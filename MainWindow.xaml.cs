using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace Demo
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string rootPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string projectfolder = Path.Combine(rootPath, "MyApp");
            string filepath = Path.Combine(projectfolder, $"{txtusername.Text}.txt");
            if (File.Exists(filepath))
            {
                string value = File.ReadAllText(filepath);

                User userdata = JsonConvert.DeserializeObject<User>(value);

                if (userdata.Username == txtusername.Text && userdata.Password == txtpassword.Password)
                {
                    MessageBox.Show("Valid User");

                }
                else
                {
                    MessageBox.Show("InValid User");
                }

            }
            else
            {
                MessageBox.Show("InValid User");
            }
        }
    }
}
        