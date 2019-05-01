CREATE TABLE ddt_issued_action (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id) ON DELETE CASCADE,
  dsdt_issuing_date timestamp,
  dsid_parent_id VARCHAR(16),
  dss_parent_type VARCHAR(30),
  dss_action VARCHAR(256)
);

CREATE TRIGGER ddt_issued_action_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_issued_action FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();