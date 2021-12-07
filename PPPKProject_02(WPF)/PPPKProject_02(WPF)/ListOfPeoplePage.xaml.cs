using PPPKProject_02_WPF_.Model;
using PPPKProject_02_WPF_.ViewModel;
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

namespace PPPKProject_02_WPF_
{
    /// <summary>
    /// Interaction logic for ListOfPeoplePage.xaml
    /// </summary>
    public partial class ListOfPeoplePage : FramedPage
    {
        public ListOfPeoplePage(PersonViewModel personViewModel) : base(personViewModel)
        {
            InitializeComponent();
            LvUsers.ItemsSource = personViewModel.People;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvUsers.SelectedItem != null)
            {
                Frame.Navigate(new EditPersonPage(PersonViewModel, LvUsers.SelectedItem as Person) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvUsers.SelectedItem != null)
            {
                PersonViewModel.People.Remove(LvUsers.SelectedItem as Person);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditPersonPage(PersonViewModel) { Frame = Frame });

        private void BtnCourses_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListOfCoursesPage(new CourseViewModel()) { Frame = Frame });
        }

        private void BtnPosition_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListOfPositionsPage(new PositionViewModel()) { Frame = Frame });
        }
    }
}
