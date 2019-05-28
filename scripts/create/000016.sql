CREATE TABLE ddt_urine_analysis (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_analysis_date timestamp,
  dss_color VARCHAR(512),
  dss_acidity VARCHAR(512),
  dss_specific_gravity VARCHAR(512),
  dss_leukocytes VARCHAR(512),
  dss_erythrocytes VARCHAR(512),
  dss_glucose VARCHAR(512),
  dss_protein VARCHAR(512),
  dss_ketones VARCHAR(512),
  dsb_admission_analysis BOOLEAN,
  dsb_discharge_analysis BOOLEAN,
  dsid_parent VARCHAR(16),
  dss_parent_type VARCHAR(30)
);

CREATE TRIGGER ddt_urine_analysis_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_urine_analysis FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_urine_analysis_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: Моча');
 RETURN NEW;
END;
$BODY$;


CREATE TRIGGER ddt_urine_analysis_trg_audit AFTER INSERT 
	ON ddt_urine_analysis FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_urine_analysis_audit();

create trigger urine_modify_history after update on ddt_urine_analysis for each row execute procedure analysis_modify_history_fct();