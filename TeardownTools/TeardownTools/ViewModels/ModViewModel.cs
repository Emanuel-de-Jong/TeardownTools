using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TeardownTools.ViewModels
{
    public class ModViewModel
    {
        private bool isInstalled;


        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Warning { get; set; }
        public bool IsSRCProhibited { get; set; }
        public bool IsInstalled
        {
            get
            {
                return isInstalled;
            }
            set
            {
                isInstalled = value;

                if (value)
                {
                    InstalledColor = "#FF36983F";
                }
                else
                {
                    InstalledColor = "#FFB83A3A";
                }
            }
        }
        public BitmapImage Preview { get; set; }
        public string InstalledColor { get; set; }


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

        public ModViewModel(int number)
        {
            Name = "Name " + number;
            ShortDescription = "Short description " + number + ".";
            Description = "Description " + number + ".";
            IsSRCProhibited = false;
            IsInstalled = false;
            Preview = new BitmapImage(new Uri(@"/images/placeholder.png", UriKind.Relative));
            Warning = string.Empty;
        }
    }
}
