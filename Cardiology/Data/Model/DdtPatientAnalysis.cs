using System;

namespace Cardiology.Data.Model
{
    public class DdtPatientAnalysis
    {
        public const string TABLE_NAME = "ddt_patient_analysis";
        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dsis_urine_analysis")]
        private string dsisUrineAnalysis;
        [Table("dsis_uzi")]
        private string dsisUzi;
        [Table("dsid_holter")]
        private string dsidHolter;
        [Table("dsid_specialist_conclusion")]
        private string dsidSpecialistConclusion;
        [Table("dsid_xray")]
        private string dsidXray;
        [Table("dsid_egds")]
        private string dsidEgds;
        [Table("dsid_kag")]
        private string dsidKag;
        [Table("dsid_ekg")]
        private string dsidEkg;

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

        public string DsidSpecialistConclusion { get => dsidSpecialistConclusion; set => dsidSpecialistConclusion = value; }
        public string DsidHolter { get => dsidHolter; set => dsidHolter = value; }
        public string DsisUzi { get => dsisUzi; set => dsisUzi = value; }
        public string DsisUrineAnalysis { get => dsisUrineAnalysis; set => dsisUrineAnalysis = value; }
        public string DsidXray { get => dsidXray; set => dsidXray = value; }
        public string DsidEgds { get => dsidEgds; set => dsidEgds = value; }
        public string DsidKag { get => dsidKag; set => dsidKag = value; }
        public string DsidEkg { get => dsidEkg; set => dsidEkg = value; }
    }
}
