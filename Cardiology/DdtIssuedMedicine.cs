using System;

namespace Cardiology.Model
{
    public class DdtIssuedMedicine
    {
        public const string TABLE_NAME = "ddt_issued_medicine";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_cure")]
        private string dsidCure;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_parent_id")]
        private string dsidParentId;
        [TableAttribute("dss_parent_type")]
        private string dssParentType;


        public string ObjectId
        {
            get { return rObjectId; }
        }
        public string DsidCure
        {
            get { return dsidCure; }
            set { this.dsidCure = value; }

        }
        public string DsidDoctor
        {
            get { return dsidDoctor; }
            set { this.dsidDoctor = value; }

        }
        public string DsidPatient
        {
            get { return dsidPatient; }
            set { this.dsidPatient = value; }

        }
        public string DsidHospitalitySession
        {
            get { return dsidHospitalitySession; }
            set { this.dsidHospitalitySession = value; }

        }
        public DateTime CreationDate
        {
            get { return rCreationDate; }
            set {; }
        }

        public string DsidParentId { get => dsidParentId; set => dsidParentId = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
    }
}
