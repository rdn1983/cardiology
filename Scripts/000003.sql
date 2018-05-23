CREATE TABLE ddt_values (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_name VARCHAR(100) NOT NULL UNIQUE,
  dss_value VARCHAR(1024)
);

CREATE TRIGGER ddt_values_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_values FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.lastname', 'Борисов');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.name', 'Эраст');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.secondname', 'Петрович')
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.birthday', '08.01.1954');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.receipttime', '18.03.2018 10:00:00');

CREATE TABLE ddt_doctors (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_login VARCHAR(100) NOT NULL UNIQUE,
  dss_full_name VARCHAR(256),
  dss_initials VARCHAR(256),
  dss_appointment_name VARCHAR(128),
  dss_phone VARCHAR(15),
  dss_email VARCHAR(40),
  dsi_appointment_type int
);

CREATE TRIGGER ddt_doctors_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_doctors FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();


CREATE TABLE ddt_patient (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_login VARCHAR(100) NOT NULL UNIQUE,
  dss_full_name VARCHAR(256),
  dss_initials VARCHAR(100),
  dss_phone VARCHAR(15),
  dss_address VARCHAR(256),
  dsdt_birthdate date,
  dsd_weight real,
  dsd_high real,

  dss_med_code VARCHAR(20)
);

CREATE TRIGGER ddt_patient_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_patient FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();


CREATE TABLE ddt_cure (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_name VARCHAR(100) NOT NULL UNIQUE,
  dsi_type int
);

CREATE TRIGGER ddt_cure BEFORE INSERT OR UPDATE
  ON ddt_cure FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();


CREATE TABLE ddt_issued_medicine (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_cure VARCHAR(100),
  dsid_doctor VARCHAR(100),
  dsid_patient VARCHAR(100)
);

CREATE TRIGGER ddt_issued_medicine BEFORE INSERT OR UPDATE
  ON ddt_issued_medicine FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE TABLE ddt_hospital (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_patient VARCHAR(100),
  dsdt_admission_date timestamp,
  dsid_duty_doctor VARCHAR(100),
  dsid_curing_doctor VARCHAR(100),
  dsid_substitution_doctor VARCHAR(100),
  dsb_active boolean,
  dsb_reject_cure boolean,
  dsb_death boolean
);

CREATE TRIGGER ddt_hospital BEFORE INSERT OR UPDATE
  ON ddt_hospital FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE TABLE ddt_journal (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_patient VARCHAR(100),
  dsdt_admission_date timestamp,
  dsid_doctor VARCHAR(100),
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

