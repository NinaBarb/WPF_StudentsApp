using PPPKProject_02_WPF_.Enumer;
using PPPKProject_02_WPF_.Model;
using PPPKProject_02_WPF_.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PPPKProject_02_WPF_.Dal
{
    class SqlRepository : IRepository
    {
        private static readonly string cs = EncryptionUtils.Decrypt(ConfigurationManager.ConnectionStrings["cs"].ConnectionString, "fru1tc@k3");

        private const string FirstNameParam = "@Firstname";
        private const string LastNameParam = "@Lastname";
        private const string AgeParam = "@Age";
        private const string JMBAGParam = "@JMBAG";
        private const string GenderParam = "@Gender";
        private const string EmailParam = "@Email";
        private const string PictureParam = "@Picture";
        private const string IdPersonParam = "@IdPerson";

        private const string TitleParam = "@Title";
        private const string ECTSParam = "@ECTS";
        private const string IdCourseParam = "@IDCourse";

        private const string IdPersonCourseParam = "@IDPersonCourse";
        private const string CourseIdParam = "@CourseID";
        private const string PersonIdParam = "@PersonID";

        private const string PositiionIdParam = "@PositionID";
        private const string IdPositionPerson = "@IDPositionPerson";
        private const string IdPositionParam = "@IDPosition";
        private const string PositionIdParam = "@PositionID";
        public void CreatePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(FirstNameParam, person.FirstName);
                    cmd.Parameters.AddWithValue(LastNameParam, person.LastName);
                    cmd.Parameters.AddWithValue(AgeParam, person.Age);
                    cmd.Parameters.AddWithValue(JMBAGParam, person.JMBAG);
                    cmd.Parameters.AddWithValue(GenderParam, person.Gender);
                    cmd.Parameters.AddWithValue(EmailParam, person.Email);
                    cmd.Parameters.Add(new SqlParameter(PictureParam, SqlDbType.Binary, person.Picture.Length)
                    {
                        Value = person.Picture
                    });
                    SqlParameter idPerson = new SqlParameter(IdPersonParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idPerson);
                    cmd.ExecuteNonQuery();
                    person.IDPerson = (int)idPerson.Value;
                }
            }
        }

        public void DeletePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdPersonParam, person.IDPerson);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Person> GetPeople()
        {
            IList<Person> people = new List<Person>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            people.Add(ReadPerson(dr));
                        }
                    }
                }
            }
            return people;
        }

        private Person ReadPerson(SqlDataReader dr) => new Person
        {
            IDPerson = (int)dr[nameof(Person.IDPerson)],
            FirstName = dr[nameof(Person.FirstName)].ToString(),
            LastName = dr[nameof(Person.LastName)].ToString(),
            Age = (int)dr[nameof(Person.Age)],
            JMBAG = dr[nameof(Person.JMBAG)].ToString(),
            Gender = (Gender)Enum.Parse(typeof(Gender), dr[nameof(Person.Gender)].ToString(), true),
            Email = dr[nameof(Person.Email)].ToString(),
            Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 7)
        };

        public Person GetPerson(int idPerson)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdPersonParam, idPerson);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return ReadPerson(dr);
                        }
                    }
                }
            }
            throw new Exception("Person does not exist!");
        }

        public void UpdatePerson(Person person)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(FirstNameParam, person.FirstName);
                    cmd.Parameters.AddWithValue(LastNameParam, person.LastName);
                    cmd.Parameters.AddWithValue(AgeParam, person.Age);
                    cmd.Parameters.AddWithValue(JMBAGParam, person.JMBAG);
                    cmd.Parameters.AddWithValue(GenderParam, person.Gender);
                    cmd.Parameters.AddWithValue(EmailParam, person.Email);
                    cmd.Parameters.AddWithValue(IdPersonParam, person.IDPerson);
                    cmd.Parameters.Add(new SqlParameter(PictureParam, SqlDbType.Binary, person.Picture.Length)
                    {
                        Value = person.Picture
                    });
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateCourse(Course course)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(TitleParam, course.Title);
                    cmd.Parameters.AddWithValue(ECTSParam, course.ECTS);
                    SqlParameter idCourse = new SqlParameter(IdCourseParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idCourse);
                    cmd.ExecuteNonQuery();
                    course.IDCourse = (int)idCourse.Value;
                }
            }
        }

        public void DeleteCourse(Course course)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdCourseParam, course.IDCourse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCourse(Course course)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(TitleParam, course.Title);
                    cmd.Parameters.AddWithValue(ECTSParam, course.ECTS);
                    cmd.Parameters.AddWithValue(IdCourseParam, course.IDCourse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Course> GetCourses()
        {
            IList<Course> courses = new List<Course>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            courses.Add(ReadCourse(dr));
                        }
                    }
                }
            }
            return courses;
        }

        private Course ReadCourse(SqlDataReader dr) => new Course
        {
            IDCourse = (int)dr[nameof(Course.IDCourse)],
            Title = dr[nameof(Course.Title)].ToString(),
            ECTS = (int)dr[nameof(Course.ECTS)]
        };

        public void CreatePersonCourse(Person person, Course course)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(CourseIdParam, course.IDCourse);
                    cmd.Parameters.AddWithValue(PersonIdParam, person.IDPerson);
                    cmd.Parameters.AddWithValue(PositionIdParam, person.Position.IDPosition);
                    SqlParameter idPersonCourse = new SqlParameter(IdPersonCourseParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idPersonCourse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Person> GetPeopleCourses(int IDCourse)
        {
            IList<Person> people = new List<Person>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdCourseParam, IDCourse);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            people.Add(ReadPerson2(dr));
                        }
                    }
                }
            }
            return people;
        }
        private Person ReadPerson2(SqlDataReader dr) => new Person
        {
            IDPerson = (int)dr[nameof(Person.IDPerson)],
            FirstName = dr[nameof(Person.FirstName)].ToString(),
            LastName = dr[nameof(Person.LastName)].ToString(),
            Age = (int)dr[nameof(Person.Age)],
            JMBAG = dr[nameof(Person.JMBAG)].ToString(),
            Gender = (Gender)Enum.Parse(typeof(Gender), dr[nameof(Person.Gender)].ToString(), true),
            Email = dr[nameof(Person.Email)].ToString(),
            PositionTitle = dr[nameof(Person.PositionTitle)].ToString(),
            Picture = ImageUtils.ByteArrayFromSqlDataReader(dr, 7)
        };

        public void DeletePersonOnCourse(Person person, Course course)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdPersonParam, person.IDPerson);
                    cmd.Parameters.AddWithValue(IdCourseParam, course.IDCourse);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreatePositionPerson(Person person, Position position)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(PersonIdParam, person.IDPerson);
                    cmd.Parameters.AddWithValue(PositiionIdParam, position.IDPosition);
                    SqlParameter idPositionPerson = new SqlParameter(IdPositionPerson, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idPositionPerson);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Position> GetPositions()
        {
            IList<Position> positions = new List<Position>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            positions.Add(ReadPosition(dr));
                        }
                    }
                }
            }
            return positions;
        }

        private Position ReadPosition(SqlDataReader dr) => new Position
        {
            IDPosition = (int)dr[nameof(Position.IDPosition)],
            Title = dr[nameof(Position.Title)].ToString()
        };

        public void CreatePosition(Position position)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(TitleParam, position.Title);
                    SqlParameter idPosition = new SqlParameter(IdPositionParam, SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(idPosition);
                    cmd.ExecuteNonQuery();
                    position.IDPosition = (int)idPosition.Value;
                }
            }
        }

        public void DeletePosition(Position position)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(IdPositionParam, position.IDPosition);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePosition(Position position)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(TitleParam, position.Title);
                    cmd.Parameters.AddWithValue(IdPositionParam, position.IDPosition);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
