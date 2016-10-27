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
using System.Text.RegularExpressions;

namespace triangle.info
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Triangle tri;

        public MainWindow()
        {
            InitializeComponent();
            tbxSideA.TextChanged += new TextChangedEventHandler(sideChanged);
            tbxSideB.TextChanged += new TextChangedEventHandler(sideChanged);
            tbxSideC.TextChanged += new TextChangedEventHandler(sideChanged);

            tri = new Triangle(tbxSideA.Text, tbxSideB.Text, tbxSideC.Text);

            updateTriangleInfoContent();
        }

        private void sideChanged(object sender, TextChangedEventArgs e)
        {
            tri.updateSides(tbxSideA.Text, tbxSideB.Text, tbxSideC.Text);

            updateTriangleInfoContent();
        }

        private void updateTriangleInfoContent()
        {
            Triangle.TriangleState triState = tri.getTriangleState();

            String triangleInfoMessage;

            switch (triState)
            {
                case Triangle.TriangleState.Invalid:
                    triangleInfoMessage = "This is an invalid triangle.";
                    break;
                case Triangle.TriangleState.Right:
                    triangleInfoMessage = "This is a right triangle.";
                    break;
                case Triangle.TriangleState.Equilateral:
                    triangleInfoMessage = "This is an equilateral triangle.";
                    break;
                case Triangle.TriangleState.Isoscelese:
                    triangleInfoMessage = "This is an isoscelese triangle.";
                    break;
                case Triangle.TriangleState.NotSpecial:
                    triangleInfoMessage = "This is a normal triangle.";
                    break;
                default:
                    triangleInfoMessage = "This is probably an invalid triangle.";
                    break;

            }

            infoOutput.Content = triangleInfoMessage;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
