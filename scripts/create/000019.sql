CREATE TABLE ddt_serology (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_analysis_date timestamp,
  dss_blood_type VARCHAR(6),
  dss_rhesus_factor VARCHAR(30) DEFAULT 'в работе',
  dss_phenotype VARCHAR(512) DEFAULT 'в работе',
  dss_kell_ag VARCHAR(30) DEFAULT 'в работе',
  dss_rw VARCHAR(30) DEFAULT 'в работе',
  dss_hbs_ag VARCHAR(30) DEFAULT 'в работе',
  dss_anti_hcv VARCHAR(30) DEFAULT 'в работе',
  dss_hiv VARCHAR(30) DEFAULT 'в работе'
);

CREATE TRIGGER ddt_serology_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_serology FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_serology_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы:Группа крови, инфекции');
 RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_serology_trg_audit AFTER INSERT 
	ON ddt_serology FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_serology_audit();

create trigger serology_modify_history after update on ddt_serology for each row execute procedure analysis_modify_history_fct();