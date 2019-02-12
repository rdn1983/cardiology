CREATE TABLE ddt_transfer (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_start_date timestamp,
  dsdt_end_date timestamp,
  dss_destination VARCHAR(256),
  dss_contacts VARCHAR(256),
  dss_transfer_justification VARCHAR(512),
  dsi_type int
);

CREATE TRIGGER ddt_transfer_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_transfer FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();
