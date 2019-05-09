CREATE TABLE ddt_relation
(
    r_object_id     varchar(16) PRIMARY KEY DEFAULT GetNextId(),
    dsid_parent     varchar(16) NOT NULL,
    dsid_child		varchar(16) NOT NULL,
    dss_child_type  varchar(64) NOT NULL
);