using PPPKProject_02_WPF_.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPPKProject_02_WPF_
{
    public class FramedPage : Page
    {
        public FramedPage(PersonCourseViewModel personCourseViewModel)
        {
            PersonCourseViewModel = personCourseViewModel;
        }
        public FramedPage(PersonViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }
        public FramedPage(CourseViewModel courseViewModel)
        {
            CourseViewModel = courseViewModel;
        }
        public FramedPage(PositionViewModel positionViewModel)
        {
            PositionViewModel = positionViewModel;
        }
        public PersonViewModel PersonViewModel { get; }
        public CourseViewModel CourseViewModel { get; }
        public PersonCourseViewModel PersonCourseViewModel { get; }
        public PositionViewModel PositionViewModel { get; }
        public Frame Frame { get; set; }
    }
}
