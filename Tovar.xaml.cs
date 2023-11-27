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
using System.Data.SqlClient;
using System.Windows.Media.Media3D;

namespace namordnIc
{
    /// <summary>
    /// Логика взаимодействия для Tovar.xaml
    /// </summary>
    public partial class Tovar : UserControl
    {
        public Tovar()
        {
            InitializeComponent();
        }

        public MainWindow MainWindow;

        private void Delete_tovar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source = k1-204-teacher,49172; Initial Catalog = namordnik_ANS; Integrated Security = true;"))
            {
                SqlCommand command = new SqlCommand($"DELETE FROM [dbo].[Product].[Material] where Id = {ID.Content}", connection);
                command.ExecuteNonQuery();
                MainWindow.Load_data("'%%'","", "");
            }
        }

        private void Edit_tovar_Click(object sender, RoutedEventArgs e)
        {
            Edit_and_add_tovar edit_and_tovar = new Edit_and_add_tovar();
            edit_and_tovar.Type1.Text = type.Content.ToString();
            edit_and_tovar.name1.Text = name.Content.ToString();
            edit_and_tovar.Articul1.Text = articul.Content.ToString();
            edit_and_tovar.Cena.Text = Cost.Content.ToString();
            edit_and_tovar.Material1.Text = Material.Content.ToString();
            edit_and_tovar.Photo2.Source = Photo.Source;
            edit_and_tovar.photo_tovar = Photo.Source.ToString().Remove(0, Photo.Source.ToString().LastIndexOf('/') + 1);
            edit_and_tovar.Photo2.Source = Photo.Source;
            edit_and_tovar.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          //  material.Children.Clear();
            using (SqlConnection connection = new SqlConnection(@"Data Source = k1-204-teacher,49172; Initial Catalog = Rahimov_product; Integrated Security = true;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"select distinct Material.Title from Product,Material,ProductMaterial where ProductMaterial.ProductID = {ID_Product.Content} and ProductMaterial.MaterialID=Material.ID", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                     //   UserControl2 userControl2 = new UserControl2();
                     //   userControl2.materials.Content = reader[0];
                      //  material.Children.Add(userControl2);
                    }
                }
            }
        }
    }
}
        
    






