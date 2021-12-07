using PPPKProject_02_WPF_.Enumer;
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
    /// Interaction logic for EditPositionPage.xaml
    /// </summary>
    public partial class EditPositionPage : FramedPage
    {
        private readonly Position position;
        public EditPositionPage(PositionViewModel positionViewModel, Position position = null): base(positionViewModel)
        {
            InitializeComponent();
            this.position = position ?? new Position();
            DataContext = position;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e) => Frame.NavigationService.GoBack();

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                position.Title = TbTitle.Text.Trim();
                if (position.IDPosition == 0)
                {
                    PositionViewModel.Positions.Add(position);
                }
                else
                {
                    PositionViewModel.Update(position);
                }
                Frame.NavigationService.GoBack();
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainter.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()))
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
    }
}
