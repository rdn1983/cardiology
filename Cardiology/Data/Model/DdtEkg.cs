﻿using System;

namespace Cardiology.Model
{
    public class DdtEkg : DdtTypedObject
    {
        public const string TABLE_NAME = "ddt_ekg";

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
        [TableAttribute("dss_ekg")]
        private string dssEkg;
        [TableAttribute("dsb_admission_analysis")]
        private bool dsbAdmissionAnalysis;
        [TableAttribute("dsdt_analysis_date")]
        private DateTime dsdtAnalysisDate;
        [TableAttribute("dsid_parent")]
        private string dsidParent;
        [TableAttribute("dss_parent_type")]
        private string dssParentType;

        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public bool DsbAdmissionAnalysis { get => dsbAdmissionAnalysis; set => dsbAdmissionAnalysis = value; }
        public string DssEkg { get => dssEkg; set => dssEkg = value; }
        public DateTime DsdtAnalysisDate { get => dsdtAnalysisDate; set => dsdtAnalysisDate = value; }
        public string DsidParent { get => dsidParent; set => dsidParent = value; }
        public string DssParentType { get => dssParentType; set => dssParentType = value; }
        public string ObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
    }
}