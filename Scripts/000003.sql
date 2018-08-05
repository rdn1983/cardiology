CREATE TABLE ddt_values (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_name VARCHAR(100) NOT NULL UNIQUE,
  dss_value VARCHAR(1024)
);

CREATE TRIGGER ddt_values_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_values FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.lastname', 'Борисов');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.name', 'Эраст');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.secondname', 'Петрович');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.birthday', '08.01.1954');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.receipttime', '18.03.2018 10:00:00');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.oksup', 'на общую слабость');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.oksdown', 'на общую слабость');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.kag', 'на общую слабость');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.aorta', 'на общую слабость');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.gb', 'на общую слабость');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.piks', 'на одышку, на общую слабость');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.pikvik', 'На момент осмотра беспокоит общая слабость, одышка при умерненной физической нагрузке, увеличение живота в объеме, отеки нижних конечностей');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.dep', 'не предъявляет по тяжести состояния');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('complaintsTxt.death', 'не предъявляет по тяжести состояния');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.oksup', 'Длительно страдает артериальной гипертензией. Регулярно артериальное давление не контролирует. Терапию не принимает.  Привычным считает АД 120/80 мм.рт.ст. Со слов больного, ранее ангинозные приступы никогда не беспокоили, толерантность к физической нагрузке была удовлетворительная.Сегодня стали беспокоить боли в области сердца давящего, жгучего характера с иррадиацией между лопаток, длительностью  15 минут. Вызвал бригаду СМП. Госпитализирован в ГКБ №67.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.oksdown', 'Ранее повышения АД не отмечал , адаптирован 120/80 мм рт ст. . Перенесенный ОИМ отрицает. Препараты регулярно  не принимает.    Ухудшение состояния в течение нескольких дней, появились давящие боли за грудиной, сегодня боль в грудной клетке повторилась, обратился в СМП, доставлен в ГКБ 67, госпитализирован в  ОКР.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.kag', 'Длительно страдает гипертонической болезнью с повышением АД 180/100 мм рт ст, адаптирован к АД130/80мм рт ст. Со слов пациента амбулаторно обследовался в связи с жалобами на снижение толерантности к физической нагрузке. По результатам обследований рекомендовано КАГ в плановом порядке. Регулярно принимает гипотензивную, диуретическую, дезагрегантную терапию. Ухудшение состояния сегодня, на фоне подъёма артериального давления до АД 190/100 мм рт ст, самостоятельно принимал гипотензивную с нестойким положительным эффектом. Самостоятельно обратился в ОКР, госпитализирован.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.aorta', 'В течение нескольких месяцев отмечал повышение АД до 140/80 мм рт ст, адаптирован 120/80 мм рт ст. Считает себя больным  в течении последних нескольких дней, когда  появились боли за грудиной, в грудном отделе позвоночника, в животе. Обратился в СМП, доставлен в ГКБ 67, госпитализирован в ОКР.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.gb', 'Пациент читает себя больным в течение нескольких лет, когда стал отмечать повышение АД до 180/120 мм рт ст. Адаптирован к АД 130/80мм рт ст. Перенесенный  ОИМ отрицает. В настоящее время препараты не принимает. Сегодня на фоне повышения АД до 180/100, отметил дискомфорт в области сердца, слабость, вызвал бригаду СМП. Госпитализирован в ГКБ №67.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.piks', 'Считает себя больным в течении нескольких лет, когда отметил повышение АД до 180/100 мм рт ст. Адаптирован к АД120/80мм рт ст. Перенес ОИМ. Выполнялась КАГ. выявлено многососудистое поражение, ангиопластика и стентирование.  Персистирующая форма фибрилляции предсердий. Неоднократно госпитализировался в стационары в связи с декомпенсацией недостаточности кровообращения. После выписки принимал рекомендованные препараты. Ухудшение состояния в течение последних нескольких дней, вновь наросла одышка,  обратился в СМП,  госпитализирован в ОКР.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.pikvik', 'Ранее сердечно-сосудистые заболевания миокарда не переносил. Артериальное давление не контролирует, медикаментозную терапию не принимает. Диагностирована фибрилляция предсердий, постоянная форма.  Последние месяцы отмечает отеки нижних конечностей, цианоз. Ухудшение состояния последние две недели - отмечает увеличение живота в объеме, нарастание отеков ног, одышку при минимальной физической нагрузке. Последние три дня одышка стала нарастать. В  связи с усилением одышки в покое, вызвал бригаду СМП доставлен в ОКР ГКБ№67, госпитализирован.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.dep', '(по имеющейся медицинской документации): Страдает гипертонической болезнью, ИБС, нарушениями ритма и проводимости. Длительное время не встает с кровати, неоднократно была госпитализирована в отделения полиативной помощи. Ухудшение состояния  , когда больная стала не контактной в связи, с чем доставлена и госпитализирована в ГКБ №67. В нарастающими явлениями сердечной недостаточности больная переведена в ОКР.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisMorbiTxt.death', 'Больной контакту не доступен из-за тяжести состояния. Доставлен в состоянии клинической смерти.  Анамнез собран по данным мед документации. Длительное время отмечает повышение артериального давления. Инфаркт миокарда не переносил. Ухудшение состояния внезапно, когда у больного стала нарастать одышка, потерял сознание, возникла остановка и дыхания и кровообращения. Родственники вызвали СМП. Доставлен в отделение ОКР минуя приёмное отделение.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.oksup', 'Со слов пациента, ранее наркотических средств не применяла. Бригадой СМП вводился морфин 1,0 на догоспитальном этапе.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.oksdown', 'Со слов пациента, ранее  наркотических средств  не применял.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.kag', 'Со слов пациента, ранее наркотические средства не применялись.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.aorta', 'Сведений о приеме наркотических препаратов ранее нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.gb', 'Со слов пациента, ранее наркотические средства не применялись.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.piks', 'Со слов пациента, ранее наркотических средств не применяла. Бригадой СМП вводился морфин 1,0 на догоспитальном этапе.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.pikvik', 'Со слов пациента, ранее наркотических средств не применяла.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.dep', 'нет данных.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.death', 'нет данных.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.oksup', 'Состояние тяжелое. Пациент в сознании, повышенного питания, продуктивному контакту доступен, на вопросы отвечает, ориентирован во времени и пространстве, память не снижена. Положение активное. T тела 36.5С. Кожные покровы и видимые слизистые физиологической окраски, умеренной влажности, варикозное расширение вен нижних конечностей, периферические отеки - пастозность стоп. Телосложение правильное, нормостеническое. Опорно-двигательный аппарат - без особенностей. Лимфатические узлы не увеличены.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.oksdown', 'Состояние средней степени тяжести. Кожные покровы смуглые, физиологической окраски, кожа теплая, умеренной влажности, целостность  кожи не нарушена, живот не увеличен, пастозность голеней и стоп. Телосложение правильное, нормостеническое. Опорно-двигательный аппарат – без особенностей. Щитовидная железа –  без особенностей. Лимфатические узлы не увеличены.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.kag', 'Состояние тяжелое. Пациент в сознании, повышенного питания, продуктивному контакту доступен, на вопросы отвечает, ориентирован во времени и пространстве, память не снижена. Положение активное. T тела 36.5С. Кожные покровы и видимые слизистые физиологической окраски, умеренной влажности, варикозное расширение вен нижних конечностей, периферические отеки - пастозность стоп. Телосложение правильное, нормостеническое. Опорно-двигательный аппарат - без особенностей. Лимфатические узлы не увеличены.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.aorta', 'Общее состояние тяжелое. Положение – активное. Кожные покровы: бледные,  умеренной влажности. T 36,7. Трофических изменений кожи нет. Нормастенического телосложения. Лимфатические узлы не пальпируются. Щитовидная железа не увеличена. Периферические отеки- нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.gb', 'Общее состояние средней тяжести. Положение – активное. Кожные покровы: бледно-розовые, умеренной влажности. T 36,7. Трофических изменений кожи нет. Нормастенического телосложения. Лимфатические узлы не пальпируются. Щитовидная железа не увеличена. Периферические отеки - отсутствуют.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.piks', 'Состояние тяжёлое. В сознании, доступен продуктивному контакту. Положение вынужденное. T тела 36.5С. Кожные покровы и видимые слизистые физиологической окраски, кожа теплая, умеренной влажности, целостность кожи не нарушена, периферические отеки - пастозность стоп. Телосложение правильное. При пальпации грудная клетка безболезненна. Опорно-двигательный аппарат - без особенностей. Лимфатические узлы не увеличены.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.pikvik', 'Состояние тяжелое. Положение – пассивное. Кожные покровы: бледные влажные. T 36,7. Гиперстенического телосложения. Лимфатические узлы не пальпируются. Щитовидная железа не увеличена. Периферические отеки: отеки ног.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.dep', 'Состояние тяжелое. Контакту не доступна. t° тела 36,7°С. Положение – с возвышенным головным концом. Питание нормостеническое. Кожные покровы бледно-розовой окраски, сухие, сыпи нет. Контрактуры нижних конечностей. Пастозность нижних конечностей.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('stPresensTxt.death', 'Состояние  крайне тяжёлое. Уровень сознания кома. Положение лежа с низким изголовьем. T тела 36.5?С. Кожные покровы и видимые слизистые бледные, акроцианоз, умеренной влажности, целостность кожи не нарушена. Варикозное расширение вен нижних конечностей, периферические отеки – нет. Телосложение правильное, нормостеническое.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.oksup', 'Грудная клетка правильной формы, нормостеническая. ЧД 17 в минуту. Ход ребер обычный, межреберные промежутки не расширены. Перкуторно: границы лёгких не изменены, лёгочный звук с 2-х сторон. Аускультативно – дыхание жесткое с 2-х сторон, хрипов нет. Голосовое дрожание одинаковое на симметричных участках грудной клетки.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.oksdown', 'Грудная клетка правильной формы,  нормостеническая. ЧД 17 в минуту. Ход ребер обычный, межреберные промежутки не расширены. Перкуторно: границы лёгких не изменены, лёгочный звук с 2-х сторон. Аускультативно – дыхание везикулярное с жестким оттенком с 2-х сторон, хрипов нет. Голосовое дрожание одинаковое на симметричных участках грудной клетки. ');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.kag', 'Грудная клетка правильной формы. Перкуторно звук легочный. Границы легких в норме. Голосовое дрожание проводится симметрично. Над легкими аускультативно: дыхание жесткое, ослабленное в нижних отделах. ЧД 18 в мин.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.aorta', 'Грудная клетка правильной формы. Перкуторно звук легочный. Границы легких в норме. Голосовое дрожание проводится симметрично. Над легкими аускультативно: дыхание жесткое, ослабленное в нижних отделах. ЧД 18 в мин.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.gb', 'Грудная клетка правильной формы. Перкуторно звук легочный. Границы легких в норме. Голосовое дрожание проводится симметрично. Над легкими аускультативно: дыхание жесткое, хрипов нет . ЧД 18 в мин.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.piks', 'Грудная клетка правильной формы, нормостеническая. ЧД 19 в минуту. Ход ребер обычный, межреберные промежутки не расширены. Перкуторно: границы лёгких не изменены, лёгочный звук с 2-х сторон. Аускультативно – дыхание жесткое, ослаблено в н/о с 2-х сторон, хрипов нет. Голосовое дрожание одинаковое на симметричных участках грудной клетки.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.pikvik', 'Грудная клетка правильной формы, нормостеническая. ЧД 21 в минуту. Ход ребер обычный, межреберные промежутки не расширены. Перкуторно: границы лёгких не изменены, лёгочный звук с 2-х сторон. Аускультативно – При аускультации легких жесткое дыхание, единичные сухие хрипы.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.dep', 'Грудная клетка правильной формы, нормостеническая. ЧД 24 в минуту. При аускультации легких выслушивается сухие свистящие хрипы с обеих сторон, ослабленное дыхание в нижних отделах от середины лопатки.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('respiratorySystemTxt.death', 'Грудная клетка правильной формы, нормостеническая. ЧД 24 в минуту. При аускультации легких выслушивается сухие свистящие хрипы с обеих сторон, ослабленное дыхание в нижних отделах от середины лопатки.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.oksup', 'Область сердца не изменена. Верхушечный толчок кнутри от средне-ключичной линии, не визуализируются. Границы относительной тупости сердца – увеличены на 0,5 см кнаружи вверх и влево от левой среднеключичной линии. АД 100/60 мм рт.ст, ЧСС–PS–59, ритм правильный, удовлетворительного наполнения и напряжения.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.oksdown', 'Область сердца не изменена. Верхушечный толчок кнутри от средне-ключичной линии, не визуализируется.  Границы относительной тупости сердца – увеличены на 0,5 см кнаружи вверх и влево. Шумы - не высл. АД 140/80 мм рт.ст, ЧСС-PS–68, ритм правильный, удовлетворительного наполнения и напряжения.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.kag', 'Область сердца без особенностей. Верхушечный толчок пальпируется в V межреберье. Границы относительной тупости сердца: верхняя - III межреберье, правая - по правому краю грудины, левая - 3 см кнаружи от левой среднеключичной линии. Тоны сердца приглушены, ритмичные. ЧСС 77 в мин. PS 77 в мин. удовлетворительного наполнения, симметричный на обеих руках АД  170/100 мм рт ст.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.aorta', 'Область сердца без особенностей. Верхушечный толчок пальпируется в V межреберье. Границы относительной тупости сердца: верхняя – III межреберье, правая – по правому краю грудины, левая – 3 см кнаружи от левой среднеключичной линии. Тоны сердца приглушены, ритмичные. ЧСС 123 в мин. PS 120  в мин. удовлетворительного наполнения, симметричный на обеих руках АД  150/80 мм рт ст.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.gb', 'Область сердца без особенностей. Верхушечный толчок пальпируется в V межреберье. Границы относительной тупости сердца: верхняя – III межреберье, правая – по правому краю грудины, левая – 3 см кнаружи от левой среднеключичной линии. Тоны сердца приглушены, ритмичные. ЧСС 77 в мин. PS 77 в мин. удовлетворительного наполнения, симметричный на обеих руках АД  140/80 мм рт ст.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.piks', 'Область сердца не изменена. Верхушечный толчок кнутри от средне-ключичной линии, не визуализируются. Границы относительной тупости сердца – увеличены на 0,5 см кнаружи вверх и влево от левой среднеключичной линии. АД 140/90 мм рт.ст, ЧСС–PS–51, ритм правильный, удовлетворительного наполнения и напряжения.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.pikvik', 'Границы относительной тупости сердца расширены вправо и влево – по левой среднеключичной линии; правая – по правому краю грудины, верхняя – на уровне III ребра. При аускультации сердца: тоны сердца глухие, ритмичные, шумов нет. АД 150/110 мм.рт.ст.; ЧСС-84 уд в мин. Пульс- 84 в мин.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.dep', 'Область сердца не изменена. Границы относительной тупости сердца – по левой среднеключичной линии; правая – по правому краю грудины, верхняя – на уровне III ребра. При аускультации сердца: тоны сердца глухие, ритмичные, шумов нет. АД-165/100 мм.рт.ст.; ЧСС-88 уд в мин. Пульс- 88 в мин.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('cardiovascularSystemTxt.death', 'Область сердца не изменена. АД 80/40 мм рт.ст, ЧСС–PS–30, ритм неправильный.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nervousSystemTxt.oksdown', 'Пациент в сознании, продуктивному  контакту доступен, на вопросы отвечает, ориентирована во времени и пространстве. Менингеальных знаков нет. Зрачки D=S. Сухожильные рефлексы симметричны. Очаговой неврологической патологии нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nervousSystemTxt.kag', 'Сознание ясное. Контактен, ориентирована в месте, времени, личности. Менингеальных знаков нет. Зрачки D=S. Сухожильные рефлексы симметричны. Очаговой неврологической патологии нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nervousSystemTxt.aorta', 'Сознание ясное. Контактен, ориентирован в месте, времени, личности. Менингеальных знаков нет. Зрачки D=S. Сухожильные рефлексы симметричны. Очаговой неврологической патологии нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nervousSystemTxt.gb', 'Сознание ясное. Контактен, ориентирована в месте, времени, личности. Менингеальных знаков нет. Зрачки D=S. Сухожильные рефлексы симметричны. Очаговой неврологической патологии нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nervousSystemTxt.piks', 'Уровень сознания – ясное, продуктивному контакту доступна, менингиальные симптомы не выявляются, очаговой неврологической симптоматики нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nervousSystemTxt.pikvik', 'Уровень сознания – ясное, продуктивному контакту доступен. Менингеальных симптомов нет. Очаговой неврологической симптоматики нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nervousSystemTxt.dep', 'Общая мышечная ригидность. Менингеальных симптомов нет.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nervousSystemTxt.death', 'Уровень сознания – кома.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.oksup', 'ИБС: Острый коронарный синдром с подъемом сегмента ST.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.oksdown', 'ИБС: Острый коронарный синдром без подъёма сегмента ST.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.kag', 'Гипертоническая болезнь II стадия, риск 3. Гипертонический криз от . ИБС: стенокардия напряжения 2 -3 ФК. HII.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.aorta', 'Гипертоническая болезнь II стадия, риск 4. HII. Расслоение аорты , гемоперикард, персистирующая форма мерцательной аритмии.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.gb', 'Гипертоническая болезнь II стадия, риск 3. Гипертонический криз от ');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.piks', 'ИБС: Постинфарктный кардиосклероз. Н2Б.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.pikvik', 'Синдром Пиквика. Хроническое легочное сердце в стадии декомпенсации. Анасарка.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.dep', 'ДЭП последствие перенесённых ОНМК со стойким неврологическим дефицитом.        ИБС: атеросклеротический кардиосклероз. Нарушения ритма и проводимости: Гипертоническая болезнь III ст, риск 4. Гипертонический криз от ');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('diagnosisTxt.death', 'ИБС. Многососудистое поражение коронарных артерий. Пароксизмальная форма мерцательной аритмии. Узловой ритм. НК2Б. Гипертоническая болезнь III ст, риск высокий.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.oksup', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.oksdown', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.kag', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.aorta', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.gb', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.piks', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.pikvik', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.dep', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisEpidTxt.death', 'За последние 6 месяцев из Москвы не выезжал, в контакт с инфекционными больными, больными с ОРВИ не вступал');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.oksup', 'не отягощен');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.oksdown', 'не отягощен');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.kag', 'не отягощен');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.aorta', 'не отягощен');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.gb', 'не отягощен');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.piks', 'не отягощен');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.pikvik', 'не отягощен');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.dep', 'не отягощен');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisAllergyTxt.death', 'не отягощен');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('accompanyingIllnessesTxt.ma', 'Мерцательная аритмия. Пароксизмальная/Персистирующая форма.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('accompanyingIllnessesTxt.gb', 'Гипертоническая болезнь IIIст., риск 4.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('accompanyingIllnessesTxt.dep', 'ДЭП 3ст., последствия перенесенного ОНМК, субкомпенсация.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('accompanyingIllnessesTxt.sd', 'Сахарный диабет 2 типа, среднетяжелого течения, субкомпенсация.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('accompanyingIllnessesTxt.hobl', 'ХОБЛ, хронический бронхит.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.no', 'Со слов пациента, ранее наркотических средств не применял.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('drugsTxt.yes', 'Со слов пациента, ранее наркотических средств не применяла. Бригадой СМП вводился морфин 1,0 на догоспитальном этапе.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisVitaeTxt.no', 'Наследственность не отягощена. Профессиональных вредностей не было, не курит, прием алкоголя отрицает.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('anamnesisVitaeTxt.yes', 'Наследственность не отягощена. Профессиональных вредностей не было, не курит. Запах алкоголя изо рта.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('justificationTxt.tela', 'Учитывая диагноз, сопутствующую патологию, пациенту показана антикоагулянтная, антибактерилаьная, диуретическая, ритмоурежеющая, гастропротективная терапия. настоящая терапия обоснована и соответствует стандартам лечения ТЭЛА, инфарктной пневмонии.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('justificationTxt.nk', 'Учитывая диагноз, сопутствующую патологию, пациенту показана антикоагулянтная, диуретическая, ритмоурежеющая, гастропротективная терапия. настоящая терапия обоснована и соответствует стандартам лечения недостаточности кровообращения. ');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('justificationTxt.oksSt', 'В связи  изменениями на ЭКГ, пациенту по жизненным показаниями решено провести КАГ с попыткой реваскуляризации миокарда.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('justificationTxt.oks', 'ST Учитывая отсутствие значимых изменений на ЭКГ, отсутствие нарушений гемодинамики пациенту возможно провести КАГ с попыткой реваскуляризации миокарда после получения клинического и биохимического анализа крови.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('justificationTxt.gb', 'С учетом анамнеза, данных осмотра пациенту показана гипотензивная, мочегонная, ритм-коррегирующая терапия');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('justificationTxt.pma', 'С учетом известной давности начала настоящего нарушения ритма пациенту показано восстановление ритма с последующей терапии антикоагулянтами.');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('justificationTxt.ibs', 'С учетом анамнеза, данных осмотра пациенту необходимо исключить ИБС.');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('bloodtype.o', 'O(I)');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('bloodtype.a', 'A(II)');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('bloodtype.b', 'B(III)');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('bloodtype.ab', 'AB(IV)');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('rhesusFactor.plus', 'положительный');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('rhesusFactor.minus', 'отрицательный');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kellAg.plus', 'положительный');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kellAg.minus', 'отрицательный');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('serology.minus', 'отрицательный');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('serology.plus', 'положительный');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('serology.inwork', 'в работе');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.0', 'Tab. Clopidogreli 300mg/однократно');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.1', 'Tab. Atorvastatini  80mg однократно');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.2', 'Sol. Nitrogliserini 1% - 20,0 ml со v 2 мл/час');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.3', 'Sol. NaCl 0,9% - 500,0 в/в кап');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.4', 'Sol. Сlexani 0,8ml х 2р/сутки п/к');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.5', 'Tab. Metoprololi 25mg х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.6', 'Tab. Enalaprili 5mg х 2 р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.7', 'Tab. Spironolactoni 25mg/утро');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.8', 'Tab. Omeprazoli 20mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.9', 'Tab. Atorvastatini  40mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.10', 'Tab. Clopidogreli 75 mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oks.medicine.11', 'Tab. Aspirini 125mg х 1р/вечер');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.0', 'Sol. NaCl 0,9% - 500,0 х 3р/сут в/в кап');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.1', 'Sol. Furosemidi 40 mg в/в стр');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.2', 'Tab. Metoprololi 25mg х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.3', 'Tab. Enalaprili 5mg х 2 р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.4', 'Tab. Spironolactoni 25mg/утро');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.5', 'Tab. Clopidogreli 75 mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.6', 'Tab. Aspirini 125mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.7', 'Tab. Atorvastatini  40mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.8', 'Tab. Omeprazoli 20mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('okslongs.medicine.9', 'Sol. Сlexani 0,8ml х 2р/сутки п/к');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.0', 'Sol. NaCl 0,9% - 500,0 в/в кап');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.1', 'Sol Furosemidi 20 mg в/в стр');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.2', 'Tab. Enapi 2,5mg вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.3', 'Tab. Bravadini 7,5 mg 2 р/сут');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.4', 'Tab. Omeprazoli 20mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.5', 'Tab Atorvastatini 20 mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.6', 'Tab. Spironolactoni 25mg/утро');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.7', 'Sol. Сlexani 0,8ml х 2р/сутки п/к');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('hobl.medicine.8', 'Sol. Atroventi 1,0 мл через небулайзер в 14-22-6ч');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.0', 'Sol. Nitrogliserini 1% - 20,0 ml со v 2 мл/час');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.1', 'Sol. Furosemidi 40 mg в/в стр');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.2', 'Sol. Сlexani 0,4ml х 2р/сутки п/к');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.3', 'Tab. Metoprololi 12,5mg х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.4', 'Tab. Spironolactoni 50mg/утро');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.5', 'Tab Atorvastatini 20 mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.6', 'Tab. Omeprazoli 20mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.7', 'Tab. Aspirini 125mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.8', 'Tab. Enalaprili 5mg х 2 р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('nk.medicine.9', 'Tab. Digoxini 0,125mg (1/2таб) х 2р/сутки');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('gb.medicine.0', 'Tab. Capoteni 25 mg х однократно');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('gb.medicine.1', 'Sol. NaCl 0,9% - 500,0 в/в кап + MgSo4 20,0');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('gb.medicine.2', 'Sol. Furosemidi 40 mg в/в стр');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('gb.medicine.3', 'Tab. Enalaprili 20mg х 2 р/сут');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('gb.medicine.4', 'Tab. Amlodipini 5mg х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('gb.medicine.5', 'Tab. Moxonidini 0,2mg х 2р/сутки');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksup.medicine.0', 'Sol. Nitrogliserini 1% - 20,0 ml со v 2 мл/час');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksup.medicine.1', 'Tab. Clopidogreli 300mg/однократно');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksup.medicine.2', 'Tab. Atorvastatini  80mg однократно');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksup.medicine.3', 'Tab. Aspirini 125mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksup.medicine.4', 'Tab. Omeprazoli 20mg/вечер');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksdown.medicine.0', 'Стол ОВД');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksdown.medicine.1', 'Sol. NaCl 0,9% - 500,0 х 3р/сут в/в кап');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksdown.medicine.2', 'Tab. Metoprololi 25mg х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksdown.medicine.3', 'Tab. Enapi 5mg x 2 р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksdown.medicine.4', 'Tab. Clopidogreli 75 mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksdown.medicine.5', 'Tab Atorvastatini 20 mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('oksdown.medicine.6', 'Tab. Omeprazoli 20mg/вечер');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.0', 'Стол ОВД');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.1', 'Sol. NaCl 0,9% - 500,0 в/в кап + MgSo4 20,0');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.2', 'Sol Furosemidi 20 mg в/в стр');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.3', 'Tab. Enalaprili 5mg х 2 р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.4', 'Tab. Metoprololi 25mg х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.5', 'Tab. Omeprazoli 20mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.6', 'Tab. Spironolactoni 25mg/утро');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.7', 'Tab. Aspirini 125mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.8', 'Tab. Clopidogreli 75 mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('kag.medicine.9', 'Tab. Atorvastatini  40mg х 1р/вечер');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.0', 'Стол ОВД');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.1', 'Sol. Nitrogliserini 1% - 20,0 ml со v 2 мл/час');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.2', 'Sol Enapi 1,25 в/в стр однократно');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.3', 'Tab Atorvastatini 20 mg/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.4', 'Tab. Enapi 5mg x 2 р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.5', 'Tab. Metoprololi 25mg х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.6', 'Sol Acidi Aminocapronici 200,0в/в кап');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.7', 'Tab. Metoprololi 25mg х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('aorta.medicine.8', 'Sol. Dicinoni 2,0ml х 3 р/д в/в');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('piks.medicine.0', 'Стол ОВД');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('piks.medicine.1', 'Tab. Aspirini 125mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('piks.medicine.2', 'Tab. Plagrili 75mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('piks.medicine.3', 'Tab. Atorvastatini  80mg однократно');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('piks.medicine.4', 'Tab. Pantoprazole 20mg х 1р/вечер');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('pikvik.medicine.0', 'Стол ОВД');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('pikvik.medicine.3', 'Tab. Aspirini 125mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('pikvik.medicine.1', 'Tab. Atorvastatini  80mg однократно');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('pikvik.medicine.4', 'Tab. Pantoprazole 20mg х 1р/вечер');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.0', 'Стол ОВД');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.1', 'Церепро: Sol. NaCl 0,9% - 500,0 + Sol. Choline alfoscerate 400mg в/в кап х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.2', 'Sol. NaCL 250,0 0,9 % + Mexidoli 5,0 х 1 раза в/в кап');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.3', 'Sol. NaCl 0,9% - 500,0 в/в кап + MgSo4 20,0');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.4', 'Sol. Lazixi 40mg в/в стр');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.5', 'Sol. Enixumi 0,8ml х 2р/сутки п/к');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.6', 'Tab. Pantoprazole 20mg х 1р/вечер');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.7', 'Tab. Verospironi 100mg х 1р/утро');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('dep.medicine.8', 'Tab. Aspirini 125mg х 1р/вечер');

INSERT INTO ddt_values (dss_name, dss_value) VALUES ('death.medicine.0', 'Sol. Furosemidi 40 mg в/в стр');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('death.medicine.2', 'Sol. Leflobacti (Levofloxacini) 5mg/ml – 100,0 х 2р/сутки 11:00 и 23:00');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('death.medicine.3', 'Tab. Verospironi 100mg х 1р/утро');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('death.medicine.4', 'Tab. Sorbiferi 1таб х 2р/сутки');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('death.medicine.5', 'Sol. Dofamini 10mg/ml – 5,0 + Sol. NaCl 0,9%– 50ml V = 2 мл/ч');
