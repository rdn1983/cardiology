using System;

namespace Cardiology.Data.Model2
{
    public class DdtHospital
    {
        public static readonly string NAME = "ddt_hospital";

        public string ObjectId { get; set; }

        public string Diagnosis { get; set; }

        //РХиДМЛ
        public string DutyDoctor { get; set; }

        public DateTime CreationDate { get; set; }

        public int ReleaseType { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Patient { get; set; }

        //Кардиореаниматологи
        public string CuringDoctor { get; set; }

        public bool Active { get; set; }

        public DateTime ModifyDate { get; set; }

        public bool RejectCure { get; set; }

        public string RoomCell { get; set; }

        public bool Death { get; set; }

        public string DirCardioReanimDoctor { get; set; }

        public string SubstitutionDoctor { get; set; }

        public string AnesthetistDoctor { get; set; }

    }
}
