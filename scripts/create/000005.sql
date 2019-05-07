CREATE TABLE ddt_patient (
  r_object_id              varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date          TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date            TIMESTAMP               NOT NULL,

  dss_last_name            VARCHAR(100)            NOT NULL,
  dss_first_name           VARCHAR(100)            NOT NULL,
  dss_middle_name          VARCHAR(100)            NOT NULL,

  dss_phone                VARCHAR(15),
  dss_address              VARCHAR(256),
  dsdt_birthdate           date,
  dsd_weight               real,
  dsd_high                 real,

  dss_snils                VARCHAR(40),
  dss_oms                  VARCHAR(40),
  dss_med_code             VARCHAR(20),

  dss_passport_serial      VARCHAR(10),
  dss_passport_num         VARCHAR(20),
  dss_passport_issue_place VARCHAR(128),
  dss_passport_date        TIMESTAMP,
  dsb_sd                   boolean,
  dsb_sex                  boolean NOT NULL,
  dss_blood_group          VARCHAR(8),
  dss_rh_factor            VARCHAR(8),
  dss_kell                 VARCHAR(16),
  dss_phenotype            VARCHAR(16)
);

CREATE TRIGGER ddt_patient_trg_modify_date
  BEFORE INSERT OR UPDATE
  ON ddt_patient
  FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE VIEW ddv_patient (
    r_object_id,
    r_creation_date,
    r_modify_date,

    dss_last_name,
    dss_first_name,
    dss_middle_name,

    dss_phone,
    dss_address,
    dsdt_birthdate,
    dsd_weight,
    dsd_high,

    dss_snils,
    dss_oms,
    dss_med_code,

    dss_passport_serial,
    dss_passport_num,
    dss_passport_issue_place,
    dss_passport_date,
    dsb_sd,

    dss_full_name,
    dss_short_name,
	dsb_sex,
	
	dss_blood_group,
	dss_rh_factor,
	dss_kell,
	dss_phenotype
) AS
  SELECT
    r_object_id,
    r_creation_date,
    r_modify_date,

    dss_last_name,
    dss_first_name,
    dss_middle_name,

    dss_phone,
    dss_address,
    dsdt_birthdate,
    dsd_weight,
    dsd_high,

    dss_snils,
    dss_oms,
    dss_med_code,

    dss_passport_serial,
    dss_passport_num,
    dss_passport_issue_place,
    dss_passport_date,
    dsb_sd,

    CONCAT(dss_last_name, ' ', dss_first_name, ' ', dss_middle_name)                                   AS dss_full_name,
    CONCAT(dss_last_name, ' ', SUBSTR(dss_first_name, 1, 1), '. ', SUBSTR(dss_middle_name, 1, 1), '.') AS dss_short_name,
	dsb_sex,
	
		dss_blood_group,
	dss_rh_factor,
	dss_kell,
	dss_phenotype

  FROM ddt_patient;