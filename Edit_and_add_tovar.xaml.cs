using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace namordnIc
{
    /// <summary>
    /// Логика взаимодействия для Edit_and_add_tovar.xaml
    /// </summary>
    public partial class Edit_and_add_tovar : Window
    {
        public Edit_and_add_tovar()
        {
            InitializeComponent();
        }

        public string photo_tovar { get; set; } = "default.jpg";

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Type1.Text.Trim() != "" && name1.Text.Trim() != "" && Articul1.Text.Trim() != "" && Cena.Text.Trim() != "" && Material1.Text.Trim() != "")
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source = k1-204-teacher,49172; Initial Catalog = namordnik_ANS; Integrated Security = true;"))
                {
                    connection.Open();
                    //SqlCommand command = new SqlCommand($@"UPDATE Product SET 
                    //                                       [Title] = '{name1.Text}'
                    //                                      ,[ProductTypeID] = '{null}'
                    //                                      ,[ArticleNumber] = '{Articul1.Text}'
                    //                                      ,[Description] = ' {(product_type.SelectedIndex == 0)}'
                    //                                      ,[Image] = '{Photo2.Source}'
                    //                                      ,[ProductionPersonCount] = '{null}'
                    //                                      ,[ProductionWorkshopNumber] = '{null}'
                    //                                      ,[MinCostForAgent] = '{null}'
                    //                                 WHERE ID={ID_Product.Content}", connection);
                    //   if (command.ExecuteNonQuery() == 1)
                    //        {
                    //            MessageBox.Show("Все ок");
                    //            Close();
                    //  //      }
                    //        else
                    //        {
                    //            MessageBox.Show("Ошибка. Проверьте данные");
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Проверьте данные");
                    //}
                }
            }
        }

            private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (/*product_type.Text.Trim() != "" &&*/ name1.Text.Trim() != "" && Articul1.Text.Trim() != "" /*&& cost.Text.Trim() != ""*/)
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source = k1-204-teacher,49172; Initial Catalog = Rahimov_product; Integrated Security = true;"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand($@"INSERT INTO [dbo].[Product]
                                                           ([Title]
                                                           ,[ArticleNumber]
                                                           ,[Image])
                                                     VALUES
                                                           ('{name1.Text}'
                                                           ,'{Articul1.Text}'
                                                           ,'{Photo2.Source}')", connection);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Все ок");
                        this.Close();
    }
                    else
                    {
                        MessageBox.Show("Ошибка. Проверьте данные");
                    }
                } 
            }

            else
            {
                 MessageBox.Show("Проверьте данные");
            }
        }
    }
}
