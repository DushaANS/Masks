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
using System.Windows.Markup;

namespace namordnIc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int i = 0;
        public int topPeremen = 0;
        public void Load_data(string stroka, string top, string a)
        {
            products.Children.Clear();
          //  Data Source = k1 - 204 - teacher,49172;
            using (SqlConnection connection = new SqlConnection(@" Initial Catalog = namordnik_ANS; Integrated Security = true;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"select {top}*,(select count(DISTINCT ID) from [namordnik_ANS].[dbo].[Product]) from Product where Description  Like {stroka + " " + a} ", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tovar sotrudnici = new Tovar();
                        sotrudnici.ID.Content = reader[0];
                        sotrudnici.name.Content = reader[1];
                        sotrudnici.articul.Content = reader[3];
                        sotrudnici.type.Content = reader[4];
                        sotrudnici.Cost.Content = reader[8];
                        try
                        {
                            sotrudnici.Photo.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + reader[5].ToString()));
                        }
                        catch (Exception)
                        {
                        }
                        sotrudnici.MainWindow = this;
                        products.Children.Add(sotrudnici);
                    }
                }
            }
        }
        public object x;

      
        private void sort_opr(string a)
        {
            //switch (sorting.SelectedIndex)
            //{
            //    case 0:
            //        Load_data("'%%' " + a, "");
            //        break;
            //    case 1:
            //        Load_data("0<=1000" + a, "");
            //        break;
            //    case 3:
            //        Load_data("1000<=2000 " + a, "");
            //        break;
            //    case 4:
            //        Load_data("1000>2000 " + a, "");
            //        break;
            //}
        }


        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filt_opr("");
        }

        private void sorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sort_opr("");
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            filt_opr($"and Product.Title like '%{search.Text}%'");
        }

        private void But_dobavit_Click(object sender, RoutedEventArgs e)
        {
            Edit_and_add_tovar edit_and_add_tovar = new Edit_and_add_tovar();
            edit_and_add_tovar.ShowDialog();
        }

       
        private void top_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filterTOP_SelectionChanged("");
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Edit_and_add_tovar add_btn = new Edit_and_add_tovar();
            add_btn.ShowDialog();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {

            if (i < 0)
            {
                back_btn.Visibility = Visibility.Hidden;
            }
            else
            {
                i -= topPeremen;
                back_btn.Visibility = Visibility.Visible;
                forward_btn.Visibility = Visibility.Visible;
            }
            if (i < 0)
            {
                filterTOP_SelectionChanged($"and ID>{0}");
            }
            else
            {
                filterTOP_SelectionChanged($"and ID>{i}");
            }
        }

        private void forward_btn_Click(object sender, RoutedEventArgs e)
        {
            if (i > (int)number_2.Content)
            {
                forward_btn.Visibility = Visibility.Hidden;
            }
            else
            {   
                i += topPeremen;
                forward_btn.Visibility = Visibility.Visible;
                back_btn.Visibility = Visibility.Visible;
            }
            if (i > (int)number_2.Content)
            {
                filterTOP_SelectionChanged($"and ID>{(int)number_2.Content - topPeremen}");
            }
            else
            {
                filterTOP_SelectionChanged($"and ID>{i - topPeremen}");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            products.Children.Clear();
            using (SqlConnection connection = new SqlConnection(@" Initial Catalog = namordnik_ANS; Integrated Security = true;"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($@"SELECT Count(DISTINCT ID) FROM [namordnik_ANS].[dbo].[Product]", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        number_2.Content = reader[0];
                    }
                }
            }
        }

        private void filterTOP_SelectionChanged(string a)
        {
            switch (filterTOP.SelectedIndex)
            {
                case 0:
                    Load_data("'%%'", "", a);
                    topPeremen = 0;
                    break;
                case 1:
                    Load_data("'%%'", "Top(5)", a);
                    topPeremen = 5;
                    number_1.Content = topPeremen;

                    break;
                case 2:
                    Load_data("'%%'", "Top(10)", a);
                    topPeremen = 10;
                    number_1.Content = topPeremen;

                    break;
                case 3:
                    Load_data("'%%'", "Top(15)", a);
                    topPeremen = 15;
                    number_1.Content = topPeremen;

                    break;
                case 4:
                    Load_data("'%%'", "Top(25)", a);
                    topPeremen = 25;
                    number_1.Content = topPeremen;

                    break;
            }
        }

        private void filt_opr(string a)
        {
            switch (filter.SelectedIndex)
            {
                case 0:
                    Load_data("'%%' " + a, "", "");
                    break;
                case 1:
                    Load_data("'Полумаски' " + a, "", "");
                    break;
                case 2:
                    Load_data("'Повязки' " + a, "", "");
                    break;
                case 3:
                    Load_data("'Маски' " + a, "", "");
                    break;
                case 4:
                    Load_data("'Респираторы' " + a, "", "");
                    break;
                case 5:
                    Load_data("'На лицо' " + a, "", "");
                    break;
                case 6:
                    Load_data("'Сменные части' " + a, "", "");
                    break;
                case 7:
                    Load_data("'Запасные части' " + a, "", "");
                    break;
                case 8:
                    Load_data("'Держители' " + a, "", "");
                    break;
                case 9:
                    Load_data("'Предфильтры' " + a, "", "");
                    break;
            }
        }
    }

}