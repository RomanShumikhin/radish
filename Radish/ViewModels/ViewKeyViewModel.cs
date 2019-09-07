using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Radish.Interfaces;
using Radish.Models;
using ReactiveUI;
using Splat;

namespace Radish.ViewModels
{
    /// <summary>
    /// This is the view model for the key view.
    /// </summary>
    public class ViewKeyViewModel : ViewModelBase
    {
        /// <summary>
        /// The redis utility.
        /// </summary>
        private readonly IRedisUtils _redisConn;

        /// <summary>
        /// The seected key value.
        /// </summary>
        /// <value>The seected key value.</value>
        public KeyListItem SelectedKeyValue { get; set; }

        /// <summary>
        /// The selected text value.
        /// </summary>
        private string _selectedTextValue;

        /// <summary>
        /// The property on whether to allow the clicking of the buttons.
        /// </summary>
        /// <value>The property on whether to allow the clicking of the buttons.</value>
        private bool _isButtonEnabled = false;

        /// <summary>
        /// The selected text value property.
        /// </summary>
        /// <value>The selected text value.</value>
        public string SelectedTextValue
        {
            get => _selectedTextValue;
            set => this.RaiseAndSetIfChanged(ref _selectedTextValue, value);
        }

        /// <summary>
        /// The property on whether to allow the clicking of the buttons.
        /// </summary>
        /// <value>The property on whether to allow the clicking of the buttons.</value>
        public bool IsButtonEnabled 
        {
            get => _isButtonEnabled;
            set => this.RaiseAndSetIfChanged(ref _isButtonEnabled, value);
        }

        /// <summary>
        /// The constructor for the key view model.
        /// </summary>
        public ViewKeyViewModel()
        {
            _redisConn = Locator.Current.GetService<IRedisUtils>();
            _redisConn.KeySelected += KeySelected;
        }

        /// <summary>
        /// Fires when the key is selected.
        /// </summary>
        /// <param name="sender">The key list item.</param>
        /// <param name="e">The event args.</param>
        private void KeySelected(object sender, EventArgs e)
        {
            this.SelectedKeyValue = (KeyListItem)sender;
            this.SelectedTextValue = this.SelectedKeyValue.KeyValue;
            this.IsButtonEnabled = true;
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        private void OnUpdateValue()
        {
            _redisConn.UpdateStringKeyValue(this.SelectedKeyValue.KeyName, this.SelectedTextValue);
        }
    }
}