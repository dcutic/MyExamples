
using System;
using System.Collections.Generic;
using System.Linq;


namespace DABViewer.Model
{
    public class SearchCriterias
    {

        public string DepotInhaber { get; set; }
        public int Stammnummer { get; set; }
        public List<TransactionTypes> TransactionTypes { get; set; }
        public TransactionTypes SelectedTransactionType { get; set; }
        public List<DocumentTypes> DocumentTypes { get; set; }
        public DocumentTypes SelectedDocumentType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime SelectedStartDate { get; set; }
        public DateTime SelectedEndDate { get; set; }
        public string ISIN { get; set; }
        public SearchCriterias()
        {
            InitializeModel();
        
        }
        private void InitializeModel()
        {
            TransactionTypes = InitializeTransactionTypes();
            DocumentTypes = InitializeDocumentTypes();

            if(SelectedTransactionType == null)
            {
                SelectedTransactionType = TransactionTypes.FirstOrDefault();
            }

            if(SelectedDocumentType == null)
            {
                SelectedDocumentType = DocumentTypes.FirstOrDefault();
            }
        }

        private List<TransactionTypes> InitializeTransactionTypes()
        {
            return new List<TransactionTypes>
            {
                new TransactionTypes
                {
                    Id = 0,
                    sysText = "Kauf"
                },
                new TransactionTypes
                {
                    Id = 1,
                    sysText = "Verkauf"
                }
            }.ToList();
        }
        private List<DocumentTypes> InitializeDocumentTypes()
        {
            return new List<DocumentTypes>
            {
                new DocumentTypes
                {
                    Id = 0,
                    sysText = "Hauptversammlung"
                },
                new DocumentTypes
                {
                    Id = 1,
                    sysText = "Änderung Informationen"
                }
            }.ToList();
        }
    }
}
