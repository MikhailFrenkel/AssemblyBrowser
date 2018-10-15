using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AssemblyBrowser.Reader;

namespace AssemblyBrowser.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ReadAssembly _readAssembly;
        private const string Dll = "D:/учёба/3 курс/5 сем/СПП/2 лаба/Plugins/Plugins/Generators/bin/Debug/netstandard2.0/Generators.dll";

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                _readAssembly = new ReadAssembly();
                _readAssembly.GetInformation(Dll);
            }
            catch (Exception)
            {

            }

        }
    }
}
