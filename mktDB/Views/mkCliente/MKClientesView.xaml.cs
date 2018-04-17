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


namespace mktDB
{
    /// <summary>
    /// Interaction logic for MKClientesView.xaml
    /// </summary>
    public partial class MKClientesView : UserControl
    {
        public MKClientesView()
        {
            InitializeComponent();
            this.DataContext = new MKClientesViewModel();
        }
    }
}
