// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Radish.ViewModels;

namespace Radish
{
    /// <summary>
    /// This is the View Locator class
    /// </summary>
    public class ViewLocator : IDataTemplate
    {
        /// <summary>
        /// Whether the view support recycling.
        /// </summary>
        public bool SupportsRecycling => false;

        /// <summary>
        /// Builds a new instance of the view model
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IControl Build(object data)
        {
            var name = data.GetType().FullName.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        /// <summary>
        /// Whether or not is is a view model base
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}