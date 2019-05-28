CREATE TABLE ddt_journal (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_journal_day VARCHAR(16) REFERENCES ddt_journal_day(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_admission_date timestamp,

  dss_complaints VARCHAR(256),
  dss_chdd VARCHAR(256),
  dss_chss VARCHAR(256),
  dss_ps VARCHAR(256),
  dss_ad VARCHAR(256),
  dss_monitor VARCHAR(256),
  dss_rhythm VARCHAR(256),
  dsb_good_rhythm boolean,
  dss_surgeon_exam VARCHAR(512),
  dss_cardio_exam VARCHAR(512),
  dss_ekg VARCHAR(512),
  dss_journal VARCHAR(1024),
  dsi_journal_type int,
  dsb_release_journal boolean,
  dss_diagnosis VARCHAR(256),
  dsb_freeze boolean,
  dsd_weight real
);

CREATE TRIGGER ddt_journal_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_journal FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();


CREATE FUNCTION dmtrg_f_ddt_journal_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
IF (NEW.dsi_journal_type = 0) THEN
        INSERT INTO ddt_history 
		(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 		VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_admission_date, 
 		'Журнал до КАГ от ' || to_char(NEW.dsdt_admission_date, 'dd.mm.YYYY HH24:MM'));
 		RETURN NEW;
ELSIF (NEW.dsi_journal_type = 1) THEN
        INSERT INTO ddt_history 
		(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 		VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_admission_date, 
 		'Журнал после КАГ от ' || to_char(NEW.dsdt_admission_date, 'dd.mm.YYYY HH24:MM'));
 		RETURN NEW;
ELSIF (NEW.dsi_journal_type = 2) THEN
        INSERT INTO ddt_history 
		(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 		VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_admission_date, 
 		'Журнал без КАГ от ' || to_char(NEW.dsdt_admission_date, 'dd.mm.YYYY HH24:MM'));
 		RETURN NEW;
ELSIF (NEW.dsi_journal_type = 3) THEN
        INSERT INTO ddt_history 
		(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 		VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_admission_date, 
 		'Обоснование отложенной коронароангиографии от ' || to_char(NEW.dsdt_admission_date, 'dd.mm.YYYY HH24:MM'));
 		RETURN NEW;
END IF;
END;
$BODY$;

CREATE TRIGGER ddt_journal_trg_audit AFTER INSERT 
	ON ddt_journal FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_ddt_journal_audit();