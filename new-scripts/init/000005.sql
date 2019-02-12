-- Отделение кардиореанимации
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Арсланбенкова' AND dss_first_name = 'Серминаз' AND dss_middle_name = 'Махмудовна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Горячева' AND dss_first_name = 'Елена' AND dss_middle_name = 'Владимировна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Кошкина' AND dss_first_name = 'Екатерина' AND dss_middle_name = 'Виленовна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Беспалова' AND dss_first_name = 'Юлия' AND dss_middle_name = 'Эдуардовна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Миронова' AND dss_first_name = 'Елена' AND dss_middle_name = 'Александровна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Докторова' AND dss_first_name = 'Марина' AND dss_middle_name = 'Викторовна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Балханова' AND dss_first_name = 'Анна' AND dss_middle_name = 'Юрьевна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Баграмова' AND dss_first_name = 'Юлия' AND dss_middle_name = 'Анатольевна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Генералова' AND dss_first_name = 'Ольга' AND dss_middle_name = 'Александровна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Щербакова' AND dss_first_name = 'Светлана' AND dss_middle_name = 'Владимировна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Кустова' AND dss_first_name = 'Татьяна' AND dss_middle_name = 'Юрьевна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('cardioreanimation_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Роот' AND dss_first_name = 'Ирина' AND dss_middle_name = 'Сергеевна'));
-- Отделение РХМДиЛ 
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('xray_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Самочатов' AND dss_first_name = 'Денис' AND dss_middle_name = 'Николаевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('xray_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Комков' AND dss_first_name = 'Артем' AND dss_middle_name = 'Андреевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('xray_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Миленькин' AND dss_first_name = 'Борис' AND dss_middle_name = 'Игоревич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('xray_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Потехин' AND dss_first_name = 'Дмитрий' AND dss_middle_name = 'Александрович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('xray_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Мостовой' AND dss_first_name = 'Игорь' AND dss_middle_name = 'Владимирович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('xray_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Шестов' AND dss_first_name = 'Денис' AND dss_middle_name = 'Васильевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('xray_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Худяков' AND dss_first_name = 'Яков' AND dss_middle_name = 'Андреевич'));
-- Отделение анестезиологии
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('anesthesiology_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Костыря' AND dss_first_name = 'Юрий' AND dss_middle_name = 'Евгеньевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('anesthesiology_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Данченко' AND dss_first_name = 'Олег' AND dss_middle_name = 'Иванович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('anesthesiology_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Ерошин' AND dss_first_name = 'Николай' AND dss_middle_name = 'Иванович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('anesthesiology_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Магидин' AND dss_first_name = 'Дмитрий' AND dss_middle_name = 'Владимирович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('anesthesiology_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Шиганова' AND dss_first_name = 'Анастасия' AND dss_middle_name = 'Михайловна'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('anesthesiology_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Капитанов' AND dss_first_name = 'Алексей' AND dss_middle_name = 'Николаевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('anesthesiology_department', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Казамбаев' AND dss_first_name = 'Евгений' AND dss_middle_name = 'Александрович'));
-- Зам. главного врача по терапии
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('therapy_deputy_head', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Арефьев' AND dss_first_name = 'Алексей' AND dss_middle_name = 'Александрович'));
-- Зав. центра анестезиологии и реанимации
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('anesthesiology_head', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Шкуратова' AND dss_first_name = 'Наталья' AND dss_middle_name = 'Владимировна'));
-- Зав. центра хирургии
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('surgery_head', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Покровский' AND dss_first_name = 'Константин' AND dss_middle_name = 'Александрович'));
-- Дежурные администраторы
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Арефьев' AND dss_first_name = 'Алексей' AND dss_middle_name = 'Александрович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Алекперов' AND dss_first_name = 'Самид' AND dss_middle_name = 'Фаязович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Горбунов' AND dss_first_name = 'Алексей' AND dss_middle_name = 'Леонидович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Горячев' AND dss_first_name = 'Владимир' AND dss_middle_name = 'Игоревич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Додица' AND dss_first_name = 'Алексей' AND dss_middle_name = 'Николаевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Зинухов' AND dss_first_name = 'Андрей' AND dss_middle_name = 'Федорович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Иванов' AND dss_first_name = 'Александр' AND dss_middle_name = 'Эдуардович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Казамбаев' AND dss_first_name = 'Евгений' AND dss_middle_name = 'Александрович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Кисель' AND dss_first_name = 'Дмитрий' AND dss_middle_name = 'Юрьевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Клименко' AND dss_first_name = 'Александр' AND dss_middle_name = 'Анатольевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Конев' AND dss_first_name = 'Дмитрий' AND dss_middle_name = 'Евгеньевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Костылев' AND dss_first_name = 'Геннадий' AND dss_middle_name = 'Николаевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Костыря' AND dss_first_name = 'Юрий' AND dss_middle_name = 'Евгеньевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Лоскутников' AND dss_first_name = 'Марк' AND dss_middle_name = 'Алексеевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Акопян' AND dss_first_name = 'Карен' AND dss_middle_name = 'Валерьевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Мартынов' AND dss_first_name = 'Павел' AND dss_middle_name = 'Александрович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Пейкер' AND dss_first_name = 'Пейкер' AND dss_middle_name = 'Николаевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Покровский' AND dss_first_name = 'Константин' AND dss_middle_name = 'Александрович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Резепов' AND dss_first_name = 'Николай' AND dss_middle_name = 'Александрович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Релин' AND dss_first_name = 'Виталий' AND dss_middle_name = 'Ефимович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Семенов' AND dss_first_name = 'Александр' AND dss_middle_name = 'Юрьевич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Семченко' AND dss_first_name = 'Виталий' AND dss_middle_name = 'Игоревич'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Соболев' AND dss_first_name = 'Владимир' AND dss_middle_name = 'Владимирович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Шандалин' AND dss_first_name = 'Вадим' AND dss_middle_name = 'Александрович'));
INSERT INTO dm_group_users (dss_group_name, dsid_doctor_id) VALUES('duty_administrators', (SELECT r_object_id FROM ddt_doctor WHERE dss_last_name = 'Юрьев' AND dss_first_name = 'Алексей' AND dss_middle_name = 'Александрович'));