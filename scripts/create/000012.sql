CREATE VIEW ddv_active_hospital_patients (
    dsdt_admission_date,
    dss_doc_name,
    dss_patient_name,
    dss_room_cell,
    dss_diagnosis,
    dsid_patient_id,
    dsid_doctor_id,
    dss_med_code,
    dsid_hospital_session,
    dsb_active
) AS
  SELECT
    hosp.dsdt_admission_date as dsdt_admission_date,
    CONCAT(doc.dss_last_name, ' ', SUBSTR(doc.dss_first_name, 1, 1), '. ', SUBSTR(doc.dss_middle_name, 1, 1), '.') AS dss_doc_name,
    CONCAT(pat.dss_last_name, ' ', SUBSTR(pat.dss_first_name, 1, 1), '. ', SUBSTR(pat.dss_middle_name, 1, 1), '.') AS dss_patient_name,
    hosp.dss_room_cell       AS dss_room_cell,
    hosp.dss_diagnosis       AS dss_diagnosis,
    hosp.dsid_patient        AS dsid_patient_id,
    hosp.dsid_curing_doctor  AS dsid_doctor_id,
    pat.dss_med_code         AS dss_med_code,
    hosp.r_object_id         AS dsid_hospital_session,
    hosp.dsb_active          AS dsb_active

  FROM ddt_patient pat, ddt_doctor doc, ddt_hospital hosp
  WHERE hosp.dsid_patient = pat.r_object_id AND hosp.dsid_curing_doctor = doc.r_object_id;