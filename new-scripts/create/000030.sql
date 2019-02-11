CREATE TABLE dm_group_users(
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dss_group_name varchar (64) REFERENCES dm_group (dss_name) ON DELETE CASCADE ON UPDATE CASCADE,
  dsid_doctor_id varchar (100) REFERENCES ddt_doctor (r_object_id) ON DELETE CASCADE ON UPDATE CASCADE,
  UNIQUE (dss_group_name, dss_user_name)
);

CREATE TRIGGER dm_group_users_trg_modify_date BEFORE INSERT OR UPDATE
  ON dm_group_users FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();