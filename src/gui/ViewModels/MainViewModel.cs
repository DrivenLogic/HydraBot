using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HydraBot.Gui.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        readonly IWindowManager _windowManager;

        public MainViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        private string _name;
        private string _helloString;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                //NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public string OutputBox
        {
            get { return _helloString; }
            private set
            {
                _helloString = value;
                NotifyOfPropertyChange(() => OutputBox);
            }
        }

        //public bool CanSayHello
        //{
        //    get { return !string.IsNullOrWhiteSpace(Name); }
        //}

        public void Start(string name)
        {
            OutputBox = "fark it";

            _windowManager.ShowWindow(new BotViewModel(), "Modeless"); // convention malarkey here

        }
    }
}
