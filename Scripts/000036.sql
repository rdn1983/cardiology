CREATE TABLE ddt_oncologic_markers (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id) ON DELETE CASCADE,
  dsdt_analysis_date timestamp,
  dsid_parent VARCHAR(16),
  dss_parent_type VARCHAR(30),
  dss_psa_common VARCHAR(60),
  dss_psa_free VARCHAR(60),
  dss_ca_199 VARCHAR(60),
  dss_ca_125 VARCHAR(60),
  dss_ca_153 VARCHAR(60),
  dss_cea VARCHAR(60),
  dss_hgch VARCHAR(60),
  dss_afr VARCHAR(60)
);

CREATE TRIGGER ddt_oncologic_markers BEFORE INSERT OR UPDATE
  ON ddt_oncologic_markers FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE OR REPLACE FUNCTION audit_ddt_oncologic_markers_creating_row () RETURNS TRIGGER AS '
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date);
 RETURN NEW;
END;
' LANGUAGE  plpgsql;


CREATE TRIGGER audit_ddt_oncologic_markers AFTER INSERT 
	ON ddt_oncologic_markers FOR EACH ROW 
EXECUTE PROCEDURE audit_ddt_oncologic_markers_creating_row();