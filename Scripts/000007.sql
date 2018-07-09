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

CREATE OR REPLACE FUNCTION audit_hospital_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type)
 VALUES (NEW.r_object_id, NEW.dsid_patient, NEW.dsid_duty_doctor, NEW.r_object_id, TG_TABLE_NAME );
 RETURN NEW;
END;
' LANGUAGE  plpgsql;


CREATE TRIGGER audit_ddt_hospital AFTER INSERT 
	ON ddt_hospital FOR EACH ROW 
EXECUTE PROCEDURE audit_hospital_creating_row();

