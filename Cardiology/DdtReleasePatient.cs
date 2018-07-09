using System;

namespace Cardiology.Model
{
    public class DdtReleasePatient
    {
        public const string TABLE_NAME = "ddt_release_patient";

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
        [TableAttribute("dsdt_okr_release_date")]
        private DateTime dsdtOkrReleaseDate;
        [TableAttribute("dsb_is_working")]
        private bool dsbIsWorking;
        [TableAttribute("dsb_dismissed_less30d")]
        private bool dsbDicmissedLess30D;
        [TableAttribute("dss_profession")]
        private string dssProfession;
        [TableAttribute("dss_occupational_hazard")]
        private string dssOccupationalHazard;
        [TableAttribute("dsb_pensioneer")]
        private bool dsbPensioneer;
        [TableAttribute("dss_disability_num")]
        private string dssDisabilityNum;
        [TableAttribute("dss_year_disabilities")]
        private string dssYearDisabilities;
        [TableAttribute("dsb_sicklist_need")]
        private bool dsbSicklistNeed;
        [TableAttribute("dsb_extr_opened_sicklist")]
        private bool dsbExtrOpenedSicklist;
        [TableAttribute("dss_extr_sicklist_num")]
        private string dssExtrSixklistNum;
        [TableAttribute("dsdt_extr_startdate")]
        private DateTime dsdtExtrStartDate;
        [TableAttribute("dsdt_extr_enddate")]
        private DateTime dsdtExtrEndDate;
        [TableAttribute("dss_our_sicklist_num")]
        private string dssOurSicklistNum;
        [TableAttribute("dsdt_our_startdate")]
        private DateTime dsdtOurStartDate;
        [TableAttribute("dsdt_our_enddate")]
        private DateTime dsdtOurEndDate;


        public string ObjectId
        {
            get { return rObjectId; }
        }

        public DateTime RCreationDate
        {
            get { return rCreationDate; }
        }

        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public DateTime DsdtOkrReleaseDate { get => dsdtOkrReleaseDate; set => dsdtOkrReleaseDate = value; }
        public bool DsbIsWorking { get => dsbIsWorking; set => dsbIsWorking = value; }
        public bool DsbDicmissedLess30D { get => dsbDicmissedLess30D; set => dsbDicmissedLess30D = value; }
        public string DssProfession { get => dssProfession; set => dssProfession = value; }
        public string DssOccupationalHazard { get => dssOccupationalHazard; set => dssOccupationalHazard = value; }
        public bool DsbPensioneer { get => dsbPensioneer; set => dsbPensioneer = value; }
        public string DssDisabilityNum { get => dssDisabilityNum; set => dssDisabilityNum = value; }
        public string DssYearDisabilities { get => dssYearDisabilities; set => dssYearDisabilities = value; }
        public bool DsbSicklistNeed { get => dsbSicklistNeed; set => dsbSicklistNeed = value; }
        public bool DsbExtrOpenedSicklist { get => dsbExtrOpenedSicklist; set => dsbExtrOpenedSicklist = value; }
        public string DssExtrSixklistNum { get => dssExtrSixklistNum; set => dssExtrSixklistNum = value; }
        public DateTime DsdtExtrStartDate { get => dsdtExtrStartDate; set => dsdtExtrStartDate = value; }
        public DateTime DsdtExtrEndDate { get => dsdtExtrEndDate; set => dsdtExtrEndDate = value; }
        public string DssOurSicklistNum { get => dssOurSicklistNum; set => dssOurSicklistNum = value; }
        public DateTime DsdtOurStartDate { get => dsdtOurStartDate; set => dsdtOurStartDate = value; }
        public DateTime DsdtOurEndDate { get => dsdtOurEndDate; set => dsdtOurEndDate = value; }
    }
}
