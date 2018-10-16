using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AssemblyBrowser.Reader;
using AssemblyBrowser.Reader.Models;
using AssemblyBrowser.WpfApplication.Helpers;
using AssemblyBrowser.WpfApplication.Interfaces;

namespace AssemblyBrowser.WpfApplication.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService _dialogService;
        private ReadAssembly _readAssembly;
        private List<Namespace> _namespaces;
        private RelayCommand _openCommand;

        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                       (_openCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               if (_dialogService.OpenFileDialog())
                               {
                                   Namespaces = _readAssembly.GetInformation(_dialogService.FilePath);
                               }
                           }
                           catch (Exception ex)
                           {
                               _dialogService.ShowMessage(ex.Message);
                           }
                       }));
            }
        }


        public List<Namespace> Namespaces
        {
            get => _namespaces;
            set
            {
                if (_namespaces != value)
                {
                    _namespaces = value;
                    OnPropertyChanged();
                }
            }
        }

        public ApplicationViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _readAssembly = new ReadAssembly();            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
