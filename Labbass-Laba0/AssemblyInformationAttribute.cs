using System;

namespace Labbass_Laba0
{
    [System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    sealed class AssemblyInformationAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string LabID;
        readonly string LabName;

        // This is a positional argument
        public AssemblyInformationAttribute(string labID, string labName)
        {
            this.LabID = labID;
            this.LabName = labName;

            // TODO: Implement code here

            throw new NotImplementedException();
        }

        public string PositionalString
        {
            get { return LabID; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }
}
