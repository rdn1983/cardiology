CREATE TABLE ddt_xray (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_chest_xray VARCHAR(512),
  dss_control_radiography VARCHAR(512),
  dss_mskt VARCHAR(512),
  dss_kt VARCHAR(512),
  dss_mrt VARCHAR(512)
);



CREATE TRIGGER ddt_xray BEFORE INSERT OR UPDATE
  ON ddt_xray FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();