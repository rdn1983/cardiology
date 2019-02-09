CREATE TABLE ddt_doctors (
  r_object_id          varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date      TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date        TIMESTAMP               NOT NULL,

  dss_login            VARCHAR(100)            NOT NULL UNIQUE,
  dss_full_name        VARCHAR(256),
  dss_initials         VARCHAR(256),
  dss_appointment_name VARCHAR(128),
  dss_phone            VARCHAR(15),
  dsi_appointment_type int
);

CREATE TRIGGER ddt_doctors_trg_modify_date
  BEFORE INSERT OR UPDATE
  ON ddt_doctors
  FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('generalOlga', 'Генералова Ольга Александровна', 'Генералова О.А.', 'Дежурный кардиореаниматолог', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES
  ('arslanbekovaSM', 'Арсланбенкова Серминаз Махмудовна', 'Арсланбенкова С.М.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('goryachevaEV', 'Горячева Елена Владимировна', 'Горячева Е.В.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('koshkinaEV', 'Кошкина Екатерина Виленовна', 'Кошкина Е.В.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('bespalovaYUE', 'Беспалова Юлия Эдуардовна', 'Беспалова Ю.Э.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('mironovaEA', 'Миронова Елена Александровна', 'Миронова Е.А.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('doctorovaMV', 'Докторова Марина Викторовна', 'Докторова М.В.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('balhanovaAYU', 'Балханова Анна Юрьевна', 'Балханова А.Ю.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('bagramovaYUA', 'Баграмова Юлия Анатольевна', 'Баграмова Ю.А.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('shcherbakovaSV', 'Щербакова Светлана Владимировна', 'Щербакова С.В.', 'Сотрудник отделения ОКР', '0-0-0', 0);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('kustovaTYU', 'Кустова Татьяна Юрьевна', 'Кустова Т.Ю.', 'Сотрудник отделения ОКР', '0-0-0', 0);

INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('samochatovDN', 'Самочатов Денис Николаевич', 'Самочатов Д.Н.', 'Ангиохирург', '0-0-0', 1);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('komkovAA', 'Комков Артем Андреевич', 'Комков А.А.', 'Ангиохирург', '0-0-0', 1);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('milenkinBI', 'Миленькин Борис Игоревич', 'Миленькин Б.И.', 'Ангиохирург', '0-0-0', 1);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('potehinDA', 'Потехин Дмитрий Александрович', 'Потехин Д.А.', 'Ангиохирург', '0-0-0', 1);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('mostovoyIV', 'Мостовой Игорь Владимирович', 'Мостовой И.В.', 'Ангиохирург', '0-0-0', 1);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('shestovDV', 'Шестов Денис Васильевич', 'Шестов Д.В.', 'Ангиохирург', '0-0-0', 1);

INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('mitrohinSD', 'Митрохин С. Д.', 'Митрохин С. Д.', 'Клинфармаколог', '0-0-0', 2);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('otpushennikovaMV', 'Отпущенникова М. В.', 'Отпущенникова М. В.', 'Клинфармаколог', '0-0-0', 2);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('galickiyAA', 'Галицкий А. А.', 'Галицкий А. А.', 'Клинфармаколог', '0-0-0', 2);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('gosteevaIV', 'Гостеева И. В.', 'Гостеева И. В.', 'Клинфармаколог', '0-0-0', 2);

INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('arefievAA', 'Арефьев А.А.', 'Арефьев А.А.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('gorbunovAL', 'Горбунов А.Л.', 'Горбунов А.Л.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('gorjachevVI', 'Горячев В.И.', 'Горячев В.И.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('dodicaAN', 'Додица А.Н.', 'Додица А.Н.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('zinuhovAF', 'Зинухов А.Ф.', 'Зинухов А.Ф.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('alekperovSF', 'Алекперов С.Ф.', 'Алекперов С.Ф.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('ivanovAE', 'Иванов А.Э.', 'Иванов А.Э.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('ivanovGI', 'Иванов Г.И.', 'Иванов Г.И.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('kazambaevEA', 'Казамбаев Е.А.', 'Казамбаев Е.А.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('kiselDYU', 'Кисель Д.Ю.', 'Кисель Д.Ю.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('klimenkoAA', 'Клименко А.А.', 'Клименко А.А.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('konevDE', 'Конев Д.Е.', 'Конев Д.Е.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('kostilevGN', 'Костылев Г.Н.', 'Костылев Г.Н.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('kostiryaYUE', 'Костыря Ю.Е.', 'Костыря Ю.Е.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('loskutnikovMA', 'Лоскутников М.А.', 'Лоскутников М.А.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('magomedovHR', 'Магомедов Х.Р.', 'Магомедов Х.Р.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('martinovPA', 'Мартынов П.А.', 'Мартынов П.А.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('peikerAN', 'Пейкер А.Н.', 'Пейкер А.Н.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('rezepovNA', 'Резепов Н.А.', 'Резепов Н.А.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('relinVE', 'Релин В.Е.', 'Релин В.Е.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('semenovAYU', 'Семенов А.Ю.', 'Семенов А.Ю.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('semchenkoVI', 'Семченко В.И.', 'Семченко В.И.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('sobolevVV', 'Соболев В.В.', 'Соболев В.В.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('shandalinVA', 'Шандалин В.А.', 'Шандалин В.А.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('shirshovIA', 'Ширшов И.А.', 'Ширшов И.А.', 'Дежурный адинистратор', '0-0-0', 3);
INSERT INTO ddt_doctors (dss_login, dss_full_name, dss_initials, dss_appointment_name, dss_phone, dsi_appointment_type)
VALUES ('yurievAA', 'Юрьев А.А.', 'Юрьев А.А.', 'Дежурный адинистратор', '0-0-0', 3);