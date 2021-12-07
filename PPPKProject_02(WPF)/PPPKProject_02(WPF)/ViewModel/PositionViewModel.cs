using PPPKProject_02_WPF_.Dal;
using PPPKProject_02_WPF_.Enumer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPKProject_02_WPF_.ViewModel
{
    public class PositionViewModel
    {
        public ObservableCollection<Position> Positions { get; }
        public PositionViewModel()
        {
            Positions = new ObservableCollection<Position>(RepositoryFactory.GetRepository().GetPositions());
            Positions.CollectionChanged += Positions_CollectionChanged; ;
        }

        private void Positions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory.GetRepository().CreatePosition(Positions[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory.GetRepository().DeletePosition(e.OldItems.OfType<Position>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory.GetRepository().UpdatePosition(e.NewItems.OfType<Position>().ToList()[0]);
                    break;
            }
        }

        internal void Update(Position position) => Positions[Positions.IndexOf(position)] = position;
    }
}
