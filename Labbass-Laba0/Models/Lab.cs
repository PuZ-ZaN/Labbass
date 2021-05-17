using System;
using System.Windows.Forms;

using LabbassCentral;

[assembly: LabAssemblyInformation("0", "Лаба 0 Штангенциркуль")]
namespace Labbass_Laba0
{

    class Lab : ILab
    {
        public Lab()
        {
        }

        public event EventHandler Shown;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Show()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LabForm());
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
