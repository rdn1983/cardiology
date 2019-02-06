using System;

namespace Cardiology.Data
{
    class TableAttribute : Attribute
    {
        string attrName;
        bool settable;
        
        public TableAttribute(string attrName)
        {
            this.attrName = attrName;
            this.settable = true;
        }

        public TableAttribute(string attrName, bool settable)
        {
            this.attrName = attrName;
            this.settable = settable;
        }

        public string AttrName
        {
            get { return attrName; }
        }

        public bool CanSetAttr
        {
            get { return settable; }
        }

    }
}
