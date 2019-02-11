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