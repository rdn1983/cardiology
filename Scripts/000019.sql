CREATE TABLE ddt_egds (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_egds VARCHAR(2048),
  dsb_admission_analysis boolean
);



CREATE TRIGGER ddt_egds BEFORE INSERT OR UPDATE
  ON ddt_egds FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();