CREATE TABLE ddt_serology (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_blood_type VARCHAR(6),
  dss_rhesus_factor VARCHAR(30),
  dss_phenotype VARCHAR(512),
  dss_kell_ag VARCHAR(30),
  dss_rw VARCHAR(30),
  dss_hbs_ag VARCHAR(30),
  dss_anti_hcv VARCHAR(30),
  dss_hiv VARCHAR(30)
);



CREATE TRIGGER ddt_serology BEFORE INSERT OR UPDATE
  ON ddt_serology FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();