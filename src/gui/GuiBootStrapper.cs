using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HydraBot.Gui.Tools;
using HydraBot.Gui.ViewModels;

namespace HydraBot.Gui
{
    public class GuiBootStrapper : AutofacBootstrapper<ShellViewModel>
    {
        // [AS] nothing extra for now. most work can be done in base.configure();
    }
}
