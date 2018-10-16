using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AssemblyBrowser.Reader.Models;
using AssemblyBrowser.WpfApplication.Interfaces;

namespace AssemblyBrowser.WpfApplication.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private IDialogService _dialogService;
        private List<Namespace> _namespaces;
        

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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
