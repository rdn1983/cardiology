CREATE TABLE ddt_kag (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_results VARCHAR(2048),
  dsdt_start_time timestamp,
  dsdt_end_time timestamp,
  dss_kag_manipulation VARCHAR(2048)
);



CREATE TRIGGER ddt_kag BEFORE INSERT OR UPDATE
  ON ddt_kag FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();