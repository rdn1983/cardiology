CREATE OR REPLACE VIEW ddv_history(dsid_hospitality_session, dss_operation_type, dsid_operation_id, dss_operation_name, 
r_creation_date, dss_doctor_name, dss_description) AS 
SELECT history.dsid_hospitality_session as dsid_hospitality_session, 
	history.dss_operation_type AS dss_operation_type,
	history.dsid_operation_id AS dsid_operation_id,
	CASE dss_operation_type 
		WHEN 'ddt_hospital' THEN 'Прием пациента'
		WHEN 'ddt_anamnesis' THEN 'Первичный осмотр'
		WHEN 'ddt_ekg' THEN 'Анализы: ЭКГ'
		WHEN 'ddt_urine_analysis' THEN 'Анализы: Моча'
		WHEN 'ddt_kag' THEN 'Анализы: КАГ'
		WHEN 'ddt_egds' THEN 'Анализы: ЭГДС'
		WHEN 'ddt_xray' THEN 'Анализы: Рентген'
		WHEN 'ddt_specialist_conclusion' THEN 'Анализы: Заключение специалистов'
		WHEN 'ddt_holter' THEN 'Анализы: Холтер'
		WHEN 'ddt_issued_medicine' THEN 'Назначение лекарственных препаратов'
		WHEN 'ddt_journal' THEN 'Журнал'
		END AS dss_operation_name,
	history.r_creation_date AS r_creation_date,
	doc.dss_initials AS dss_doctor_name,
	history.dss_description AS dss_description
	
FROM ddt_doctors doc, ddt_history history 
WHERE history.dsid_doctor=doc.r_object_id;