using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RangSystem.ViewModel
{
    class ControlViewModel: DependencyObject
    {
       

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(ControlViewModel), new PropertyMetadata(null));
        public ControlViewModel(ObservableCollection <Data.IntermediateControl> controlList)
        {
            Items = System.Windows.Data.CollectionViewSource.GetDefaultView(controlList);
        }

    }
}
