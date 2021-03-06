CREATE TABLE ddt_egds (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_analysis_date timestamp,
  dss_egds VARCHAR(2048),
  dsb_admission_analysis boolean,
  
  dsid_parent VARCHAR(16),
  dss_parent_type VARCHAR(30)
);

CREATE TRIGGER ddt_egds_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_egds FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_egds_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: ЭГДС');
 RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_egds_trg_audit AFTER INSERT 
	ON ddt_egds FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_egds_audit();

create trigger egds_modify_history after update on ddt_egds for each row execute procedure analysis_modify_history_fct();

CREATE TABLE ddt_ekg (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dss_ekg VARCHAR(2048),
  dsb_admission_analysis boolean,
  dsid_parent VARCHAR(16),
  dsdt_analysis_date timestamp,
  dss_parent_type VARCHAR(30)
);

CREATE TRIGGER ddt_ekg_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_ekg FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_ekg_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: ЭКГ');
 RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_ekg_trg_audit AFTER INSERT 
	ON ddt_ekg FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_ekg_audit();

create trigger ekg_modify_history after update on ddt_ekg for each row execute procedure analysis_modify_history_fct();