using System;

namespace Cardiology.Model
{
    public class DdtPatientAnalysis
    {
        public const string TABLE_NAME = "ddt_patient_analysis";
        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dsis_urine_analysis")]
        private string dsisUrineAnalysis;
        [TableAttribute("dsis_uzi")]
        private string dsisUzi;
        [TableAttribute("dsid_holter")]
        private string dsidHolter;
        [TableAttribute("dsid_specialist_conclusion")]
        private string dsidSpecialistConclusion;
        [TableAttribute("dsid_xray")]
        private string dsidXray;
        [TableAttribute("dsid_egds")]
        private string dsidEgds;

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
    }
}
