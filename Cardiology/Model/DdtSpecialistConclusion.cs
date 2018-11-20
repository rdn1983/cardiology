using System;

namespace Cardiology.Model
{
    public class DdtSpecialistConclusion : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_specialist_conclusion";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsid_patient")]
        private string dsidPatient;
        [TableAttribute("dsid_doctor")]
        private string dsidDoctor;
        [TableAttribute("dss_neurolog")]
        private string dssNeurolog;
        [TableAttribute("dss_surgeon")]
        private string dssSurgeon;
        [TableAttribute("dss_neuro_surgeon")]
        private string dssNeuroSurgeon;
        [TableAttribute("dss_endocrinologist")]
        private string dssEndocrinologist;
        [TableAttribute("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [TableAttribute("dsid_parent")]
        private string dsidParent;
        [TableAttribute("dss_parent_type")]
        private string dssParentType;

        public string ObjectId
        {
            get { return rObjectId; }
        }

        public DateTime RCreationDate
        {
            get { return rCreationDate; }
        }

        public string DsidHospitalitySession
        {
            get { return dsidHospitalitySession; }
            set { this.dsidHospitalitySession = value; }
        }

        public string DsidPatient
        {
            get { return dsidPatient; }
            set { this.dsidPatient = value; }
        }

        public string DsidDoctor
        {
            get { return dsidDoctor; }
            set { this.dsidDoctor = value; }
        }

        public string DssNeurolog { get => dssNeurolog; set => dssNeurolog = value; }
        public string DssSurgeon { get => dssSurgeon; set => dssSurgeon = value; }
        public string DssNeuroSurgeon { get => dssNeuroSurgeon; set => dssNeuroSurgeon = value; }
        public string DssEndocrinologist { get => dssEndocrinologist; set => dssEndocrinologist = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
    }
}
