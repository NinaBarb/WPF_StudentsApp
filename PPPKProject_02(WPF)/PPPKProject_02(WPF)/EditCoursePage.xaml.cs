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
    /// Interaction logic for EditCoursePage.xaml
    /// </summary>
    public partial class EditCoursePage : FramedPage
    {
        private readonly Course course;
        public EditCoursePage(CourseViewModel courseViewModel, Course course = null) :base(courseViewModel)
        {
            InitializeComponent();
            this.course = course ?? new Course();
            DataContext = course;
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                course.Title = TbTitle.Text.Trim();
                course.ECTS = int.Parse(TbECTS.Text.Trim());
                if (course.IDCourse == 0)
                {
                    CourseViewModel.Courses.Add(course);
                }
                else
                {
                    CourseViewModel.Update(course);
                }
                Frame.NavigationService.GoBack();
            }
        }
        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age)))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            return valid;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();
    }
}
