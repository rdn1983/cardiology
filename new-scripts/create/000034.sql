CREATE TABLE ddt_consilium_member_level (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  dss_group_name VARCHAR(64) REFERENCES dm_group(dss_name),
  dsi_level int
);