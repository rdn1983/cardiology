using System;

namespace Cardiology.Data
{
    class TableAttribute : Attribute
    {
        readonly bool settable;
        
        public TableAttribute(string attrName)
        {
            this.AttrName = attrName;
            this.settable = true;
        }

        public TableAttribute(string attrName, bool settable)
        {
            this.AttrName = attrName;
            this.settable = settable;
        }

        public string AttrName { get; }

        public bool CanSetAttr
        {
            get { return settable; }
        }

    }
}
