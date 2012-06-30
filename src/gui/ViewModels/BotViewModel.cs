using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HydraBot.Gui.ViewModels
{
    public class BotViewModel : PropertyChangedBase
    {
        private string _urlBox;
        public string UrlBox
        {
            get { return _urlBox; }
            private set
            {
                _urlBox = value;
                NotifyOfPropertyChange(() => UrlBox);
            }
        }

        public void Start(string name)
        {
            Bot hydraBot = new Bot();
            hydraBot.StartLocation(UrlBox);
            hydraBot.ProcessTasks();
        }
    }
}
