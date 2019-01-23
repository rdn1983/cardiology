UPDATE ddt_history SET dss_operation_name = 'Журнал' WHERE dss_operation_type = 'ddt_journal';

ALTER TABLE ddt_history ADD COLUMN dss_operation_name TEXT;

UPDATE ddt_history SET dss_operation_name = 'Прием пациента' WHERE dss_operation_type = 'ddt_hospital';
UPDATE ddt_history SET dss_operation_name = 'Первичный осмотр' WHERE dss_operation_type = 'ddt_anamnesis';
UPDATE ddt_history SET dss_operation_name = 'Анализы: ЭКГ' WHERE dss_operation_type = 'ddt_ekg';
UPDATE ddt_history SET dss_operation_name = 'Анализы: Моча' WHERE dss_operation_type = 'ddt_urine_analysis';
UPDATE ddt_history SET dss_operation_name = 'Анализы: ЭГДС' WHERE dss_operation_type = 'ddt_egds';
UPDATE ddt_history SET dss_operation_name = 'Анализы: Рентген' WHERE dss_operation_type = 'ddt_xray';
UPDATE ddt_history SET dss_operation_name = 'Анализы: УЗИ' WHERE dss_operation_type = 'ddt_uzi';
UPDATE ddt_history SET dss_operation_name = 'Анализы: Заключение специалистов' WHERE dss_operation_type = 'ddt_specialist_conclusion';
UPDATE ddt_history SET dss_operation_name = 'Анализы: Холтер' WHERE dss_operation_type = 'ddt_holter';
UPDATE ddt_history SET dss_operation_name = 'Назначение лекарственных препаратов' WHERE dss_operation_type = 'ddt_issued_medicine_list';
UPDATE ddt_history SET dss_operation_name = 'Консилиум' WHERE dss_operation_type = 'ddt_consilium';
UPDATE ddt_history SET dss_operation_name = 'Анализы:Кровь' WHERE dss_operation_type = 'ddt_blood_analysis';
UPDATE ddt_history SET dss_operation_name = 'Анализы:Гормоны' WHERE dss_operation_type = 'ddt_hormones';
UPDATE ddt_history SET dss_operation_name = 'Анализы:Коагулограмма' WHERE dss_operation_type = 'ddt_coagulogram';
UPDATE ddt_history SET dss_operation_name = 'Анализы:Группа крови, инфекции' WHERE dss_operation_type = 'ddt_serology';
UPDATE ddt_history SET dss_operation_name = 'Ежедневный обход' WHERE dss_operation_type = 'ddt_inspection';
UPDATE ddt_history SET dss_operation_name = 'Эпикриз' WHERE dss_operation_type = 'ddt_epicrisis';
UPDATE ddt_history SET dss_operation_name = 'Онкомаркеры' WHERE dss_operation_type = 'ddt_oncologic_markers';
UPDATE ddt_history SET dss_operation_name = 'Анализы: КАГ' WHERE dss_operation_type = 'ddt_kag';
UPDATE ddt_history SET dss_operation_name = 'Журнал' WHERE dss_operation_type = 'ddt_journal';


CREATE OR REPLACE FUNCTION audit_ddt_journal_creating_row()
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



CREATE OR REPLACE FUNCTION audit_anamnesis_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_inspection_date,
 		'Первичный осмотр');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_blood_analysis_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы:Кровь');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_coagulogram_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы:Коагулограмма');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_consilium_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_consilium_date, 'Консилиум');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_egds_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: ЭГДС');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_ekg_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: ЭКГ');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_epicrisis_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_epicrisis_date, 'Эпикриз');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_holter_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: Холтер');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_hormones_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы:Гормоны');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_hospital_creating_row()
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


CREATE OR REPLACE FUNCTION audit_ddt_inspection_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_inspection_date, 'Ежедневный обход');
 RETURN NEW;
END;
$BODY$;


CREATE OR REPLACE FUNCTION audit_ddt_issued_medicine_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_issuing_date, 'Назначение лекарственных препаратов');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_kag_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: КАГ');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_oncologic_markers_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Онкомаркеры');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_serology_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы:Группа крови, инфекции');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_specialist_conclusion_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы: Заключение специалистов');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_urine_analysis_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: Моча');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_uzi_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_analysis_date, 'Анализы: УЗИ');
 RETURN NEW;
END;
$BODY$;

CREATE OR REPLACE FUNCTION audit_ddt_xray_creating_row()
  returns trigger
language plpgsql
as $BODY$
BEGIN
INSERT INTO ddt_history 
(dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
 VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, NEW.dsdt_analysis_date, 'Анализы: Рентген');
 RETURN NEW;
END;
$BODY$;


CREATE OR REPLACE VIEW ddv_history AS
  SELECT history.dsid_hospitality_session,
    history.dss_operation_type,
    history.dsid_operation_id,
    history.dss_operation_name,
    history.dsdt_operation_date,
    doc.dss_initials AS dss_doctor_name,
    history.dss_description
  FROM (ddt_history history
    LEFT JOIN ddt_doctors doc ON (((history.dsid_doctor)::text = (doc.r_object_id)::text)))
  WHERE (history.dsb_deleted = false)
  ORDER BY history.dsdt_operation_date;








