CREATE TABLE ddt_doctor_order
(
    r_object_id        varchar(16) PRIMARY KEY DEFAULT GetNextId(),
    dss_name           varchar(64) NOT NULL,
    dsid_group_user_id varchar(16) NOT NULL REFERENCES dm_group_users (r_object_id) ON DELETE CASCADE ON UPDATE CASCADE,
    dsi_value          INT         NOT NULL,

    UNIQUE (dss_name, dsid_group_user_id)
);