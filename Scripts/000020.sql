CREATE TABLE ddt_hormones (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
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
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME );
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
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME );
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
  dsd_hemoglobin double,
  dsd_leucocytes double,
  dsd_platelets double,
  dsd_protein double,
  dsd_creatinine double,
  dsd_cholesterol double,
  dsd_bil double,
  dsd_iron double,
  dsd_alt double,
  dsd_ast double,
  dsd_schf double,
  dsd_amylase double,
  dsd_kfk double,
  dsd_kfk_mv double,
  dsd_srp double,
  dsd_potassium double,
  dsd_sodium double,
  dsd_chlorine double
);

CREATE TRIGGER ddt_blood_analysis BEFORE INSERT OR UPDATE
  ON ddt_blood_analysis FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_blood_analysis_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME );
 RETURN NEW;
END;
' LANGUAGE  plpgsql;

CREATE TRIGGER audit_ddt_blood_analysis AFTER INSERT 
	ON ddt_blood_analysis FOR EACH ROW 
EXECUTE PROCEDURE audit_ddt_blood_analysis_creating_row();
