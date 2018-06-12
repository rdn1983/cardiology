CREATE TABLE ddt_hospital (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsdt_admission_date timestamp,
  dsid_duty_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsid_curing_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsid_substitution_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsb_active boolean,
  dsb_reject_cure boolean,
  dsb_death boolean,
  dss_room_cell VARCHAR(16),
  dss_diagnosis VARCHAR(128)
);

CREATE TRIGGER ddt_hospital BEFORE INSERT OR UPDATE
  ON ddt_hospital FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();