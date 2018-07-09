CREATE TABLE ddt_egds (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_egds VARCHAR(2048),
  dsb_admission_analysis boolean
);



CREATE TRIGGER ddt_egds BEFORE INSERT OR UPDATE
  ON ddt_egds FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_egds_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME );
 RETURN NEW;
END;
' LANGUAGE  plpgsql;


CREATE TRIGGER audit_ddt_egds AFTER INSERT 
	ON ddt_egds FOR EACH ROW 
EXECUTE PROCEDURE audit_ddt_egds_creating_row();

CREATE TABLE ddt_ekg (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_ekg VARCHAR(2048),
  dsb_admission_analysis boolean
);



CREATE TRIGGER ddt_ekg BEFORE INSERT OR UPDATE
  ON ddt_ekg FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_ekg_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME );
 RETURN NEW;
END;
' LANGUAGE  plpgsql;


CREATE TRIGGER audit_ddt_ekg AFTER INSERT 
	ON ddt_ekg FOR EACH ROW 
EXECUTE PROCEDURE audit_ddt_ekg_creating_row();