using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AssemblyBrowser.WpfApplication.Interfaces;
using Microsoft.Win32;

namespace AssemblyBrowser.WpfApplication.Helpers
{
    class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }

            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }

            return false;
        }
    }
}
