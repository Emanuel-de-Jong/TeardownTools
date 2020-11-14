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
                        new ModViewModel("Timer",
                            "Display your in-game time on the screen.",
                            "Display your setup time at the top right of the screen during gameplay. Can be toggled off in the gameplay menu.", false, false,
                            @"images\placeholder.png", UriKind.Relative),
                        new ModViewModel("Remove Quickload Restriction",
                            "Quickload any old quicksave.",
                            "Lets you quickload any previously made quicksave. Make a copy of Documents/Teardown/quicksave.bin and rename it back later, to make multiple saves.", false, false,
                            @"images\placeholder.png", UriKind.Relative,
                            "Only quickload on the same map as you made the quicksave on."),
                        new ModViewModel("Menubutton Protection",
                            "Dangerous menubuttons need to be double pressed.",
                            "The gameplay menubuttons: restart, abandon and quickload have to be pressed twice to activate.", false, false,
                            @"images\placeholder.png", UriKind.Relative),
                        new ModViewModel("Menubutton Protection Advanced",
                            "Confirm window for dangerous menubuttons.",
                            "A Confirm window for the gameplay menubuttons: restart, abandon and quickload. Can be toggled off untill the next start of the game.", false, false,
                            @"images\placeholder.png", UriKind.Relative),
                        new ModViewModel("Speedometer",
                            "Display your velocity on the screen.",
                            "Display your total velocity at the top left of the screen during gameplay.", true, false,
                            @"images\placeholder.png", UriKind.Relative),
                        new ModViewModel("Speedometer Advanced",
                            "Display all your velocity parameters on the screen.",
                            "Display your x, y, z and total velocity at the top left of the screen during gameplay.", true, false,
                            @"images\placeholder.png", UriKind.Relative),
                        new ModViewModel("Remove Startscreens",
                            "Remove the startscreens when launching the game.",
                            "Remove the logo and warning message when launching the game.", false, false,
                            @"images\placeholder.png", UriKind.Relative),
                        new ModViewModel("Decrease Render Scale Slider",
                            "Decrease the minimum value of the Render Scale slider.",
                            "Decrease the minimum value of the Render Scale slider in the option menu to 25%.", false, false,
                            @"images\placeholder.png", UriKind.Relative),
                        new ModViewModel("Increase FOV Slider",
                            "Increase the maximum value of the FOV slider.",
                            "Increase the maximum value of the FOV slider in the option menu to 130.", true, false,
                            @"images\placeholder.png", UriKind.Relative),
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
