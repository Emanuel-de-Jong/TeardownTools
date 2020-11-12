using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TeardownTools.ViewModels
{
    public class ModViewModel
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Warning { get; set; }
        public bool IsInstalled { get; set; }
        public BitmapImage Preview { get; set; }

        public ModViewModel(string name, string shortDescription, string description, bool isInstalled, string previewPath, string warning)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            IsInstalled = isInstalled;
            Preview = new BitmapImage(new Uri(previewPath, UriKind.Absolute));
            Warning = warning;
        }

        public ModViewModel(string name, string shortDescription, string description, bool isInstalled, string previewPath)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            IsInstalled = isInstalled;
            Preview = new BitmapImage(new Uri(previewPath, UriKind.Absolute));
            Warning = string.Empty;
        }

        public ModViewModel(string name, string shortDescription, string description, string warning)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            IsInstalled = false;
            Preview = new BitmapImage(new Uri(@"/images/placeholder.png", UriKind.Relative));
            Warning = warning;
        }

        public ModViewModel(string name, string shortDescription, string description)
        {
            Name = name;
            ShortDescription = shortDescription;
            Description = description;
            IsInstalled = false;
            Preview = new BitmapImage(new Uri(@"/images/placeholder.png", UriKind.Relative));
            Warning = string.Empty;
        }

        public ModViewModel()
        {
            Name = "Name";
            ShortDescription = "Short description.";
            Description = "Description.";
            IsInstalled = false;
            Preview = new BitmapImage(new Uri(@"/images/placeholder.png", UriKind.Relative));
            Warning = string.Empty;
        }
    }
}
