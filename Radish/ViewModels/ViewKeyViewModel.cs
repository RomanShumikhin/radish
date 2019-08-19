using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Radish.Interfaces;
using Radish.Models;
using ReactiveUI;
using Splat;

namespace Radish.ViewModels
{
    public class ViewKeyViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis utility.
        /// </summary>
        private readonly IRedisUtils _redisConn;

        public KeyListItem SelectedKeyValue { get; set; }

        private string _selectedTextValue;

        public string SelectedTextValue
        {
            get => _selectedTextValue;
            set => this.RaiseAndSetIfChanged(ref _selectedTextValue, value);
        }

        public ViewKeyViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.KeySelected += KeySelected;
        }

        private void KeySelected(object sender, EventArgs e)
        {
            Console.WriteLine("Selected Key");
            this.SelectedKeyValue = (KeyListItem)sender;
            this.SelectedTextValue = this.SelectedKeyValue.KeyValue;
            Console.WriteLine("Selected Key: " + this.SelectedKeyValue.KeyName);
            Console.WriteLine("Selected Value: " + this.SelectedKeyValue.KeyValue);
        }
    }
}