CREATE TABLE ddt_patient_analysis (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsis_urine_analysis VARCHAR(16) ,
  dsis_uzi VARCHAR(16),
  dsid_holter VARCHAR(16) ,
  dsid_specialist_conclusion VARCHAR(16) ,
  dsid_xray VARCHAR(16),
  dsid_egds VARCHAR(16),
  dsid_ekg VARCHAR(16),
  dsid_kag VARCHAR(16) 
);



CREATE TRIGGER ddt_patient_analysis BEFORE INSERT OR UPDATE
  ON ddt_patient_analysis FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();