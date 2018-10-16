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
        private string _outputString;

        public string OutputString
        {
            get => _outputString;
            set
            {
                if (_outputString != value)
                {
                    _outputString = value;
                    OnPropertyChanged();
                }
            }
        }
        
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
                //if (_namespaces != value)
                //{
                    _namespaces = value;
                    NamespacesToString();
                    OnPropertyChanged();
                //}
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

        private void NamespacesToString()
        {
            string res = "";
            foreach (var ns in _namespaces)
            {
                res += $"{ns.Name}:\n";
                foreach (var dataType in ns.DataTypes)
                {
                    res += $"  {dataType.Name}:\n";
                    foreach (var field in dataType.Fields)
                    {
                        res += $"    Field: {field.Type} {field.Name}\n";
                    }

                    foreach (var property in dataType.Properties)
                    {
                        res += $"    Property: {property.Type} {property.Name}\n";
                    }

                    foreach (var method in dataType.Methods)
                    {
                        res += $"    Method: {method.Signature}\n";
                    }
                }
            }

            OutputString = res;
        }
    }
}
