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