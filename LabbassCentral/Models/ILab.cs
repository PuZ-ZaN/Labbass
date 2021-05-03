using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbassCentral
{
    public interface ILab
    {
        void Show();
        event EventHandler Shown;
    }
}
