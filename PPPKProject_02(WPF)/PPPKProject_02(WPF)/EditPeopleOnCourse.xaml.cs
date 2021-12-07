using PPPKProject_02_WPF_.Enumer;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPPKProject_02_WPF_
{
    /// <summary>
    /// Interaction logic for EditPeopleOnCourse.xaml
    /// </summary>
    public partial class EditPeopleOnCourse : FramedPage
    {
        private readonly Person person;
        public EditPeopleOnCourse(PersonCourseViewModel personCourseViewModel, Person person = null) :base(personCourseViewModel)
        {
            InitializeComponent();
            CbPeople.ItemsSource = personCourseViewModel.AllPeople;
            cbPosition.ItemsSource = personCourseViewModel.Positions;
            this.person = person ?? new Person();
            DataContext = person;
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                person.IDPerson = (CbPeople.SelectedItem as Person).IDPerson;
                person.FirstName = (CbPeople.SelectedItem as Person).FirstName;
                person.LastName = (CbPeople.SelectedItem as Person).LastName;
                person.PositionTitle = cbPosition.SelectedItem.ToString();
                person.Position = (Position)cbPosition.SelectedItem;
                PersonCourseViewModel.PeopleOnCourse.Add(person);
                Frame.NavigationService.GoBack(); 
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<ComboBox>().ToList().ForEach(e =>
            {
                if (e.SelectedItem == null)
                {
                    Storyboard storyboard = new Storyboard();
                    TimeSpan duration = new TimeSpan(0, 0, 1);

                    // Create a DoubleAnimation to fade the not selected option control
                    DoubleAnimation animation = new DoubleAnimation();

                    animation.From = 1.0;
                    animation.To = 0.3;
                    animation.Duration = new Duration(duration);
                    animation.AutoReverse = true;
                    animation.RepeatBehavior= new RepeatBehavior(2);
                    // Configure the animation to target de property Opacity
                    Storyboard.SetTargetName(animation, e.Name);
                    Storyboard.SetTargetProperty(animation, new PropertyPath(OpacityProperty));
                    // Add the animation to the storyboard
                    storyboard.Children.Add(animation);

                    // Begin the storyboard
                    storyboard.Begin(this);
                    valid = false;
                }
            });

            return valid;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();
    }
}
