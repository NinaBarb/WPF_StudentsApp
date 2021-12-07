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
    /// Interaction logic for EditPeoplePerCoursePage.xaml
    /// </summary>
    public partial class EditPeoplePerCoursePage : FramedPage
    {
        public EditPeoplePerCoursePage(PersonCourseViewModel personCourseViewModel) :base(personCourseViewModel)
        {
            InitializeComponent();
            LvPeople.ItemsSource = personCourseViewModel.PeopleOnCourse;
            DataContext = personCourseViewModel.Course;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e) => Frame.Navigate(new EditPeopleOnCourse(PersonCourseViewModel) { Frame = Frame });

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvPeople.SelectedItem != null)
            {
                PersonCourseViewModel.PeopleOnCourse.Remove(LvPeople.SelectedItem as Person);
            }
        }
    }
}
