CREATE TABLE ddt_patient (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_full_name VARCHAR(256),
  dss_initials VARCHAR(100),
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

INSERT INTO ddt_patient(dss_full_name, dss_initials, dss_phone, dss_address, dsd_weight, dsd_high, dss_med_code) 
VALUES ('Борисов Эраст Петрович', 'Борисов Э.П.', '8985-123-45-67', 'Москва, ул Луначарского д.1', 76, 178, '00-00-001');