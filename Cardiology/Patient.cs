using System;

namespace Cardiology.Model
{
    class Patient
    {
        [TableAttribute("name")]
        public string name;
        [TableAttribute("secondName")]
        public string secondName;
        [TableAttribute("lastName")]
        public string lastName;
        [TableAttribute("birthday")]
        public DateTime birthday;
        [TableAttribute("receiptDateTime")]
        public DateTime receiptDateTime;
    }
}
