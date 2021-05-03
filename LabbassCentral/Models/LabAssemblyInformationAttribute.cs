using System;

namespace Labbass_Laba0
{
    [System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    sealed class LabAssemblyInformationAttribute : Attribute
    {
        readonly string labID;
        readonly string labName;
        public LabAssemblyInformationAttribute(string labID, string labName)
        {
            this.labID = labID;
            this.labName = labName;
        }

        public string LabID
        {
            get { return labID; }
        }

        public string LabName
        {
            get { return labName; }
        }
    }
}
