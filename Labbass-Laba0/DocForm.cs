using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labbass_Laba0
{
    public partial class DocForm : Form
    {
        private MemoryStream dataSource;

        public DocForm(MemoryStream dataSource)
        {
            this.dataSource = dataSource;
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (dataSource == null)
            {
                var exc = new ArgumentNullException(nameof(dataSource));
                MessageBox.Show($"Ошибка: Пустой поток. \nДанные трассировки стека: \n{exc}", "Ошибка загрузки документации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            pdfDocumentViewer1.LoadFromStream(dataSource);
        }

        protected override void OnClosed(EventArgs e)
        {
            dataSource?.Close();
            base.OnClosed(e);
        }
    }
}
