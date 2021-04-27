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
using System.Xml.Serialization;
using System.IO;

namespace WPF_labs
{
    /// <summary>
    /// Interaction logic for AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        public AddingWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var s = new Service();
            s.Name = NameT.Text;
            s.Desc = DescT.Text;
            s.Description = DescriptionT.Text;
            s.ImageSource = SourceT.Text;
            s.Price = Convert.ToInt32(PriceT.Text);

            XmlSerializer formatter = new XmlSerializer(typeof(List<Service>));
            List<Service> SavedServices = new List<Service>();
            //using (FileStream fs = new FileStream("Services.xml", FileMode.OpenOrCreate))
            //{

            //    SavedServices = (List<Service>)formatter.Deserialize(fs);
            //}

            SavedServices.Add(s);

            XmlSerializer formatterr = new XmlSerializer(typeof(List<Service>));
            using (FileStream fs = new FileStream("Services.xml", FileMode.Create))
            {
                {
                    formatter.Serialize(fs, SavedServices);
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            string a = SourceT.Text;
            Picture.Source = new ImageSourceConverter().ConvertFromString(a) as ImageSource;
        } 
    }
}
