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
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksup'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='oksdown'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='kag'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='aorta'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='gb'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='piks'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='pikvik'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='dep'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'���� ��� \n ����� ����������'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'���, ���; Ht; ��������, ���������, �����������, ���������, ����� �����, ���������, ��, ��; ����'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'���,���, ���, ���-��'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'Rg-������ ������� ������� ������- ��������� ������ � ���'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'���������� ��, ���, ���, t'
);
INSERT INTO ddt_issued_action (dsdt_issuing_date, dsid_parent_id, dss_parent_type, dss_action) VALUES (
current_timestamp, 
(SELECT r_object_id FROM ddt_anamnesis where dss_template_name ='death'), 
'ddt_anamnesis',
'��������� ��������� ��������, ��������� ����� ��� ������� 1%�-��� ����������, � ����������� ����������� ��� ���������������� ����� ������ ������������ ��������.'
);