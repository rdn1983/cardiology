CREATE TABLE ddt_urine_analysis (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_color VARCHAR(512),
  dss_acidity VARCHAR(512),
  dss_specific_gravity VARCHAR(512),
  dss_leukocytes VARCHAR(512),
  dss_erythrocytes VARCHAR(512),
  dss_glucose VARCHAR(512),
  dss_protein VARCHAR(512),
  dss_ketones VARCHAR(512)
);


CREATE TRIGGER ddt_urine_analysis BEFORE INSERT OR UPDATE
  ON ddt_urine_analysis FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();