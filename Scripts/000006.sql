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