CREATE TABLE dm_group(
        r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
        r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
        r_modify_date TIMESTAMP NOT NULL,

	dss_name varchar(64) UNIQUE NOT NULL,
	dss_description varchar(1024)
);

CREATE TRIGGER dm_group_trg_modify_date BEFORE INSERT OR UPDATE
    ON dm_group FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

INSERT INTO dm_group (dss_name, dss_description) VALUES ('io_cardio_reanim', 'Заведующая отделения кардиореанимации');
INSERT INTO dm_group (dss_name, dss_description) VALUES ('io_therapy', 'Зам. главного врача по терапии');
INSERT INTO dm_group (dss_name, dss_description) VALUES ('io_rhmdil', 'Зав. отделения РХМДиЛ');
INSERT INTO dm_group (dss_name, dss_description) VALUES ('duty_cardioreanim', 'Дежурный кардиореаниматолог');
INSERT INTO dm_group (dss_name, dss_description) VALUES ('duty_rhdmil', 'Дежурный врач отделения РХМДиЛ');
INSERT INTO dm_group (dss_name, dss_description) VALUES ('duty_admin', 'Дежурный администратор');


