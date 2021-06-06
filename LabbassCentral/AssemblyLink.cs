using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LabbassCentral
{
    internal class AssemblyLink
    {
        public LabAssemblyInformationAttribute AssemblyInfo { get; private set; }
        public string Path { get; private set; }

        public AssemblyLink(LabAssemblyInformationAttribute info, string path)
        {
            AssemblyInfo = info;
            Path = path;
        }

        public override string ToString()
        {
            return $"{AssemblyInfo.LabID}: {AssemblyInfo.LabName}";
        }
    }
}
