
CREATE TABLE ddt_journal (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsdt_admission_date timestamp,
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),

  dss_complaints VARCHAR(256),
  dss_chdd VARCHAR(256),
  dss_chss VARCHAR(256),
  dss_ps VARCHAR(256),
  dss_ad VARCHAR(256),
  dss_monitor VARCHAR(256),
  dss_rhythm VARCHAR(256),
  dsb_good_rhythm boolean,
  dss_surgeon_exam VARCHAR(512),
  dss_cardio_exam VARCHAR(512),
  dss_ekg VARCHAR(512),
  dss_journal VARCHAR(1024),
  dsi_journal_type int,
  dsb_release_journal boolean,
  dss_diagnosis VARCHAR(256)
);

CREATE TRIGGER ddt_journal BEFORE INSERT OR UPDATE
  ON ddt_journal FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_journal_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_admission_date );
 RETURN NEW;
END;
' LANGUAGE  plpgsql;


CREATE TRIGGER audit_ddt_journal AFTER INSERT 
	ON ddt_journal FOR EACH ROW
EXECUTE PROCEDURE audit_ddt_journal_creating_row();