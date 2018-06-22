CREATE TABLE ddt_anamnesis (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_complaints VARCHAR(2048),
  dss_anamnesis_morbi VARCHAR(2048),
  dss_anamnesis_vitae VARCHAR(2048),
  dss_anamnesis_allergy VARCHAR(512),
  dss_anamnesis_epid VARCHAR(512),
  dss_past_surgeries VARCHAR(512),
  dss_accompanying_illnesses VARCHAR(512),
  dss_drugs_intoxication VARCHAR(512),
  dss_st_presens VARCHAR(512),
  dss_respiratory_system VARCHAR(512),
  dss_cardiovascular_system VARCHAR(512),
  dss_digestive_system VARCHAR(512),
  dss_urinary_system VARCHAR(512),
  dss_nervous_system VARCHAR(512),
  dss_diagnosis_justification VARCHAR(512)
);

CREATE TRIGGER ddt_anamnesis BEFORE INSERT OR UPDATE
  ON ddt_anamnesis FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();