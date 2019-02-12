CREATE TABLE ddt_consilium_group (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_name VARCHAR(1024) NOT NULL UNIQUE
);

CREATE TRIGGER ddt_consilium_group_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_consilium_group FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE TABLE ddt_consilium_group_member (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_group VARCHAR(16) NOT NULL REFERENCES ddt_consilium_group(r_object_id) ON DELETE CASCADE,
  dss_name VARCHAR(1024),
  dsid_doctor VARCHAR(16) NOT NULL REFERENCES ddt_doctor(r_object_id) ON DELETE CASCADE,
  UNIQUE(dsid_group, dsid_doctor)
);

CREATE TRIGGER ddt_consilium_group_member_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_consilium_group_member FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE TABLE ddt_consilium_group_level (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  dsid_group VARCHAR(16) NOT NULL REFERENCES ddt_consilium_group(r_object_id) ON DELETE CASCADE,
  dsi_level int
);