
CREATE TABLE ddt_consilium (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  
  dss_goal VARCHAR(2048),
  dss_dynamics VARCHAR(2048),
  dss_diagnosis VARCHAR(526),
  dss_decision VARCHAR(2048),
  dss_duty_admin_name VARCHAR(256)
);

CREATE TRIGGER ddt_consilium BEFORE INSERT OR UPDATE
  ON ddt_consilium FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_consilium_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, '', NEW.r_object_id, TG_TABLE_NAME );
 RETURN NEW;
END;
' LANGUAGE  plpgsql;


CREATE TRIGGER audit_ddt_consilium AFTER INSERT 
	ON ddt_consilium FOR EACH ROW
EXECUTE PROCEDURE audit_ddt_consilium_creating_row();



CREATE TABLE ddt_consilium_members (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_consilium VARCHAR(16) REFERENCES ddt_consilium(r_object_id),
  
  dss_appointment_name VARCHAR(512),
  dss_doctor_name VARCHAR(512)
);

CREATE TRIGGER ddt_consilium_members BEFORE INSERT OR UPDATE
  ON ddt_consilium_members FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();
