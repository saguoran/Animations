using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Animations.DataModels;
using Animations.Services;

namespace Animations.DataBindingModel
{
    public class TitleDetailMode:INotifyPropertyChanged
    {
        private ObservableCollection<Product> allProducts = ProductService.GetAllProduct();
        List<string> titles = null;
        public ObservableCollection<Product> AllProducts {
            get => allProducts;
            set {
                if (allProducts == value) return;
                allProducts = value;
                onPropertyChanged(nameof(AllProducts));
            } }
        public ObservableCollection<string> Descriptions
        {
            get =>new ObservableCollection<string>(allProducts.Select(p=>p.Description));
        }
        public ObservableCollection<long> Ids
        {
            get => new ObservableCollection<long>(allProducts.Select(p => p.Id));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void onPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
