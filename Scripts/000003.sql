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
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.secondname', 'Петрович')
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.birthday', '08.01.1954');
INSERT INTO ddt_values (dss_name, dss_value) VALUES ('default.patient.receipttime', '18.03.2018 10:00:00');