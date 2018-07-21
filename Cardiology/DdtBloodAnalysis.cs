using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardiology.Model
{
    public class DdtBloodAnalysis
    {
        public const string TABLE_NAME = "ddt_blood_analysis";

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
        [TableAttribute("dsd_hemoglobin")]
        private double dsdHemoglobin;
        [TableAttribute("dsd_leucocytes")]
        private double dsdLeucocytes;
        [TableAttribute("dsd_platelets")]
        private double dsdPlatelets;
        [TableAttribute("dsd_protein")]
        private double dsdProtein;
        [TableAttribute("dsd_creatinine")]
        private double dsdCreatinine;
        [TableAttribute("dsd_cholesterol")]
        private double dsdCholesterolr;
        [TableAttribute("dsd_bil")]
        private double dsdBil;
        [TableAttribute("dsd_iron")]
        private double dsdIron;
        [TableAttribute("dsd_alt")]
        private double dsdAlt;
        [TableAttribute("dsd_ast")]
        private double dsdAst;
        [TableAttribute("dsd_schf")]
        private double dsdSchf;
        [TableAttribute("dsd_amylase")]
        private double dsdAmylase;
        [TableAttribute("dsd_kfk")]
        private double dsdKfk;
        [TableAttribute("dsd_kfk_mv")]
        private double dsdKfkMv;
        [TableAttribute("dsd_srp")]
        private double dsdSrp;
        [TableAttribute("dsd_potassium")]
        private double dsdPotassium;
        [TableAttribute("dsd_sodium")]
        private double dsdSodium;
        [TableAttribute("dsd_chlorine")]
        private double dsdChlorine;

        public string RObjectId { get => rObjectId; set => rObjectId = value; }
        public DateTime RCreationDate { get => rCreationDate; set => rCreationDate = value; }
        public string DsidHospitalitySession { get => dsidHospitalitySession; set => dsidHospitalitySession = value; }
        public string DsidPatient { get => dsidPatient; set => dsidPatient = value; }
        public string DsidDoctor { get => dsidDoctor; set => dsidDoctor = value; }
        public double DsdHemoglobin { get => dsdHemoglobin; set => dsdHemoglobin = value; }
        public double DsdLeucocytes { get => dsdLeucocytes; set => dsdLeucocytes = value; }
        public double DsdPlatelets { get => dsdPlatelets; set => dsdPlatelets = value; }
        public double DsdProtein { get => dsdProtein; set => dsdProtein = value; }
        public double DsdCreatinine { get => dsdCreatinine; set => dsdCreatinine = value; }
        public double DsdCholesterolr { get => dsdCholesterolr; set => dsdCholesterolr = value; }
        public double DsdBil { get => dsdBil; set => dsdBil = value; }
        public double DsdIron { get => dsdIron; set => dsdIron = value; }
        public double DsdAlt { get => dsdAlt; set => dsdAlt = value; }
        public double DsdAst { get => dsdAst; set => dsdAst = value; }
        public double DsdSchf { get => dsdSchf; set => dsdSchf = value; }
        public double DsdAmylase { get => dsdAmylase; set => dsdAmylase = value; }
        public double DsdKfk { get => dsdKfk; set => dsdKfk = value; }
        public double DsdKfkMv { get => dsdKfkMv; set => dsdKfkMv = value; }
        public double DsdSrp { get => dsdSrp; set => dsdSrp = value; }
        public double DsdPotassium { get => dsdPotassium; set => dsdPotassium = value; }
        public double DsdSodium { get => dsdSodium; set => dsdSodium = value; }
        public double DsdChlorine { get => dsdChlorine; set => dsdChlorine = value; }
    }
}
