using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TeardownTools.ViewModels
{
    public class ModViewModel : INotifyPropertyChanged
    {
        // FIELDS
        private bool isInstalled;


        // PROPERTIES
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Warning { get; set; }
        public bool IsSRCProhibited { get; set; }
        public BitmapImage Preview { get; set; }
        public bool IsInstalled
        {
            get { return isInstalled; }
            set
            {
                if (isInstalled != value)
                {
                    isInstalled = value;
                    OnPropertyChanged("IsInstalled");
                }
            }
        }


        // CONSTRUCTORS
        public ModViewModel(int _id, string _name, string _shortDescription, string _description, bool _isSRCProhibited, bool _isInstalled, string _previewPath, UriKind _previewPathScope, string _warning)
        {
            Id = _id;
            Name = _name;
            ShortDescription = _shortDescription;
            Description = _description;
            IsSRCProhibited = _isSRCProhibited;
            IsInstalled = _isInstalled;
            Preview = new BitmapImage(new Uri(_previewPath, _previewPathScope));
            Warning = _warning;
        }
        public ModViewModel(int _id, string _name, string _shortDescription, string _description, bool _isSRCProhibited, bool _isInstalled, string _previewPath, UriKind _previewPathScope)
        {
            Id = _id;
            Name = _name;
            ShortDescription = _shortDescription;
            Description = _description;
            IsSRCProhibited = _isSRCProhibited;
            IsInstalled = _isInstalled;
            Preview = new BitmapImage(new Uri(_previewPath, _previewPathScope));
            Warning = string.Empty;
        }
        public ModViewModel()
        {
            Id = 0;
            Name = "Name";
            ShortDescription = "Short description.";
            Description = "Description.";
            IsSRCProhibited = false;
            IsInstalled = false;
            Preview = new BitmapImage(new Uri(@"/images/placeholder.png", UriKind.Relative));
            Warning = string.Empty;
        }


        // METHODS
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
