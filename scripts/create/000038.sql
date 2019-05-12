CREATE TABLE ddt_transfusion (
  r_object_id varchar(16) PRIMARY KEY DEFAULT GetNextId(),
  r_creation_date TIMESTAMP DEFAULT NOW() NOT NULL,
  r_modify_date TIMESTAMP NOT NULL,

  dsid_hospitality_session VARCHAR(16) REFERENCES ddt_hospital(r_object_id),
  dsid_patient VARCHAR(16) REFERENCES ddt_patient(r_object_id),
  dsid_doctor VARCHAR(16) REFERENCES ddt_doctor(r_object_id),
  dsdt_transfusion_date timestamp,
  dss_transfusion_medium VARCHAR(64),
  dsid_consilium VARCHAR(16) REFERENCES ddt_consilium(r_object_id),
  dsid_blood_analysis VARCHAR(16) REFERENCES ddt_blood_analysis(r_object_id),
  dss_consent VARCHAR(16)
);

CREATE TRIGGER ddt_transfusion_trg_modify_date BEFORE INSERT OR UPDATE
  ON ddt_transfusion FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_modify_date();

CREATE FUNCTION dmtrg_f_ddt_transfusion_audit()
  returns trigger
language plpgsql
as $BODY$
BEGIN
  INSERT INTO ddt_history
      (dsid_hospitality_session, dsid_patient, dsid_doctor, dsid_operation_id, dss_operation_type, dsdt_operation_date, dss_operation_name)
  VALUES (NEW.dsid_hospitality_session, NEW.dsid_patient, NEW.dsid_doctor, NEW.r_object_id, TG_TABLE_NAME, new.dsdt_transfusion_date, 'Переливание крови');
  RETURN NEW;
END;
$BODY$;


CREATE TRIGGER ddt_transfusion_trg_audit AFTER INSERT
  ON ddt_transfusion FOR EACH ROW
EXECUTE PROCEDURE dmtrg_f_ddt_transfusion_audit();

CREATE TABLE ddt_relation
(
    r_object_id     varchar(16) PRIMARY KEY DEFAULT GetNextId(),
    dsid_parent     varchar(16) NOT NULL,
    dsid_child		varchar(16) NOT NULL,
    dss_child_type  varchar(64) NOT NULL
);