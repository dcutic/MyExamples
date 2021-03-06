﻿using DABViewer.Common;
using DABViewer.Model;
using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace DABViewer.ViewModel
{
    public class SearchBankReceiptViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Data> _myData;
        private string _searchKeyWord;
        private Data _selectedData;
        private SearchCriterias _searchCriterias;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public Data SelectedData
        {
            get
            {
                return _selectedData;
            }
            set
            {
                if(_selectedData != value)
                {
                    _selectedData = value;
                    NotifyPropertyChanged("SelectedData");
                }
            }
        }
        public string SearchKeyWord
        {
            get
            {
                return _searchKeyWord;
            }
            set
            {
                if(_searchKeyWord != value)
                {
                    _searchKeyWord = value;
                    NotifyPropertyChanged("SearchKeyWord");
                    SetFilter();
                }
            }
        }
        public ObservableCollection<Data> MyData
        {
            get
            {
                return _myData;
            }
            set
            {
                if(_myData != value)
                {
                    _myData = value;
                }
            }
        }
        public SearchCriterias SeachCriterias
        {
            get
            {
                return _searchCriterias;
            }
            set
            {
                if(_searchCriterias != value)
                {
                    _searchCriterias = value;
                    NotifyPropertyChanged("SeachCriterias");
                }
            }
        }
        public ICommand StartFilteringCommand
        {
            get
            {
                return new DelegateCommand(StartFiltering);
            }
        }

        private void StartFiltering(object param)
        {
            MessageBox.Show("Done", "OK");
        }

        public SearchBankReceiptViewModel()
        {
            MyData = new ObservableCollection<Data>();
            var dirInfo = new DirectoryInfo("C:/Users/Dani/OneDrive/Schule/Bachelor Arbeit");
            var info = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);
            var counter = 0;
            foreach(var item in info)
            {
                var test = new Data { FullName = item.Name, LastAccess = item.LastAccessTime, DepotNummer = counter++ };
                MyData.Add(test);     
            }
            SeachCriterias = new SearchCriterias();
        }
        private void SetFilter()
        {
            var view = CollectionViewSource.GetDefaultView(MyData);
            view.Filter = item =>
            {
                var vitem = item as Data;
                return vitem != null && (vitem.FullName.Contains(SearchKeyWord) || (vitem.DepotNummer.ToString()).Contains(SearchKeyWord));
            }; 
       }
         
    }
}
