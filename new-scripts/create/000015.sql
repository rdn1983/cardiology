CREATE TABLE ddt_specialist_conclusion (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_analysis_date timestamp,
  dss_neurolog VARCHAR(512),
  dss_surgeon VARCHAR(512),
  dss_neuro_surgeon VARCHAR(512),
  dss_endocrinologist VARCHAR(512),

  dsid_parent VARCHAR(16),
  dss_parent_type VARCHAR(30)
);

CREATE TRIGGER ddt_specialist_conclusion_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_specialist_conclusion FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_specialist_conclusion_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
  INSERT INTO ddt_history
  (dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
  VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы: Заключение специалистов');
  RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_specialist_conclusion_trg_audit AFTER INSERT
  ON ddt_specialist_conclusion FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_ddt_specialist_conclusion_audit();