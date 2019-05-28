CREATE TABLE ddt_journal_day (
	r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
	r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
	r_modify_date TIMESTAMP NOT NULL,

	dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
	dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
	dsdt_admission_date timestamp,
	dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
	dss_diagnosis VARCHAR(512),

	dss_name VARCHAR(256),
	dsi_journal_type int
);

CREATE TRIGGER ddt_journal_day_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_journal_day FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_journal_day_audit()
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

CREATE TRIGGER ddt_journal_day_trg_audit AFTER INSERT 
	ON ddt_journal_day FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_ddt_journal_day_audit();

CREATE OR REPLACE FUNCTION journal_modify_history_fct() 
RETURNS TRIGGER 
language 'plpgsql' 
as $$ DECLARE new_name TEXT; 
BEGIN 
IF (NEW.dsi_journal_type = 0) THEN new_name='Журнал до КАГ от ' || to_char(NEW.dsdt_admission_date, 'dd.mm.YYYY HH24:MM');
ELSEIF (NEW.dsi_journal_type = 1) THEN new_name='Журнал после КАГ от ' || to_char(NEW.dsdt_admission_date, 'dd.mm.YYYY HH24:MM');
END IF;
UPDATE ddt_history SET dsdt_operation_date=NEW.dsdt_admission_date, dss_operation_name=new_name WHERE dsid_operation_id=NEW.r_object_id; 
return new; end; $$;

create trigger jrnl_modify_history after update on ddt_journal_day for each row execute procedure journal_modify_history_fct();
