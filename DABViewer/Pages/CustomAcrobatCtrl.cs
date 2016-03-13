using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DABViewer.Pages
{
    public partial class CustomAcrobatCtrl : UserControl
    {
        public CustomAcrobatCtrl()
        {
            InitializeComponent();
        }

        private AxAcroPDFLib.AxAcroPDF AdobeArobatPDFControl
        {
            get
            {
                return this.axAcroPDF;
            }
        }

        public void LoadFile(string pdfFilePath)
        {
            AdobeArobatPDFControl.LoadFile(pdfFilePath);
        }
    }
}
