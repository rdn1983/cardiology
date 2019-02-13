using System;

namespace Cardiology.Data.Model
{
    [Obsolete("Этот класс будет удален", false)]
    public class DdtAlcoProtocol
    {
        public const string TABLE_NAME = "ddt_alco_protocol";

        [Table("r_object_id", false)]
        private string rObjectId;
        [Table("r_creation_date", false)]
        private DateTime rCreationDate;
        [Table("dsid_hospitality_session")]
        private string dsidHospitalitySession;
        [Table("dss_look")]
        private string dssLook;
        [Table("dss_behavior")]
        private string dssBehavior;
        [Table("dss_orientation")]
        private string dssOrientation;
        [Table("dss_speech")]
        private string dssSpeech;
        [Table("dss_skin")]
        private string dssSkin;
        [Table("dss_breathe")]
        private string dssBreathe;
        [Table("dss_pulse")]
        private string dssPulse;
        [Table("dss_pressure")]
        private string dssPressure;
        [Table("dss_eyes")]
        private string dssEyes;
        [Table("dss_nistagm")]
        private string dssNistagm;
        [Table("dss_motions")]
        private string dssMotions;
        [Table("dss_mimics")]
        private string dssMimics;
        [Table("dss_walk")]
        private string dssWalk;
        [Table("dss_touch_nose")]
        private string dssTouchNose;
        [Table("dss_tremble")]
        private string dssTremble;
        [Table("dss_illness")]
        private string dssIllness;
        [Table("dss_drunk")]
        private string dssDrunk;
        [Table("dss_smell")]
        private string dssSmell;
        [Table("dss_pribor")]
        private string dssPribor;
        [Table("dss_trub")]
        private string dssTrub;
        [Table("dss_bio")]
        private string dssBio;
        [Table("dss_docs")]
        private string dssDocs;
        [Table("dss_conclusion")]
        private string dssConclusion;
        [Table("dss_cause")]
        private string dssCause;
        [Table("dsb_template")]
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
