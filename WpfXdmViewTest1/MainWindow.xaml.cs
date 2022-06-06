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
using Saxon.Api;

namespace WpfXdmViewTest1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Processor processor = new Processor();
        public MainWindow()
        {
            InitializeComponent();

            //var values = new string[] { "foo", "bar", "baz" };

            //var values = new XdmItem[] { new XdmAtomicValue("foo"), new XdmAtomicValue(3), new XdmAtomicValue(true) };

            var xqueryCompiler = processor.NewXQueryCompiler();
            xqueryCompiler.BaseUri = new Uri("urn:from-string");
            var xqueryExecutable = xqueryCompiler.Compile("(1 to 5) ! <item>Item {.}</item>");
            var xqueryEvaluator = xqueryExecutable.Load();

            var xdmValue = xqueryEvaluator.Evaluate();

            XdmView.ItemsSource = xdmValue;
        }
    }
}
