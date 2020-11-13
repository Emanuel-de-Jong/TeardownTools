using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeardownTools.ViewModels;

namespace TeardownTools.Templates
{
    public class ModViewModelTemplate
    {
        public ObservableCollection<ModViewModel> ModViewModels
        {
            get
            {
                return new ObservableCollection<ModViewModel>()
                    {
                        new ModViewModel("Remove Splash",
                            "Remove the splash at the start of the game.",
                            "Remove the logo and warning message during the launch of the game.", false, false,
                            @"images\placeholder.png", UriKind.Relative),
                        new ModViewModel("Show Speedometer",
                            "Display your velocity on the screen.",
                            "Display your x, y and z velocity at the top left of the screen during gameplay.", true, true,
                            @"images\placeholder.png", UriKind.Relative,
                            "Not allowed in runs because of SRC regulations.")
                    };
            }
        }

        public ModViewModel Details
        {
            get
            {
                return ModViewModels[0];
            }
        }
    }
}
