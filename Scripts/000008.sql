CREATE TABLE ddt_issued_medicine_list (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id) ON DELETE CASCADE,
  dsdt_issuing_date timestamp,
  dsid_parent_id VARCHAR(16),
  dss_parent_type VARCHAR(30),
  dss_diagnosis VARCHAR(30),
  dss_has_kag VARCHAR(30),
  dsb_skip_print BOOLEAN
);

CREATE TRIGGER ddt_issued_medicine_list BEFORE INSERT OR UPDATE
  ON ddt_issued_medicine_list FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_issued_medicine_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_issuing_date);
 RETURN NEW;
END;
' LANGUAGE  plpgsql;


CREATE TRIGGER audit_ddt_issued_medicine_list AFTER INSERT 
	ON ddt_issued_medicine_list FOR EACH ROW
EXECUTE PROCEDURE audit_ddt_issued_medicine_creating_row();

CREATE TABLE ddt_issued_medicine (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_med_list VARCHAR(16) REFERENCES ddt_issued_medicine_list(r_object_id) ON DELETE CASCADE,
  dsid_cure VARCHAR(16) REFERENCES ddt_cure(r_object_id) ON DELETE CASCADE
);


CREATE TRIGGER ddt_issued_medicine BEFORE INSERT OR UPDATE
  ON ddt_issued_medicine FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

