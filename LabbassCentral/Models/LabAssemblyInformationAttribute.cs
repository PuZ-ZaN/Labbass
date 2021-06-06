using System;

namespace LabbassCentral
{
    [System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public class LabAssemblyInformationAttribute : Attribute
    {
        private readonly string labID;
        private readonly string labName;

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
