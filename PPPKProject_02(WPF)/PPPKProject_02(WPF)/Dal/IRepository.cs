using PPPKProject_02_WPF_.Enumer;
using PPPKProject_02_WPF_.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPKProject_02_WPF_.Dal
{
    public interface IRepository
    {
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        IList<Person> GetPeople();
        Person GetPerson(int idPerson);

        IList<Course> GetCourses();
        void CreateCourse(Course course);
        void DeleteCourse(Course course);
        void UpdateCourse(Course course);

        IList<Position> GetPositions();
        void CreatePosition(Position position);
        void DeletePosition(Position position);
        void UpdatePosition(Position position);

        void CreatePersonCourse(Person person, Course course);
        void DeletePersonOnCourse(Person person, Course course);
        IList<Person> GetPeopleCourses(int IDCourse);

        void CreatePositionPerson(Person person, Position position);


    }
}
