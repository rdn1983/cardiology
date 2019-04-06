CREATE TABLE ddt_history (
  r_object_id              varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date          TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date            TIMESTAMP               NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital (r_object_id),
  dsid_patient             VARCHAR(16) REFERENCES ddt_patient (r_object_id),
  dsid_doctor              VARCHAR(16) REFERENCES ddt_doctor (r_object_id),
  dsid_operation_id        VARCHAR(16),
  dsdt_operation_date      timestamp,
  dss_operation_type       VARCHAR(60),
  dss_description          VARCHAR(256),
  dsdt_delete_date         timestamp,
  dsb_deleted              boolean                 default false,
  dss_operation_name       TEXT
);

CREATE TRIGGER ddt_history_trg_modify_date
  BEFORE INSERT OR UPDATE
  ON ddt_history
  FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE VIEW ddv_history AS
  SELECT
    history.dsid_hospitality_session,
    history.dss_operation_type,
    history.dsid_operation_id,
    history.dss_operation_name,
    history.dsdt_operation_date,
    CONCAT(doc.dss_last_name, ' ', doc.dss_first_name, ' ', doc.dss_middle_name) AS dss_doctor_name,
    CONCAT(doc.dss_last_name, ' ', SUBSTR(doc.dss_first_name, 1, 1), '. ', SUBSTR(doc.dss_middle_name, 1, 1), '.') AS dss_doctor_short_name,
    history.dss_description
  FROM (ddt_history history
    LEFT JOIN ddt_doctor doc ON (history.dsid_doctor = doc.r_object_id))
  WHERE (history.dsb_deleted = false)
  ORDER BY history.dsdt_operation_date;