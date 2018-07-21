
CREATE TABLE ddt_various_spec_concluson (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_parent VARCHAR(16),
  dss_parent_type VARCHAR(128),
  
  dsdt_admission_date timestamp,
  dss_specialist_type VARCHAR(256),
  dss_specialist_conclusion VARCHAR(2048),
  dss_additional_info0 VARCHAR(1024),
  dss_additional_info1 VARCHAR(1024),
  dss_additional_info2 VARCHAR(1024),
  dss_additional_info3 VARCHAR(1024),
  dss_additional_info4 VARCHAR(1024),
  dsb_visible BOOLEAN default true,
  dsb_additional_bool BOOLEAN default false
);

CREATE TRIGGER ddt_various_spec_concluson BEFORE INSERT OR UPDATE
  ON ddt_various_spec_concluson FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

