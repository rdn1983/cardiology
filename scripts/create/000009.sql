CREATE FUNCTION dmtrg_f_ddt_hospital_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.r_object_id, NEW.dsid_patient, NEW.dsid_duty_doctor, NEW.r_object_id, TG_TABLE_NAME , NEW.dsdt_admission_date, 'Прием пациента');
 RETURN NEW;
END;
$BODY$;

CREATE TRIGGER ddt_hospital_trg_audit AFTER INSERT 
	ON ddt_hospital FOR EACH ROW 
EXECUTE PROCEDURE dmtrg_f_ddt_hospital_audit();