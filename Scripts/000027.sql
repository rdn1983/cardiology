CREATE TABLE ddt_alco_protocol (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dss_look VARCHAR(128),
  dss_cause VARCHAR(128),
  dss_behavior VARCHAR(128),
  dss_orientation VARCHAR(128),
  dss_speech VARCHAR(128),
  dss_skin VARCHAR(128),
  dss_breathe VARCHAR(128),
  dss_pulse VARCHAR(128),
  dss_pressure VARCHAR(128),
  dss_eyes VARCHAR(128),
  dss_nistagm VARCHAR(128),
  dss_motions VARCHAR(128),
  dss_mimics VARCHAR(128),
  dss_walk VARCHAR(128),
  dss_touch_nose VARCHAR(128),
  dss_tremble VARCHAR(128),
  dss_illness VARCHAR(128),
  dss_drunk VARCHAR(128),
  dss_smell VARCHAR(128),
  dss_pribor VARCHAR(128),
  dss_trub VARCHAR(128),
  dss_bio VARCHAR(128),
  dss_docs VARCHAR(128),
  dss_conclusion VARCHAR(200),
  dsb_template boolean
);

CREATE TRIGGER ddt_alco_protocol BEFORE INSERT OR UPDATE
  ON ddt_alco_protocol FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();
