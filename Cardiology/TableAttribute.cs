using System;

namespace Cardiology
{
    class TableAttribute : Attribute
    {
        string attrName;
        
        public TableAttribute(string attrName)
        {
            this.attrName = attrName;
        }

        public string AttrName
        {
            get { return attrName; }
        }
    }
}
