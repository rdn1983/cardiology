CREATE TABLE ddt_history (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsid_operation_id VARCHAR(16),
  dsdt_operation_date timestamp,
  dss_operation_type VARCHAR(60),
  dss_description VARCHAR(256)
);


CREATE TRIGGER ddt_history BEFORE INSERT OR UPDATE
  ON ddt_history FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();


