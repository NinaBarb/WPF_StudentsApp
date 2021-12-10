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
    /// Interaction logic for ListOfCoursesPage.xaml
    /// </summary>
    public partial class ListOfCoursesPage : FramedPage
    {
        private CourseViewModel viewModel;
        public ListOfCoursesPage(CourseViewModel courseViewModel) :base(courseViewModel)
        {
            InitializeComponent();
            LvCourses.ItemsSource = courseViewModel.Courses;
            viewModel = courseViewModel;
        }

        private void BtnPeople_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new ListOfPeoplePage(new PersonViewModel()) { Frame = Frame });

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditCoursePage(CourseViewModel) { Frame = Frame });

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (LvCourses.SelectedItem != null)
            {
                Frame.Navigate(new EditCoursePage(CourseViewModel, LvCourses.SelectedItem as Course) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvCourses.SelectedItem != null)
            {
                CourseViewModel.Courses.Remove(LvCourses.SelectedItem as Course);
            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Course course = viewModel.Courses.FirstOrDefault(c => c.IDCourse == (int)button.Tag);
            new CourseDetails(PersonCourseViewModel, course).Show();
        }

        private void BtnPositions_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new ListOfPositionsPage(new PositionViewModel()) { Frame = Frame });
    }
}
