CREATE TABLE ddt_issued_action (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_doctor VARCHAR(16) REFERENCES ddt_doctors(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id) ON DELETE CASCADE,
  dsdt_issuing_date timestamp,
  dsid_parent_id VARCHAR(16),
  dss_parent_type VARCHAR(30),
  dss_action VARCHAR(256)
);

CREATE TRIGGER ddt_issued_action BEFORE INSERT OR UPDATE
  ON ddt_issued_action FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'Стол ОВД \n Режим постельный'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'ОАК, ОАМ; Ht; Мочевина, креатинин, электролиты, билирубин, общий белок, альбумины, ХС, ТГ; АЧТВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'АЛТ,АСТ, КФК, КФК-МВ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'ЭКГ'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'Rg-графия органов грудной клетки- исключить застой в МКК'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'Мониторинг АД, ЧСС, ЭКГ, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'Установка венозного катетера, обработка места его стояния 1%р-ром йодопирона, с последующим промыванием его антикоагулянтами после каждой внутривенной инъекции.'
);