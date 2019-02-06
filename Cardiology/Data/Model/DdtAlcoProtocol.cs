using Cardiology.Commons;
using System;

namespace Cardiology.Data
{
    public class DdtAlcoProtocol
    {
        public const string TABLE_NAME = "ddt_alco_protocol";

        [TableAttribute("r_object_id", false)]
        private string rObjectId;
        [TableAttribute("r_creation_date", false)]
        private DateTime rCreationDate;
        [TableAttribute("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [TableAttribute("dss_look")]
        private string dssLook;
        [TableAttribute("dss_behavior")]
        private string dssBehavior;
        [TableAttribute("dss_orientation")]
        private string dssOrientation;
        [TableAttribute("dss_speech")]
        private string dssSpeech;
        [TableAttribute("dss_skin")]
        private string dssSkin;
        [TableAttribute("dss_breathe")]
        private string dssBreathe;
        [TableAttribute("dss_pulse")]
        private string dssPulse;
        [TableAttribute("dss_pressure")]
        private string dssPressure;
        [TableAttribute("dss_eyes")]
        private string dssEyes;
        [TableAttribute("dss_nistagm")]
        private string dssNistagm;
        [TableAttribute("dss_motions")]
        private string dssMotions;
        [TableAttribute("dss_mimics")]
        private string dssMimics;
        [TableAttribute("dss_walk")]
        private string dssWalk;
        [TableAttribute("dss_touch_nose")]
        private string dssTouchNose;
        [TableAttribute("dss_tremble")]
        private string dssTremble;
        [TableAttribute("dss_illness")]
        private string dssIllness;
        [TableAttribute("dss_drunk")]
        private string dssDrunk;
        [TableAttribute("dss_smell")]
        private string dssSmell;
        [TableAttribute("dss_pribor")]
        private string dssPribor;
        [TableAttribute("dss_trub")]
        private string dssTrub;
        [TableAttribute("dss_bio")]
        private string dssBio;
        [TableAttribute("dss_docs")]
        private string dssDocs;
        [TableAttribute("dss_conclusion")]
        private string dssConclusion;
        [TableAttribute("dss_cause")]
        private string dssCause;
        [TableAttribute("dsb_template")]
        private bool dsbTemplate;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DssLook { get => dssLook; set => dssLook = value; }
        public string DssBehavior { get => dssBehavior; set => dssBehavior = value; }
        public string DssOrientation { get => dssOrientation; set => dssOrientation = value; }
        public string DssSpeech { get => dssSpeech; set => dssSpeech = value; }
        public string DssSkin { get => dssSkin; set => dssSkin = value; }
        public string DssBreathe { get => dssBreathe; set => dssBreathe = value; }
        public string DssPulse { get => dssPulse; set => dssPulse = value; }
        public string DssPressure { get => dssPressure; set => dssPressure = value; }
        public string DssEyes { get => dssEyes; set => dssEyes = value; }
        public string DssNistagm { get => dssNistagm; set => dssNistagm = value; }
        public string DssMotions { get => dssMotions; set => dssMotions = value; }
        public string DssMimics { get => dssMimics; set => dssMimics = value; }
        public string DssWalk { get => dssWalk; set => dssWalk = value; }
        public string DssTouchNose { get => dssTouchNose; set => dssTouchNose = value; }
        public string DssTremble { get => dssTremble; set => dssTremble = value; }
        public string DssIllness { get => dssIllness; set => dssIllness = value; }
        public string DssDrunk { get => dssDrunk; set => dssDrunk = value; }
        public string DssSmell { get => dssSmell; set => dssSmell = value; }
        public string DssPribor { get => dssPribor; set => dssPribor = value; }
        public string DssTrub { get => dssTrub; set => dssTrub = value; }
        public string DssBio { get => dssBio; set => dssBio = value; }
        public string DssDocs { get => dssDocs; set => dssDocs = value; }
        public string DssConclusion { get => dssConclusion; set => dssConclusion = value; }
        public bool DsbTemplate { get => dsbTemplate; set => dsbTemplate = value; }
        public string DssCause { get => dssCause; set => dssCause = value; }
    }
}
