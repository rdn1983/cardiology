CREATE TABLE ddt_cure (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_name VARCHAR(100) NOT NULL UNIQUE,
  dsi_type int
);

CREATE TRIGGER ddt_cure BEFORE INSERT OR UPDATE
  ON ddt_cure FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Integrilini со ск 6,6 мл/час ч/з инфузомат', 0);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Heparini 5000ED x 4 р/сутки п/к', 0);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Anfibra 0,4ml х 2р/сутки п/к', 0);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Сlexani 0,4ml х 2р/сутки п/к', 0);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Arixtri 2,5 mg х 1р/сутки п/к', 0);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Enixumi 0,8ml х 2р/сутки п/к', 0);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Fraxiparini 0,3ml х 2р/сутки п/к', 0);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Ceraxoni 2,0 в/в стр в 10:00 и 12:00', 1);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Cerepro 250 мг в/в, стр утром', 1);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Церепро: Sol. NaCl 0,9% - 500,0 + Sol. Choline alfoscerate 400mg в/в кап х 2р/сутки', 1);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Мексидол: Sol. NaCl 0,9% - 250,0+ Sol. Aethylmethylhydroxypyridini succinas 4мл х2р/сутки', 1);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Cerebrolysini10,0 + Sol. NaCl 0,9% - 250,0 х 1р/утро', 1);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Amikacini 1g в/в стр в 12:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Amoxiclavi 1фл +Sol. NaCl 0,9% - 100,0 в/в кап х 3р/сут', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Ampicillini+Sulbactami 1,5g х 3р/сутки в/в 6:00 – 14:00 – 22:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Broadsef – C 1,5 х 2р/сутки в/в кап 11:00 и 23:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Cefepini 1g х 2р/сутки в/в кап.', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Ceftriaxoni 2g  (Lendacini) в/в, стр в 12:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Cefuroximi 1,5g + Sol. NaCl 0,9% - 200,0 за 1,5 часа в/в кап х 3р/сутки ', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Cefazolini 1g х 3р/сутки в/в 6:00 – 14:00 – 22:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Cefoperazoni + Sol. Sulbactami 3,0 х 2р/сутки в/в кап 11:00 и 23:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Ceftasidini 2g в/в, стр в 12:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Ciprofloxacini 200 mg х 2р/сутки в/в кап 11:00 и 23:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Cubicini 500mg х1р/сутки в/в кап.', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Gentamicini 4% – 160mg + Sol. NaCl 0,9% - 250,0 за 1,5 часа в/в кап ', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Invanz 1g в/в кап в 11:00 в течение часа', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Fluconazoli 0,2% – 100ml  х 2р/сутки в/в кап 10:00 – 22:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Leflobacti (Levofloxacini) 5mg/ml – 100,0 х 2р/сутки 11:00 и 23:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Meropenemi 1 гр х 2р/сутки в/в, стр', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Metrogyli 100,0 х 2р/сутки в/в кап 11:00 и 23:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol.Metronidazoli 0,5% - 100ml х 3р/сутки в в/в кап 6:00 – 14:00 – 22:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Ofloxacini 200mg х 2р/сутки в/в кап 11:00 и 23:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Sulmoveri 2/3/4g х 2р/сутки в/в стр в 11:00 и 23:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Sultasini 1,5g х 3р/сутки в/в стр 6:00 – 14:00 – 22:00', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Sulmografi 3 г х 2р/сутки в/в 10-22', 2);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Vancomycini 1g  в/в стр в 12:00', 2);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Multi-Link  3,5х12мм (без лекарственного покрытия).', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Integrity BMS 3,0х15мм (без лекарственного покрытия).', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Angioline Calipso 2,75 х 23мм (без лекарственного покрытия).', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Driver Sprint 4,5x18 мм (без лекарственного покрытия).', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Vision 3,5х18 мм (без лекарственного покрытия).  ', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Калипсо 2,75 х 18мм (с лекарственным покрытием).', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Biomime 3,0x29 мм (с лекарственным покрытием).', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Xience Xpedition 2,75x18 мм (с лекарственным покрытием).', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Resolute Integrity 3,5х12 мм (с лекарственным покрытием).', 3);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('стент Nexgen 2,75 х 37мм ', 3);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Atorvastatini  40mg х 1р/вечер', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Aspirini 125mg х 1р/вечер', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Brilintae 90mg х 2р/сутки', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Clopidogreli 300mg/однократно', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Co-plavixi 75/100 mg х 1р/вечер', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Eliquisi 2,5/5mg x 2р/сутки', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Plagrili 75mg х 1р/вечер', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Pradaxa 150/110mg x 2р/сутки', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Syncumar 6 mg х 1р/утро', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab.Warfarini 2,5mg х 1р/вечер', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Xarelti 20mg х 1р/вечер', 4);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Zilti 75mg х 1р/сутки', 4);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Nolpaza 20mg х 1р/вечер', 5);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Omeprazoli 20mg/вечер', 5);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Quamateli 20mg х 2 р/сутки', 5);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Almagel по 1-3 ч.л. х 3-4 р/сутки за 30 мин до еды', 5);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Domperidoni (Motiliumi) 10mg х 3-4р/сутки', 5);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Verospironi 100mg х 1р/утро', 6);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Spironolactoni 50mg х 2р/сутки', 6);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Diuveri 5mg х 1р/утро', 6);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab.Trigrimi 5/10mg х 1р/утро', 6);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Furosemidi 40 mg/утро', 6);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Indapi 2,5mg х 1р/утро', 6);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Hydrochlorothiazidi 25mg х 1р/утро', 6);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Capoteni 25 mg х однократно', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Amlodipini 5mg х 2р/сутки', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Nifedipini 30mg х 2р/сутки', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Verapamili 40mg/80mg х 2р/сутки', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Diltiazemi 90mg х 2р/сутки', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Enalaprili 5mg х 2 р/сутки', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Losartani 50mg х 2 р/сутки', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Doxazosini 2mg х 2р/сутки (макс 16мг/сутки)', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Moxonidini 0,2/0,4mg х 2р/сутки (Физиотенз)', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Molsidomini 0,2мг  х 2р/сут (Сиднофарм)', 7);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Sildenafili 25mg х 2р/сутки', 7);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Digoxini 0,125mg (1/2таб) х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Atenololi 50mg х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. (Betaloc ZOK) Metoprololi 25mg х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Lokreni 5/40 mg х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Bisoprololi 5mg х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Nebivololi 2,5mg х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Dilarendi 6,25mg х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Sotalexi 40mg х 2 р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Propanormi 150mg х3р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Allapinini 25mg х 2 р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Cordaroni 400mg х 1 р/д вечер', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Ivabradini (Coraxani) 5mg/7,5 mg х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Carvediloli 6,25 mg х 2р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Ethacyzini 50 mg х 3р/сутки', 8);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Propafenoni 150mg х 4таб (600мг) х однократно', 8);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Phenazepamum 1mg н/ночь', 9);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Phenibuti 250 mg х 3р/сутки', 9);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Prednizoloni 20 mg/утро', 10);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Dexamethasoni 4mg + Sol. NaCl 0,9% - 500,0 в/в кап медленно ', 10);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. L-thyroxini 100mkg  утро', 10);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Thyrozoli (Thiamazoli) 5/10mg х 2р/сутки', 10);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Allopurinoli 100mg х 1 р/сутки', 11);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab. Sorbiferi 1таб х 2р/сутки', 12);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Ferric (III) hydroxide polymaltosate 20mg/ml – 5,0ml х 1р/сутки', 12);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Actropidi 16Ед х 3р/сутки п/з, п/о, п/у.', 13);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Protafani 18Ед х 2р/сутки в 09:00 и 21:00', 13);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Biosulini R 4 Ed  перед едой', 13);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Biosulini H 9:00-6Ed 21-4Ed', 13);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Tab.Glucophage 500mg/вечер', 13);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Beroduali 1ml (20 кап) х 3р/сутки через небулайзер', 14);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Fluimucili 3,0 мл в/в,стр утром', 14);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Ambrobene 4мл х 3р/сутки', 14);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Atroventi 0,25мг/мл х 20кап через небулайзер', 14);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol. Euphyllini 2,4% - 1,0 ml х 20кап через небулайзер', 14);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Sol.Nutriflexi 1500  в/вено капельно', 15);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Em. Smofkabiveni 1920 в/вено капельно (периферический)', 15);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Инсуфляция увлажнённым кислородом.', 16);

INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Стол ОВД', 17);
INSERT INTO ddt_cure (dss_name, dsi_type) VALUES ('Стол НКД', 17);
