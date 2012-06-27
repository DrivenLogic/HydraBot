using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using HydraBot.Gui.ViewModels;

namespace HydraBot.Gui
{
    public class ShellViewModel : Screen
    {
        readonly IWindowManager _windowManager;

        public ShellViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        public void OpenModeless()
        {
            var result = _windowManager.ShowDialog(new BotViewModel());
            //_windowManager.ShowWindow(new BotViewModel(), "Modeless");
        }
    }
}
