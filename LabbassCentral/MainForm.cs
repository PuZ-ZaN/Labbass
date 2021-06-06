namespace LabbassCentral
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private List<AssemblyLink> assemblies;

        public MainForm()
        {
            InitializeComponent();
            UpdateLabsList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateLabsList();
        }

        private async void UpdateLabsList()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(10); //Без этого не работает)))
                button1.Invoke(new Action(() => button1.Enabled = false));
                listBox1.Invoke(new Action(() => listBox1.Items.Clear()));
                assemblies = LoadAssemblies(Directory.GetCurrentDirectory()).ToList();
                assemblies.ForEach(asm => listBox1.Invoke(new Action(() => listBox1.Items.Add(asm))));
                label1.Invoke(new Action(() => label1.Text = $"Загружено {assemblies.Count} лабораторных работ"));
                button1.Invoke(new Action(() => button1.Enabled = true));
            });
        }

        private IEnumerable<AssemblyLink> LoadAssemblies(string path)
        {
            var files = Directory.EnumerateFiles(path);
            foreach (var fileName in files)
            {
                if (Path.GetExtension(fileName) == ".dll")
                {
                    var assembly = Assembly.LoadFrom(fileName);
                    var asmAttribute = assembly.GetCustomAttribute<LabAssemblyInformationAttribute>();
                    if (asmAttribute != null)
                        yield return new AssemblyLink(asmAttribute, fileName);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunLab();
        }

        private void RunLab()
        {
            var selectedLab = (AssemblyLink)listBox1.SelectedItem;
            if (selectedLab == null) return;

            var currentAssembly = Assembly.LoadFrom(selectedLab.Path);
            var labInstance = Activator.CreateInstance(currentAssembly.GetTypes().Where(type => type.GetInterface(nameof(ILab)) != null).First()) as ILab;
            var LabThread = new Thread(() => labInstance.Show());
            this.WindowState = FormWindowState.Minimized;
            LabThread.SetApartmentState(ApartmentState.STA);
            LabThread.Start();
            LabThread.Join();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
