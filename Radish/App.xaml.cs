using Avalonia;
using Avalonia.Markup.Xaml;

namespace Radish
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}