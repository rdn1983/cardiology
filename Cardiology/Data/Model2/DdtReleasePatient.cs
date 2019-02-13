using System;

namespace Cardiology.Data.Model2
{
    public class DdtReleasePatient
    {
        public string ObjectId { get; set; }

        public DateTime OurEnddate { get; set; }

        public bool DismissedLess30d { get; set; }

        public string OurSicklistNum { get; set; }

        public string YearDisabilities { get; set; }

        public DateTime OurStartdate { get; set; }

        public DateTime CreationDate { get; set; }

        public string DisabilityNum { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string HospitalitySession { get; set; }

        public string Profession { get; set; }

        public DateTime ExtrEnddate { get; set; }

        public DateTime ExtrStartdate { get; set; }

        public DateTime ModifyDate { get; set; }

        public bool Pensioneer { get; set; }

        public bool IsWorking { get; set; }

        public bool SicklistNeed { get; set; }

        public bool ExtrOpenedSicklist { get; set; }

        public string OccupationalHazard { get; set; }

        public DateTime OkrReleaseDate { get; set; }

        public string ExtrSicklistNum { get; set; }

    }
}
