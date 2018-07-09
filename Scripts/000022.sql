CREATE OR REPLACE VIEW ddv_history(dsid_hospitality_session, dss_operation_type, dsid_operation_id, dss_operation_name, 
r_creation_date, dss_doctor_name, dss_description) AS 
SELECT history.dsid_hospitality_session as dsid_hospitality_session, 
	history.dss_operation_type AS dss_operation_type,
	history.dsid_operation_id AS dsid_operation_id,
	CASE dss_operation_type 
		WHEN 'ddt_hospital' THEN 'Прием пациента'
		WHEN 'ddt_anamnesis' THEN 'Первичный осмотр'
		WHEN 'ddt_patient_analysis' THEN 'Анализы'
		END AS dss_operation_name,
	history.r_creation_date AS r_creation_date,
	doc.dss_initials AS dss_doctor_name,
	history.dss_description AS dss_description
	
FROM ddt_doctors doc, ddt_history history 
WHERE history.dsid_doctor=doc.r_object_id;