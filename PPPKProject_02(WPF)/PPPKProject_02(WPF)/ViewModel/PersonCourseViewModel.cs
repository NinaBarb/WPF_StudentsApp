using PPPKProject_02_WPF_.Dal;
using PPPKProject_02_WPF_.Enumer;
using PPPKProject_02_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPKProject_02_WPF_.ViewModel
{
    public class PersonCourseViewModel
    {
        public Course Course { get; set; }
        public ObservableCollection<Person> PeopleOnCourse { get; }
        public ObservableCollection<Position> Positions{ get; }
        public ObservableCollection<Person> AllPeople { get; }
        public PersonCourseViewModel(Course course)
        {
            Course = course;
            AllPeople = new ObservableCollection<Person>(RepositoryFactory.GetRepository().GetPeople());
            Positions = new ObservableCollection<Position>(RepositoryFactory.GetRepository().GetPositions());
            PeopleOnCourse = new ObservableCollection<Person>(RepositoryFactory.GetRepository().GetPeopleCourses(Course.IDCourse));
            PeopleOnCourse.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().CreatePersonCourse(PeopleOnCourse[e.NewStartingIndex], Course);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeletePersonOnCourse(e.OldItems.OfType<Person>().ToList()[0], Course);
                    break;
            }
        }

        internal void Update(Person person) => PeopleOnCourse[PeopleOnCourse.IndexOf(person)] = person;
    }
}
