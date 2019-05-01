INSERT INTO ddt_cure_type (dss_name) VALUES ('Антикоагулянты');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Неврологические');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Антибиотики');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Стенты');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Антиагреганты');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Гастропротекторы');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Мочегонные');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Гипотензивные');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Антиоритмики и b-блокеры');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Транки');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Гормоны');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Против подагры');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Железо');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Инсулины');
INSERT INTO ddt_cure_type (dss_name) VALUES ('ХОБЛ');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Кабивен');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Кислород');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Стол');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Обезболивающие');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Седативная терапия');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Лечение шока');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Статины');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Инфузионная терапия');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Антиаритмическая терапия (внутривенная)');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Лечение гипертонического криза');
INSERT INTO ddt_cure_type (dss_name) VALUES ('Кровоостанавливающая терапия');


INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Integrilini со ск 6,6 мл/час ч/з инфузомат', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антикоагулянты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Heparini 5000ED x 4 р/сутки п/к', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антикоагулянты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Anfibra 0,4ml х 2р/сутки п/к', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антикоагулянты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Сlexani 0,4ml х 2р/сутки п/к', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антикоагулянты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Сlexani 0,8ml х 2р/сутки п/к', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антикоагулянты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Arixtri 2,5 mg х 1р/сутки п/к', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антикоагулянты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Enixumi 0,8ml х 2р/сутки п/к', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антикоагулянты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Fraxiparini 0,3ml х 2р/сутки п/к', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антикоагулянты'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ceraxoni 2,0 в/в стр в 10:00 и 12:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Неврологические'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Cerepro 250 мг в/в, стр  утром', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Неврологические'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Церепро: Sol. NaCl 0,9% - 500,0 + Sol. Choline alfoscerate 400mg в/в кап х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Неврологические'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Мексидол: Sol. NaCl 0,9% - 250,0+ Sol. Aethylmethylhydroxypyridini succinas 4мл х2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Неврологические'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Cerebrolysini10,0 + Sol. NaCl 0,9% - 250,0 х 1р/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Неврологические'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Глиацер: Sol.Gleaceri 250,0 +Sol. NaCL 0,9% 500,0 в/в кап  х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Неврологические'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Amikacini 1g в/в стр в 12:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Amoxiclavi 1фл +Sol. NaCl 0,9% - 100,0 в/в кап х 3р/сут', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ampicillini+Sulbactami 1,5g х 3р/сутки в/в 6:00 – 14:00 – 22:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Broadsef – C 1,5 х 2р/сутки в/в кап 11:00 и 23:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Cefepini 1g х 2р/сутки в/в кап.', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ceftriaxoni 2g  (Lendacini) в/в, стр в 12:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Cefuroximi 1,5g + Sol. NaCl 0,9% - 200,0 за 1,5 часа в/в кап х 3р/сутки ', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Cefazolini 1g х 3р/сутки в/в 6:00 – 14:00 – 22:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Cefoperazoni + Sol. Sulbactami 3,0 х 2р/сутки в/в кап 11:00 и 23:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ceftasidini 2g в/в, стр в 12:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ciprofloxacini 200 mg х 2р/сутки в/в кап 11:00 и 23:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Cubicini 500mg х1р/сутки в/в кап.', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Gentamicini 4% – 160mg + Sol. NaCl 0,9% - 250,0 за 1,5 часа в/в кап ', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Invanz 1g в/в кап в 11:00 в течение часа', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Fluconazoli 0,2% – 100ml  х 2р/сутки в/в кап 10:00 – 22:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Leflobacti (Levofloxacini) 5mg/ml – 100,0 х 2р/сутки 11:00 и 23:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Meropenemi 1 гр х 2р/сутки в/в, стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Metrogyli 100,0 х 2р/сутки в/в кап 11:00 и 23:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol.Metronidazoli 0,5% - 100ml х 3р/сутки в в/в кап 6:00 – 14:00 – 22:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ofloxacini 200mg х 2р/сутки в/в кап 11:00 и 23:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Sulmoveri 2/3/4g х 2р/сутки в/в стр в 11:00 и 23:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Sultasini 1,5g х 3р/сутки в/в стр 6:00 – 14:00 – 22:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Sulmografi 3 г х 2р/сутки в/в 10-22', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Vancomycini 1g  в/в стр в 12:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антибиотики'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Multi-Link  3,5х12мм (без лекарственного покрытия).', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Integrity BMS 3,0х15мм (без лекарственного покрытия).', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Angioline Calipso 2,75 х 23мм (без лекарственного покрытия).', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Driver Sprint 4,5x18 мм (без лекарственного покрытия).', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Vision 3,5х18 мм (без лекарственного покрытия).  ', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Калипсо 2,75 х 18мм (с лекарственным покрытием).', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Biomime 3,0x29 мм (с лекарственным покрытием).', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Xience Xpedition 2,75x18 мм (с лекарственным покрытием).', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Resolute Integrity 3,5х12 мм (с лекарственным покрытием).', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('стент Nexgen 2,75 х 37мм ', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стенты'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Aspirini 125mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Brilintae 90mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Clopidogreli 300mg/однократно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Clopidogreli 75 mg/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Co-plavixi 75/100 mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Eliquisi 2,5/5mg x 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Plagrili 75mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Pradaxa 150/110mg x 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Syncumar 6 mg х 1р/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab.Warfarini 2,5mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Xarelti 20mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Clopidogreli 75mg х 1р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиагреганты'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Pantoprazole 20mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гастропротекторы'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Omeprazoli 20mg/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гастропротекторы'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Quamateli 20mg х 2 р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гастропротекторы'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Almagel по 1-3 ч.л. х 3-4 р/сутки за 30 мин до еды', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гастропротекторы'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Domperidoni (Motiliumi) 10mg х 3-4р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гастропротекторы'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Verospironi 100mg х 1р/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Spironolactoni 50mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Spironolactoni 25mg/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Spironolactoni 50mg/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Diuveri 5mg х 1р/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab.Trigrimi 5/10mg х 1р/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Furosemidi 40 mg/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Furosemidi 40 mg в/в стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol Furosemidi 20 mg в/в стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Indapi 2,5mg х 1р/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Hydrochlorothiazidi 25mg х 1р/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Мочегонные'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Capoteni 25 mg х однократно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Enapi 2,5mg вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Enapi 5mg x 2 р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Amlodipini 5mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Nifedipini 30mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Verapamili 40mg/80mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Diltiazemi 90mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Enalaprili 5mg х 2 р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Enalaprili 20mg х 2 р/сут', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Losartani 50mg х 2 р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Doxazosini 2mg х 2р/сутки (макс 16мг/сутки)', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Moxonidini 0,2/0,4mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Moxonidini 0,2mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Molsidomini 0,2мг  х 2р/сут (Сиднофарм)', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Sildenafili 25mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гипотензивные'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Digoxini 0,125mg (1/2таб) х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Atenololi 50mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Bravadini 7,5 mg 2 р/сут', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Metoprololi 25mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Metoprololi 12,5mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Lokreni 5/40 mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Bisoprololi 5mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Nebivololi 2,5mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Dilarendi 6,25mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Sotalexi 40mg х 2 р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Propanormi 150mg х3р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Allapinini 25mg х 2 р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Cordaroni 400mg х 1 р/д вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Ivabradini (Coraxani) 5mg/7,5 mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Carvediloli 6,25 mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Ethacyzini 50 mg х 3р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Propafenoni 150mg х 4таб (600мг) х однократно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиоритмики и b-блокеры'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Phenazepamum 1mg н/ночь', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Транки'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Phenibuti 250 mg х 3р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Транки'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Prednizoloni 20 mg/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гормоны'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Dexamethasoni 4mg + Sol. NaCl 0,9% - 500,0 в/в кап медленно ', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гормоны'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. L-thyroxini 100mkg  утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гормоны'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Thyrozoli (Thiamazoli) 5/10mg х 2р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Гормоны'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Allopurinoli 100mg х 1 р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Против подагры'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Sorbiferi 1таб х 3р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Железо'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ferric (III) hydroxide polymaltosate 20mg/ml – 5,0ml х 1р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Железо'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Actropidi 16Ед х 3р/сутки п/з, п/о, п/у.', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инсулины'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Protafani 18Ед х 2р/сутки в 09:00 и 21:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инсулины'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Biosulini R 4 Ed  перед едой', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инсулины'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Biosulini H 9:00-6Ed 21-4Ed', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инсулины'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab.Glucophage 500mg/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инсулины'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Beroduali 1ml (20 кап) х 3р/сутки через небулайзер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'ХОБЛ'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Fluimucili 3,0 мл в/в,стр утром', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'ХОБЛ'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ambrobene 4мл х 3р/сутки', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'ХОБЛ'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Atroventi 0,25мг/мл х 20кап через небулайзер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'ХОБЛ'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Atroventi 1,0 мл через небулайзер в 14-22-6ч', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'ХОБЛ'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Euphyllini 2,4% - 1,0 ml х 20кап через небулайзер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'ХОБЛ'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol.Nutriflexi 1500  в/вено капельно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кабивен'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Em. Smofkabiveni 1920 в/вено капельно (периферический)', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кабивен'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Инсуфляция увлажнённым кислородом.', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кислород'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Стол ОВД', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стол'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Стол НКД', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Стол'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Nitrogliserini 1% - 20,0 ml со v 2 мл/час', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Обезболивающие'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Propofoli 10mg/ml – 50,0 ml со v 5мл/час', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Седативная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ketoroli 30mg – 1,0 х однократно в/в стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Седативная терапия'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Dopamini 200мг + Sol. NaCl 0,9%– 500ml  V = 60 мл/ч', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение шока'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Noradrenalini 2mg/ml + NaCl 0,9%– 50ml  V = 4-8 мл/ч', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение шока'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Dofamini 10mg/ml – 5,0 + Sol. NaCl 0,9%– 50ml V = 2 мл/ч', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение шока'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Adenosintriphosphate sodium 1,0 ml (макс 3,0мл) в/в стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение шока'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Sterofundini 400,0 х 2раз в/в кап, медленно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение шока'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Atorvastatini  40mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Статины'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Atorvastatini  80mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Статины'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab Atorvastatini 20 mg/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Статины'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Rosuvastatin 40mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Статины'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Rosuvastatin 20mg х 1р/вечер', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Статины'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCl 0,9% - 500,0 в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCl 0,9% - 500,0 х 3р/сут в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCl 0,9% - 500,0 в/в кап + MgSo4 20,0', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Sterofundini 500,0 х 3раз в/в кап, медленно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Rheopolyglukini 10% - 400,0 х 2р/сутки в/в капельно медленно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol.Voluveni 6% - 500,0 х 1раз в/в кап, медленно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCL 0,9% 500 мл х2 раза ск 100 мл/ч, через эскадроп', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCl  0,9% - 250,0 + Prednizoloni 60 мг/утро', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCl 200,0 + Sol. Euphуllini 20,0 мл  в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Инфузионная терапия'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCL 0,9% - 400,0 + Sol. Cordaroni 450 mg в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиаритмическая терапия (внутривенная)'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCL 250,0 0,9 % + Mexidoli 5,0 х 1 раза в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиаритмическая терапия (внутривенная)'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCl 0,9% - 200,0 + Sol. Asparcami 20,0 в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиаритмическая терапия (внутривенная)'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCl 0,9% - 250 мл + Sol. Asparkami 20 + Sol. Digoхini 1,0 мл в/в кап, v 150 мл/ч.', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиаритмическая терапия (внутривенная)'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Glucosi 5% - 200,0 + Sol. KCl 4% - 60,0 + Sol. MgSO4 25% - 20,0 в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиаритмическая терапия (внутривенная)'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Glucosi 5% - 200,0 + Sol. Novocaini 0,5% - 50,0 х 1р/сутки в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиаритмическая терапия (внутривенная)'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Coradroni 600mg х 1 в/в стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиаритмическая терапия (внутривенная)'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Digoxini 0,025% - 1,0/2,0 в/в, стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Антиаритмическая терапия (внутривенная)'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Enapi 1,25 мкг х 1р/сутки в/в стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение гипертонического криза'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Furosemidi 20 mg в/в стр, после инфузии', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение гипертонического криза'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Lazixi 40mg в/в стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение гипертонического криза'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. NaCl 0,9%, - 250,0 + Sol. MgSO4 25% - 20,0 в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение гипертонического криза'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Metoprololi 1мг/кг - 5,0 в/в, стр', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Лечение гипертонического криза'));

INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Dicinoni 2,0ml х 3 р/д в/в', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кровоостанавливающая терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Tranexamic acid 1g (Traksara) х 3р/сутки в/в кап медленно', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кровоостанавливающая терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Ac.Aminocapronici 100ml х 2 р\д в\в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кровоостанавливающая терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. B12 1000 mcg/ml х 1р/сутки в/м в 12:00', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кровоостанавливающая терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Tab. Folic Acidi 1g х 2р/сутки (фоливая к-та)', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кровоостанавливающая терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Metoclopramidi (Cerucali) 2,0 х 3р/сутки в/в стр (Церукал)', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кровоостанавливающая терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Heptor 400 мг в/в кап', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кровоостанавливающая терапия'));
INSERT INTO ddt_cure (dss_name, dsid_cure_type) VALUES ('Sol. Drotaverini 2,0 ml в/в', (SELECT r_object_id FROM ddt_cure_type WHERE dss_name = 'Кровоостанавливающая терапия'));