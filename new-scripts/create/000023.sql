CREATE VIEW ddv_history(dsid_hospitality_session, dss_operation_type, dsid_operation_id, dss_operation_name, 
dsdt_operation_date, dss_doctor_name, dss_description) AS 
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
		WHEN 'ddt_uzi' THEN 'Анализы: УЗИ'
		WHEN 'ddt_specialist_conclusion' THEN 'Анализы: Заключение специалистов'
		WHEN 'ddt_holter' THEN 'Анализы: Холтер'
		WHEN 'ddt_issued_medicine_list' THEN 'Назначение лекарственных препаратов'
		WHEN 'ddt_journal' THEN 'Журнал'
		WHEN 'ddt_consilium' THEN 'Консилиум'
		WHEN 'ddt_blood_analysis' THEN 'Анализы:Кровь'
		WHEN 'ddt_hormones' THEN 'Анализы:Гормоны'
		WHEN 'ddt_coagulogram' THEN 'Анализы:Коагулограмма'
		WHEN 'ddt_serology' THEN 'Анализы:Группа крови, инфекции'
		WHEN 'ddt_inspection' THEN 'Ежедневный обход'
		WHEN 'ddt_epicrisis' THEN 'Эпикриз'
		WHEN 'ddt_oncologic_markers' THEN 'Онкомаркеры'
		END AS dss_operation_name,
	history.dsdt_operation_date AS dsdt_operation_date,
	doc.dss_initials AS dss_doctor_name,
	history.dss_description AS dss_description
	
FROM ddt_history history LEFT JOIN ddt_doctor doc ON history.dsid_doctor=doc.r_object_id

WHERE history.dsb_deleted=false order by dsdt_operation_date;