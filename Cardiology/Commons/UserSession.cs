using Cardiology.Data.Model2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardiology.Commons
{
    public class UserSession
    {
        private static UserSession userSession;

        public DdtDoctorV2 Doctor { get; private set; }

        public static UserSession getUserSession()
        {
            return userSession;
        }

        protected UserSession(DdtDoctorV2 doctor)
        {
            this.Doctor = doctor;
        }

        public static UserSession getUserSession(DdtDoctorV2 doctor)
        {
            if (doctor != null)
                userSession = new UserSession(doctor);
            return userSession;
        }
    }
}
