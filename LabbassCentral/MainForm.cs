using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabbassCentral
{
    public partial class MainForm : Form
    {
        List<Assembly> assemblies;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int labCounter = 0;
            assemblies = new List<Assembly>();
            foreach (var assembly in LoadAssemblies())
            {
                listBox1.Items.Add(assembly.GetCustomAttribute<LabAssemblyInformationAttribute>().LabName);
                assemblies.Add(assembly);
                labCounter++;
            }
            label1.Text = String.Format("Загружено {0} лабораторных работ", labCounter.ToString());
        }
        public IEnumerable<Assembly> LoadAssemblies()
        {
            var files = Directory.EnumerateFiles(Directory.GetCurrentDirectory());
            foreach (var fileName in files)
            {
                if (fileName.Substring(fileName.Length - 4) == ".dll")
                    yield return Assembly.LoadFrom(fileName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Вынести в метод, добавить проверки на null, переделать год(в)нокод короче
            var labSelectedName = listBox1.SelectedItem?.ToString();
            if (labSelectedName == null) return;
            var currentAssembly = assemblies.Where(assembly => assembly.
                GetCustomAttribute<LabAssemblyInformationAttribute>().
                LabName == labSelectedName).FirstOrDefault();
            var name = currentAssembly.DefinedTypes.Where(typeInfo => typeInfo.Name == "Lab").FirstOrDefault().FullName;
            var labInstance = (ILab)Activator.CreateInstance(currentAssembly.GetType(name));
            var LabThread = new Thread(a => labInstance.Show());
            this.WindowState = FormWindowState.Minimized;
            LabThread.Start();
            LabThread.Join();
            this.WindowState = FormWindowState.Normal;
        }
    }

}
