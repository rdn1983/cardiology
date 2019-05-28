CREATE TABLE ddt_consilium (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id)  ON DELETE CASCADE,
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id)  ON DELETE CASCADE,
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_consilium_date timestamp,
  
  dss_goal VARCHAR(2048),
  dss_dynamics VARCHAR(2048),
  dss_diagnosis VARCHAR(526),
  dss_decision VARCHAR(2048),
  dss_duty_admin_name VARCHAR(256)
);

CREATE TRIGGER ddt_consilium_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_consilium FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_consilium_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_consilium_date, 'Консилиум');
 RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_consilium_trg_audit AFTER INSERT 
	ON ddt_consilium FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_ddt_consilium_audit();

CREATE OR REPLACE FUNCTION consilium_modify_history_fct() 
RETURNS TRIGGER 
language 'plpgsql' 
as $$ 
BEGIN 
	UPDATE ddt_history SET dsdt_operation_date=NEW.dsdt_consilium_date WHERE dsid_operation_id=NEW.r_object_id; 
return new; end; $$;

create trigger consilium_modify_history after update on ddt_consilium for each row execute procedure consilium_modify_history_fct();

CREATE TABLE ddt_consilium_relation (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_consilium VARCHAR(16) NOT NULL REFERENCES ddt_consilium(r_object_id) ON DELETE CASCADE,
  dsid_member VARCHAR(16) NOT NULL REFERENCES ddt_consilium_group_member(r_object_id) ON DELETE RESTRICT
);

CREATE TRIGGER ddt_consilium_relation_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_consilium_relation FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();