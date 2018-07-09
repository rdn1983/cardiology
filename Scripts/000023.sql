CREATE TABLE ddt_release_patient (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsdt_okr_release_date timestamp,
  dsb_is_working boolean,
  dsb_dismissed_less30d boolean,
  dss_profession VARCHAR(256),
  dss_occupational_hazard VARCHAR(128),
  dsb_pensioneer boolean,
  dss_disability_num VARCHAR(10),
  dss_year_disabilities VARCHAR(40),
  dsb_sicklist_need boolean,
  dsb_extr_opened_sicklist boolean,
  dss_extr_sicklist_num VARCHAR(128),
  dsdt_extr_startdate timestamp,
  dsdt_extr_enddate timestamp,
  dss_our_sicklist_num VARCHAR(128),
  dsdt_our_startdate timestamp,
  dsdt_our_enddate timestamp
);


CREATE TRIGGER ddt_release_patient BEFORE INSERT OR UPDATE
  ON ddt_release_patient FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();


