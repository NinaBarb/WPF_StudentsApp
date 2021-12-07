using Microsoft.Win32;
using PPPKProject_02_WPF_.Enumer;
using PPPKProject_02_WPF_.Model;
using PPPKProject_02_WPF_.Utils;
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
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Person person;

        public EditPersonPage(PersonViewModel personViewModel, Person person = null) :base(personViewModel)
        {
            InitializeComponent();
            //cbPosition.ItemsSource = Enum.GetValues(typeof(Position)).Cast<Position>();
            this.person = person ?? new Person();
            DataContext = person;
            if (person != null)
            {
                RadioButton btn = GridContainter.Children.OfType<RadioButton>().FirstOrDefault(b => b.Content.Equals(person.Gender.ToString()));
                btn.IsChecked = true;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                person.Age = int.Parse(TbAge.Text.Trim());
                person.Email = TbEmail.Text.Trim();
                person.FirstName = TbFirstName.Text.Trim();
                person.LastName = TbLastName.Text.Trim();
                person.JMBAG = TbJMBAG.Text.Trim();
                var checkedButton = GridContainter.Children.OfType<RadioButton>().FirstOrDefault(r => (bool)r.IsChecked);
                person.Gender = (Gender)Enum.Parse(typeof(Gender), checkedButton.Content.ToString(), true); // case insensitive
                //person.Position = (Position)cbPosition.SelectedItem;
                person.Picture = ImageUtils.BitmapImageToByteArray(Picture.Source as BitmapImage);
                if (person.IDPerson == 0)
                {
                    PersonViewModel.People.Add(person);
                }
                else
                {
                    PersonViewModel.Update(person);
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
                    || ("Int".Equals(e.Tag) && !int.TryParse(e.Text, out int age))
                    || ("JMBAG".Equals(e.Tag) && !long.TryParse(e.Text, out long jmbag))
                    || ("Email".Equals(e.Tag) && !ValidationUtils.isValidEmail(TbEmail.Text.Trim())))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            //if (cbPosition.SelectedItem == null)
            //{
            //    AnimateTb(cbPosition);
            //    valid = false;
            //}
            if (TbJMBAG.Text.Length != 10)
            {
                TbJMBAG.Background = Brushes.LightCoral;
                valid = false;
            }
            if (Picture.Source == null)
            {
                PictureBorder.BorderBrush = Brushes.LightCoral;
                valid = false;
            }
            else
            {
                PictureBorder.BorderBrush = Brushes.WhiteSmoke;
            }
            return valid;
        }
        private void AnimateTb(ComboBox e)
        {
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 1);

            // Create a DoubleAnimation to fade the not selected option control
            DoubleAnimation animation = new DoubleAnimation();

            animation.From = 1.0;
            animation.To = 0.3;
            animation.Duration = new Duration(duration);
            animation.AutoReverse = true;
            animation.RepeatBehavior = new RepeatBehavior(2);
            // Configure the animation to target de property Opacity
            Storyboard.SetTargetName(animation, e.Name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(OpacityProperty));
            // Add the animation to the storyboard
            storyboard.Children.Add(animation);

            // Begin the storyboard
            storyboard.Begin(this);
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = Filter
            };
            if (openFileDialog.ShowDialog() == true)
            {
                Picture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
