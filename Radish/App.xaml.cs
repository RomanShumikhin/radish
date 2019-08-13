using Avalonia;
using Avalonia.Markup.Xaml;

namespace Radish
{
    /// <summary>
    /// The app class.
    /// </summary>
    public class App : Application
    {
        /// <summary>
        /// Initializing the App.
        /// </summary>
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}