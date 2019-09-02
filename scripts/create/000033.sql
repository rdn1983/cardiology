CREATE VIEW ddv_all_diagnosis(dsid_hospitality_session, dss_diagnosis, r_object_id, object_type) AS 
SELECT dsid_hospitality_session as dsid_hospitality_session, 
	dss_diagnosis AS dss_diagnosis,
	r_object_id AS r_object_id,
	'Первичный осмотр' as r_object_type FROM ddt_anamnesis 
	UNION ALL 
	SELECT jd.dsid_hospitality_session as dsid_hospitality_session, 
	jrn.dss_diagnosis AS dss_diagnosis,
	jrn.r_object_id AS r_object_id,
	jd.dss_name as r_object_type FROM ddt_journal jrn, ddt_journal_day jd WHERE jrn.dsid_journal_day=jd.r_object_id
	UNION ALL
	SELECT dsid_hospitality_session as dsid_hospitality_session, 
	dss_diagnosis AS dss_diagnosis,
	r_object_id AS r_object_id,
	'Консилиум' as r_object_type FROM ddt_consilium 
	UNION ALL
	SELECT dsid_hospitality_session as dsid_hospitality_session, 
	dss_diagnosis AS dss_diagnosis,
	r_object_id AS r_object_id,
	'Ежедневный обход' as r_object_type FROM ddt_inspection
	;


