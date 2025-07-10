using System.Windows;

namespace Example_03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.GetType().Name);
        }
    }
}