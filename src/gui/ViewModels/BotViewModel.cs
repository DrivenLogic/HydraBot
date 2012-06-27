﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace HydraBot.Gui.ViewModels
{
    public class BotViewModel : Screen
    {
        public BotViewModel()
        {
            
        }

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
    }
}
