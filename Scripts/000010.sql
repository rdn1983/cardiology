CREATE OR REPLACE VIEW ddv_active_hospital_patients(dsdt_admission_date, dss_doc_name, dss_patient_name, 
dss_romm_cell, dss_diagnosis, dsid_patient_id, dsid_doctor_id, dss_med_code) AS 
SELECT hosp.dsdt_admission_date as dsdt_admission_date, 
	doc.dss_initials AS dss_doc_name,
	pat.dss_initials AS dss_patient_name,
	hosp.dss_room_cell AS dss_room_cell,
	hosp.dss_diagnosis AS dss_diagnosis,
	hosp.dsid_patient AS dsid_patient_id,
	hosp.dsid_curing_doctor AS dsid_doctor_id,
	pat.dss_med_code AS dss_med_code

FROM ddt_patient pat, ddt_doctors doc, ddt_hospital hosp 
WHERE hosp.dsid_patient=pat.r_object_id AND hosp.dsid_curing_doctor=doc.r_object_id AND hosp.dsb_active=true;