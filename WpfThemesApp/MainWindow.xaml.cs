using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfThemesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<string> themes = new List<string>() { "light", "dark" };

            list.ItemsSource = themes;
            list.SelectedIndex = 0;
            list.SelectionChanged += List_SelectionChanged;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theme = list.SelectedItem.ToString();
            var uri = new Uri(theme + ".xaml", UriKind.Relative);
            var resourceTheme = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceTheme);
        }
    }
}