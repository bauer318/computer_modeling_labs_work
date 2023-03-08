using ComputerModelling.Pearson;
using ComputerModelling.PokerTest;
using ComputerModelling.QuadraticCongruentMethod;
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
using System.Windows.Shapes;

namespace Graphic
{
    /// <summary>
    /// Interaction logic for PokerTestWindow.xaml
    /// </summary>
    public partial class PokerTestWindow : Window
    {
        public List<PokerTestValue> PokerTestList { get; set; }
        public PokerTestWindow(double[] parValues, int parN)
        {
            PokerTestList = new List<PokerTestValue>();
            PokerTest test = new PokerTest(parValues, parN, 8);
            test.DetemineFivesDifferentClassesNumber();
            PokerTestList.Add(new PokerTestValue("P(abcde)", Math.Round(test.Pabcde,5,MidpointRounding.AwayFromZero).ToString()));
            PokerTestList.Add(new PokerTestValue("P(aabcd)", Math.Round(test.Paabcd,5, MidpointRounding.AwayFromZero).ToString()));
            PokerTestList.Add(new PokerTestValue("P(aabbc)", Math.Round(test.Paabbc,5, MidpointRounding.AwayFromZero).ToString()));
            PokerTestList.Add(new PokerTestValue("P(aaabc)", Math.Round(test.Paaabc,5, MidpointRounding.AwayFromZero).ToString()));
            PokerTestList.Add(new PokerTestValue("P(aaabb)", Math.Round(test.Paaabb,5, MidpointRounding.AwayFromZero).ToString()));
            PokerTestList.Add(new PokerTestValue("P(aaaab)", Math.Round(test.Paaaab,5, MidpointRounding.AwayFromZero).ToString()));
            PokerTestList.Add(new PokerTestValue("P(aaaaa)", Math.Round(test.Paaaaa,5, MidpointRounding.AwayFromZero).ToString()));
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
