using System;
using System.Windows;

namespace SummationProductCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoopyCalculator sum = new LoopyCalculator();
        LoopyCalculator product = new LoopyCalculator();

        public MainWindow()
        {
            InitializeComponent();
            sum.window = this;
            product.window = this;
            sum.Init("sum");
            product.Init("product");
        }

        // Sum calculator buttons:
        private void sumClear_Click(object sender, RoutedEventArgs e)
        {
            sum.ResetAndClear(true);
        }

        private void sumRandom_Click(object sender, RoutedEventArgs e)
        {
            sum.Random();
        }

        private void sumEquals_Click(object sender, RoutedEventArgs e)
        {
            sum.CheckInput();
        }

        // Product calculator buttons:
        private void productClear_Click(object sender, RoutedEventArgs e)
        {
            product.ResetAndClear(true);
        }

        private void productRandom_Click(object sender, RoutedEventArgs e)
        {
            product.Random();
        }

        private void productEquals_Click(object sender, RoutedEventArgs e)
        {
            product.CheckInput();
        }
    }
}
