CREATE TABLE ddt_hormones (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_analysis_date timestamp,
  dss_t3 VARCHAR(16),
  dss_t4 VARCHAR(16),
  dss_ttg VARCHAR(16)
);

CREATE TRIGGER ddt_hormones_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_hormones FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_hormones_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы:Гормоны');
 RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_hormones_trg_audit AFTER INSERT 
	ON ddt_hormones FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_hormones_audit();

CREATE TABLE ddt_coagulogram (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_analysis_date timestamp,
  dss_achtv VARCHAR(16),
  dss_mcho VARCHAR(16),
  dss_ddimer VARCHAR(16)
);

CREATE TRIGGER ddt_coagulogram_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_coagulogram FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_coagulogram_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы:Коагулограмма');
 RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_coagulogram_trg_audit AFTER INSERT 
	ON ddt_coagulogram FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_coagulogram_audit();

CREATE TABLE ddt_blood_analysis (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
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

CREATE TRIGGER ddt_blood_analysis_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_blood_analysis FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_blood_analysis_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы:Кровь');
 RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_blood_analysis_trg_audit AFTER INSERT 
	ON ddt_blood_analysis FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_blood_analysis_audit();
