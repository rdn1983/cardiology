CREATE TABLE ddt_inspection (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsdt_inspection_date timestamp,
  dss_diagnosis VARCHAR(256),
  dss_complaints VARCHAR(256),
  dss_inspection VARCHAR(256),
  dss_kateter_placement VARCHAR(128),
  dss_inspection_result VARCHAR(256)

);

CREATE TRIGGER ddt_inspection BEFORE INSERT OR UPDATE
  ON ddt_inspection FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_inspection_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_inspection_date);
 RETURN NEW;
END;
' LANGUAGE  plpgsql;


CREATE TRIGGER audit_ddt_inspection AFTER INSERT 
	ON ddt_inspection FOR EACH ROW 
EXECUTE PROCEDURE audit_ddt_inspection_creating_row();