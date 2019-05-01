CREATE TABLE ddt_cure_type (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_name VARCHAR(100) NOT NULL UNIQUE
);

CREATE TRIGGER ddt_cure_type_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_cure_type FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE TABLE ddt_cure (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_name VARCHAR(350) NOT NULL UNIQUE,
  dsid_cure_type varchar(16) NOT NULL REFERENCES ddt_cure_type (r_object_id)
);

CREATE TRIGGER ddt_cure_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_cure FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();