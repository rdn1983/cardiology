CREATE TABLE ddt_epicrisis (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_epicrisis_date timestamp,
  dss_diagnosis VARCHAR(600),
  dsi_epicrisis_type int

);

CREATE TRIGGER ddt_epicrisis_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_epicrisis FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_epicrisis_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_epicrisis_date, 'Эпикриз');
 RETURN NEW;
END;
$BODY$;


CREATE TRIGGER ddt_epicrisis_trg_audit AFTER INSERT 
	ON ddt_epicrisis FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_epicrisis_audit();

CREATE OR REPLACE FUNCTION epicrisis_modify_history_fct() 
RETURNS TRIGGER 
language 'plpgsql' 
as $$ 
BEGIN 
	UPDATE ddt_history SET dsdt_operation_date=NEW.dsdt_epicrisis_date WHERE dsid_operation_id=NEW.r_object_id; 
return new; end; $$;

create trigger epicrs_modify_history after update on ddt_consilium for each row execute procedure epicrisis_modify_history_fct();