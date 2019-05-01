INSERT INTO ddt_doctor_order (dss_name, dsid_group_user_id, dsi_value)
VALUES ('admission.xray_department', (SELECT g.r_object_id
                                                        FROM dm_group_users g,
                                                             ddv_doctor d
                                                        WHERE g.dsid_doctor_id = d.r_object_id
                                                          AND g.dss_group_name = 'xray_department'
                                                          AND d.dss_full_name = '������ ����� ���������'), 20);
														  
INSERT INTO ddt_doctor_order (dss_name, dsid_group_user_id, dsi_value)
VALUES ('admission.xray_department_head', (SELECT g.r_object_id
                                                        FROM dm_group_users g,
                                                             ddv_doctor d
                                                        WHERE g.dsid_doctor_id = d.r_object_id
                                                          AND g.dss_group_name = 'xray_department'
                                                          AND d.dss_full_name = '��������� ����� ����������'), 20);

INSERT INTO ddt_doctor_order (dss_name, dsid_group_user_id, dsi_value)
VALUES ('admission.xray_department_head', (SELECT g.r_object_id
                                                        FROM dm_group_users g,
                                                             ddv_doctor d
                                                        WHERE g.dsid_doctor_id = d.r_object_id
                                                          AND g.dss_group_name = 'xray_department'
                                                          AND d.dss_full_name = '������ ����� ���������'), 10);

INSERT INTO ddt_doctor_order (dss_name, dsid_group_user_id, dsi_value)
VALUES ('default.cardioreanimation_department_head', (SELECT g.r_object_id
                                                        FROM dm_group_users g,
                                                             ddv_doctor d
                                                        WHERE g.dsid_doctor_id = d.r_object_id
                                                          AND g.dss_group_name = 'cardioreanimation_department'
                                                          AND d.dss_full_name = '������� ��������� ���������'), 20);

INSERT INTO ddt_doctor_order (dss_name, dsid_group_user_id, dsi_value)
VALUES ('default.cardioreanimation_department_head', (SELECT g.r_object_id
                                                        FROM dm_group_users g,
                                                             ddv_doctor d
                                                        WHERE g.dsid_doctor_id = d.r_object_id
                                                          AND g.dss_group_name = 'cardioreanimation_department'
                                                          AND d.dss_full_name = '�������� ����� �������������'), 10);

INSERT INTO ddt_doctor_order (dss_name, dsid_group_user_id, dsi_value)
VALUES ('default.anesthesiology_department', (SELECT g.r_object_id
                                                        FROM dm_group_users g,
                                                             ddv_doctor d
                                                        WHERE g.dsid_doctor_id = d.r_object_id
                                                          AND g.dss_group_name = 'anesthesiology_department'
                                                          AND d.dss_full_name = '�������� ���� ��������'), 20);