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
            UpdateLabsList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateLabsList();
        }
        public void UpdateLabsList()
        {
            listBox1.Items.Clear();
            int labCounter = 0;
            assemblies = new List<Assembly>();
            foreach (var assembly in LoadAssemblies())
            {
                //TODO: костыль, нужно что то типа assembly.CustomAttributes.Where(attr => attr.Type is LabAssemblyInformationAttributes)
                try
                {
                    listBox1.Items.Add(assembly.GetCustomAttribute<LabAssemblyInformationAttribute>()?.LabName);
                }
                catch (Exception ex)
                {
                    continue;
                }

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
            RunLab();
        }
        private void RunLab()
        {
            var labSelectedName = listBox1.SelectedItem?.ToString();
            if (labSelectedName == null) return;
            var currentAssembly = assemblies.Where(assembly => assembly.GetCustomAttribute<LabAssemblyInformationAttribute>().LabName == labSelectedName).FirstOrDefault();
            var name = currentAssembly.DefinedTypes.Where(typeInfo => typeInfo.Name == "Lab").FirstOrDefault().FullName;//FullName!="Lab"
            var labInstance = currentAssembly.CreateInstance(name) as ILab;
            var LabThread = new Thread(() => labInstance.Show());
            this.WindowState = FormWindowState.Minimized;
            LabThread.SetApartmentState(ApartmentState.STA);
            LabThread.Start();
            LabThread.Join();
            this.WindowState = FormWindowState.Normal;
        }
    }

}
