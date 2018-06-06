using System;

namespace Cardiology.Model
{
    class Patient
    {
        [TableAttribute("dss_login")]
        public string name;
        [TableAttribute("dss_initials")]
        public string secondName;
        [TableAttribute("dss_full_name")]
        public string lastName;
        
        public DateTime birthday;
        
        public DateTime receiptDateTime;
    }
}
