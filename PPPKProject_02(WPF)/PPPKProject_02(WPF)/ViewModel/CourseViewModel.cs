using PPPKProject_02_WPF_.Dal;
using PPPKProject_02_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPKProject_02_WPF_.ViewModel
{
    public class CourseViewModel
    {
        public ObservableCollection<Course> Courses { get; }
        public CourseViewModel()
        {
            Courses = new ObservableCollection<Course>(RepositoryFactory.GetRepository().GetCourses());
            Courses.CollectionChanged += Courses_CollectionChanged1;
        }

        private void Courses_CollectionChanged1(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().CreateCourse(Courses[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeleteCourse(e.OldItems.OfType<Course>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdateCourse(e.NewItems.OfType<Course>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Course course) => Courses[Courses.IndexOf(course)] = course;
    }
}
