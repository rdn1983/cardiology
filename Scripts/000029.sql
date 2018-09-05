CREATE TABLE dm_group_users(
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_group_name varchar (64) REFERENCES dm_group (dss_name) ON DELETE CASCADE ON UPDATE CASCADE,
  dss_user_name varchar (100) REFERENCES ddt_doctors (dss_login) ON DELETE CASCADE ON UPDATE CASCADE,
  UNIQUE (dss_group_name, dss_user_name)
);

CREATE TRIGGER dm_group_users_trg_modify_date BEFORE INSERT OR UPDATE
  ON dm_group_users FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('io_cardio_reanim', 'koshkinaEV');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('io_therapy', 'arefievAA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('io_rhmdil', 'samochatovDN');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_cardioreanim', 'generalOlga');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_rhdmil', 'samochatovDN');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'arefievAA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'gorbunovAL');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'gorjachevVI');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'dodicaAN');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'zinuhovAF');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'alekperovSF');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'ivanovAE');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'ivanovGI');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'kazambaevEA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'kiselDYU');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'klimenkoAA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'konevDE');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'kostilevGN');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'kostiryaYUE');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'loskutnikovMA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'magomedovHR');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'martinovPA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'peikerAN');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'rezepovNA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'relinVE');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'semenovAYU');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'semchenkoVI');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'sobolevVV');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'shandalinVA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'shirshovIA');
INSERT INTO dm_group_users (dss_group_name, dss_user_name) VALUES('duty_admin', 'yurievAA');
