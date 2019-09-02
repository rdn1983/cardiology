CREATE TABLE ddt_journal (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_journal_day VARCHAR(16) REFERENCES ddt_journal_day(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_admission_date timestamp,

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
  dss_diagnosis VARCHAR(256),
  dsb_freeze boolean,
  dsd_weight real
);

CREATE TRIGGER ddt_journal_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_journal FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

