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
using System.Windows.Shapes;

namespace PPPKProject_02_WPF_
{
    /// <summary>
    /// Interaction logic for CourseDetails.xaml
    /// </summary>
    public partial class CourseDetails : Window
    {
        public CourseDetails(PersonCourseViewModel personCourseViewModel, Course course)
        {
            InitializeComponent();
            Frame.Navigate(new EditPeoplePerCoursePage(new PersonCourseViewModel(course)) { Frame = Frame });
        }
    }
}
