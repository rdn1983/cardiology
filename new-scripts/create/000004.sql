CREATE TABLE ddt_doctor (
  r_object_id          varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date      TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date        TIMESTAMP               NOT NULL,

  dss_last_name        VARCHAR(100)            NOT NULL,
  dss_first_name       VARCHAR(100)            NOT NULL,
  dss_middle_name      VARCHAR(100)            NOT NULL
);

CREATE TRIGGER ddt_doctor_trg_modify_date
  BEFORE INSERT OR UPDATE
  ON ddt_doctor
  FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE VIEW ddv_doctor (
  r_object_id,
  r_creation_date,
  r_modify_date,
  dss_last_name,
  dss_first_name,
  dss_middle_name,
  dss_full_name,
  dss_short_name
) AS 
SELECT 
  r_object_id,
  r_creation_date,
  r_modify_date,
  dss_last_name,
  dss_first_name,
  dss_middle_name,
  
  CONCAT(dss_last_name, ' ', dss_first_name, ' ', dss_middle_name) AS dss_full_name,
  CONCAT(dss_last_name, ' ', SUBSTR(dss_first_name, 1, 1), '. ', SUBSTR(dss_middle_name, 1, 1), '.') AS dss_short_name

FROM ddt_doctor;