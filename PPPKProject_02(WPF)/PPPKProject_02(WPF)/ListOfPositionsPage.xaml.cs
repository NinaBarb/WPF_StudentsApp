using PPPKProject_02_WPF_.Enumer;
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
    /// Interaction logic for ListOfPositionsPage.xaml
    /// </summary>
    public partial class ListOfPositionsPage : FramedPage
    {
        public ListOfPositionsPage(PositionViewModel positionViewModel) :base(positionViewModel)
        {
            InitializeComponent();
            LvPositions.ItemsSource = positionViewModel.Positions;
        }

        private void BtnPeople_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new ListOfPeoplePage(new PersonViewModel()) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvPositions.SelectedItem != null)
            {
                Frame.Navigate(new EditPositionPage(PositionViewModel, LvPositions.SelectedItem as Position) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvPositions.SelectedItem != null)
            {
                PositionViewModel.Positions.Remove(LvPositions.SelectedItem as Position);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditPositionPage(PositionViewModel) { Frame = Frame });

        private void BtnCourses_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new ListOfCoursesPage(new CourseViewModel()) { Frame = Frame });
    }
}
