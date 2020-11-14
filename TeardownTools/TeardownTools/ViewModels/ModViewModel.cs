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
        private string name;
        private string shortDescription;
        private string description;
        private string warning;
        private bool isSRCProhibited;
        private bool isInstalled;
        private BitmapImage preview;


        // PROPERTIES
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string ShortDescription
        {
            get { return shortDescription; }
            set
            {
                if (shortDescription != value)
                {
                    shortDescription = value;
                    OnPropertyChanged("ShortDescription");
                }
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string Warning
        {
            get { return warning; }
            set
            {
                if (warning != value)
                {
                    warning = value;
                    OnPropertyChanged("Warning");
                }
            }
        }
        public bool IsSRCProhibited
        {
            get { return isSRCProhibited; }
            set
            {
                if (isSRCProhibited != value)
                {
                    isSRCProhibited = value;
                    OnPropertyChanged("IsSRCProhibited");
                }
            }
        }
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
        public BitmapImage Preview
        {
            get { return preview; }
            set
            {
                if (preview != value)
                {
                    preview = value;
                    OnPropertyChanged("Preview");
                }
            }
        }


        // CONSTRUCTORS
        public ModViewModel(string _name, string _shortDescription, string _description, bool _isSRCProhibited, bool _isInstalled, string _previewPath, UriKind _previewPathScope, string _warning)
        {
            Name = _name;
            ShortDescription = _shortDescription;
            Description = _description;
            IsSRCProhibited = _isSRCProhibited;
            IsInstalled = _isInstalled;
            Preview = new BitmapImage(new Uri(_previewPath, _previewPathScope));
            Warning = _warning;
        }
        public ModViewModel(string _name, string _shortDescription, string _description, bool _isSRCProhibited, bool _isInstalled, string _previewPath, UriKind _previewPathScope)
        {
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
