CREATE TABLE ddt_consilium_member_level (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  dss_group_name VARCHAR(64) REFERENCES dm_group(dss_name),
  dsi_level int
);

INSERT INTO ddt_consilium_member_level (dss_group_name, dsi_level) VALUES ('io_cardio_reanim', 10);
INSERT INTO ddt_consilium_member_level (dss_group_name, dsi_level) VALUES ('io_therapy', 20);
INSERT INTO ddt_consilium_member_level (dss_group_name, dsi_level) VALUES ('io_rhmdil', 30);
INSERT INTO ddt_consilium_member_level (dss_group_name, dsi_level) VALUES ('duty_cardioreanim', 40);
INSERT INTO ddt_consilium_member_level (dss_group_name, dsi_level) VALUES ('duty_rhdmil', 50);
INSERT INTO ddt_consilium_member_level (dss_group_name, dsi_level) VALUES ('duty_admin', 60);