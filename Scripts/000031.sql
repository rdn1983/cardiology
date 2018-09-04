CREATE OR REPLACE VIEW ddv_all_diagnosis(dsid_hospitality_session, dss_diagnosis, r_object_id, object_type) AS 
SELECT dsid_hospitality_session as dsid_hospitality_session, 
	dss_diagnosis AS dss_diagnosis,
	r_object_id AS r_object_id,
	'��������� ������' as r_object_type FROM ddt_anamnesis 
	UNION ALL 
	SELECT dsid_hospitality_session as dsid_hospitality_session, 
	dss_diagnosis AS dss_diagnosis,
	r_object_id AS r_object_id,
	'������' as r_object_type FROM ddt_journal 
	UNION ALL
	SELECT dsid_hospitality_session as dsid_hospitality_session, 
	dss_diagnosis AS dss_diagnosis,
	r_object_id AS r_object_id,
	'���������' as r_object_type FROM ddt_consilium 
	UNION ALL
	SELECT dsid_hospitality_session as dsid_hospitality_session, 
	dss_diagnosis AS dss_diagnosis,
	r_object_id AS r_object_id,
	'���������� �����' as r_object_type FROM ddt_inspection
	;


