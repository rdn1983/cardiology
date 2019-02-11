CREATE TABLE ddt_patient (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_last_name        VARCHAR(100)            NOT NULL,
  dss_first_name       VARCHAR(100)            NOT NULL,
  dss_middle_name      VARCHAR(100)            NOT NULL,
  
  dss_phone VARCHAR(15),
  dss_address VARCHAR(256),
  dsdt_birthdate date,
  dsd_weight real,
  dsd_high real,

  dss_snils VARCHAR(40),
  dss_oms VARCHAR(40),
  dss_med_code VARCHAR(20),

  dss_passport_serial VARCHAR(10),
  dss_passport_num VARCHAR(20),
  dss_passport_issue_place VARCHAR(128),
  dss_passport_date TIMESTAMP,
  dsb_sd boolean
);

CREATE TRIGGER ddt_patient_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_patient FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();