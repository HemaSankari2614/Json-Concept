using System;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace Demo
{
    public partial class CombineFolder : Window
    {
        public CombineFolder()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User ouser = new User();
            ouser.Name = txtname.Text;
            ouser.Username = txtusername.Text;
            ouser.Password = txtpassword.Password;
            ouser.Adressvalue= txtaddressvalue.Text;
            ouser.Position = txtposition.Text;
            ouser.Degree = txtDegree.Text;


            string content = JsonConvert.SerializeObject(ouser);
            string rootPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string projectfolder = Path.Combine(rootPath, "MyApp");


            Directory.CreateDirectory(projectfolder);

            string filepath = Path.Combine(projectfolder, $"{txtusername.Text}.txt");
            if (File.Exists(filepath))
            {
                MessageBox.Show("Please choice differnt user name");
            }
            else
            {
                File.WriteAllText(filepath, content);
                MessageBox.Show("Register Success");
            }
        }
    }
}
