
using DABViewer.ViewModel;
using System.Windows.Controls;


namespace DABViewer.Pages
{
    /// <summary>
    /// Interaction logic for SearchBankReceipt.xaml
    /// </summary>
    public partial class SearchBankReceipt : UserControl
    {
        public SearchBankReceipt()
        {
            InitializeComponent();
            DataContext = new SearchBankReceiptViewModel();
        }
    }
}
