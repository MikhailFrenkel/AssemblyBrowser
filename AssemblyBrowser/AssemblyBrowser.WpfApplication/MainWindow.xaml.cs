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
        private const string Dll = @"D:\учёба\3 курс\5 сем\СПП\1 лаба\Tracer\packages\Newtonsoft.Json.11.0.2\lib\netstandard2.0\Newtonsoft.Json.dll";

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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
