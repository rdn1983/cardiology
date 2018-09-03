CREATE TABLE ddt_hormones (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsdt_analysis_date timestamp,
  dss_t3 VARCHAR(16),
  dss_t4 VARCHAR(16),
  dss_ttg VARCHAR(16)
);

CREATE TRIGGER ddt_hormones BEFORE INSERT OR UPDATE
  ON ddt_hormones FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_hormones_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date);
 RETURN NEW;
END;
' LANGUAGE  plpgsql;

CREATE TRIGGER audit_ddt_hormones AFTER INSERT 
	ON ddt_hormones FOR EACH ROW 
EXECUTE PROCEDURE audit_ddt_hormones_creating_row();



CREATE TABLE ddt_coagulogram (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsdt_analysis_date timestamp,
  dss_achtv VARCHAR(16),
  dss_mcho VARCHAR(16),
  dss_ddimer VARCHAR(16)
);

CREATE TRIGGER ddt_coagulogram BEFORE INSERT OR UPDATE
  ON ddt_coagulogram FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_coagulogram_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date);
 RETURN NEW;
END;
' LANGUAGE  plpgsql;

CREATE TRIGGER audit_ddt_coagulogram AFTER INSERT 
	ON ddt_coagulogram FOR EACH ROW 
EXECUTE PROCEDURE audit_ddt_coagulogram_creating_row();



CREATE TABLE ddt_blood_analysis (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dss_hemoglobin VARCHAR (20),
  dss_leucocytes VARCHAR (20),
  dss_platelets VARCHAR (20),
  dss_protein VARCHAR (20),
  dss_creatinine VARCHAR (20),
  dss_cholesterol VARCHAR (20),
  dss_bil VARCHAR (20),
  dss_iron VARCHAR (20),
  dss_alt VARCHAR (20),
  dss_ast VARCHAR (20),
  dss_schf VARCHAR (20),
  dss_amylase VARCHAR (20),
  dss_kfk VARCHAR (20),
  dss_kfk_mv VARCHAR (20),
  dss_srp VARCHAR (20),
  dss_potassium VARCHAR (20),
  dss_sodium VARCHAR (20),
  dss_chlorine VARCHAR (20),
  dsb_admission_analysis BOOLEAN,
  dsb_discharge_analysis BOOLEAN,
  dsdt_analysis_date timestamp,
  
  dsid_parent VARCHAR(16),
  dss_parent_type VARCHAR(30)
);

CREATE TRIGGER ddt_blood_analysis BEFORE INSERT OR UPDATE
  ON ddt_blood_analysis FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_blood_analysis_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date);
 RETURN NEW;
END;
' LANGUAGE  plpgsql;

CREATE TRIGGER audit_ddt_blood_analysis AFTER INSERT 
	ON ddt_blood_analysis FOR EACH ROW 
EXECUTE PROCEDURE audit_ddt_blood_analysis_creating_row();
