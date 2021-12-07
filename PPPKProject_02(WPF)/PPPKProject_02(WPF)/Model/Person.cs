using PPPKProject_02_WPF_.Enumer;
using PPPKProject_02_WPF_.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PPPKProject_02_WPF_.Model
{
    public class Person
    {
        public int IDPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string JMBAG { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PositionTitle { get; set; }
        public Position Position { get; set; }
        public byte[] Picture { get; set; }
        public BitmapImage Image
        {
            get => ImageUtils.ByteArrayToBitmapImage(Picture);
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
