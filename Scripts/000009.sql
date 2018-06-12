
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
  dss_cardio_exam VARCHAR(512)
);

CREATE TRIGGER ddt_journal BEFORE INSERT OR UPDATE
  ON ddt_journal FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();