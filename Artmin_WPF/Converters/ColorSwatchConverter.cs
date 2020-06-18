using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using MaterialDesignColors.Recommended;

namespace Artmin_WPF.Converters
{
    public class ColorSwatchConverter : IValueConverter
    {
        private static readonly Dictionary<string, SolidColorBrush> Brushes = new Dictionary<string, SolidColorBrush>
        {
            { "Red",        new SolidColorBrush { Color = RedSwatch.Red500 } },
            { "Pink",       new SolidColorBrush { Color = PinkSwatch.Pink500 } },
            { "Purple",     new SolidColorBrush { Color = PurpleSwatch.Purple500 } },
            { "DeepPurple", new SolidColorBrush { Color = DeepPurpleSwatch.DeepPurple500 } },
            { "Indigo",     new SolidColorBrush { Color = IndigoSwatch.Indigo500 } },
            { "Blue",       new SolidColorBrush { Color = BlueSwatch.Blue500 } },
            { "LightBlue",  new SolidColorBrush { Color = LightBlueSwatch.LightBlue500 } },
            { "Cyan",       new SolidColorBrush { Color = CyanSwatch.Cyan500 } },
            { "Teal",       new SolidColorBrush { Color = TealSwatch.Teal500 } },
            { "Green",      new SolidColorBrush { Color = GreenSwatch.Green500 } },
            { "LightGreen", new SolidColorBrush { Color = LightGreenSwatch.LightGreen500 } },
            { "Lime",       new SolidColorBrush { Color = LimeSwatch.Lime500 } },
            { "Yellow",     new SolidColorBrush { Color = YellowSwatch.Yellow500 } },
            { "Amber",      new SolidColorBrush { Color = AmberSwatch.Amber500 } },
            { "Orange",     new SolidColorBrush { Color = OrangeSwatch.Orange500 } },
            { "DeepOrange", new SolidColorBrush { Color = DeepOrangeSwatch.DeepOrange500 } },
            { "Brown",      new SolidColorBrush { Color = BrownSwatch.Brown500 } },
            { "Grey",       new SolidColorBrush { Color = GreySwatch.Grey500 } },
            { "BlueGrey",   new SolidColorBrush { Color = BlueGreySwatch.BlueGrey500 } }
        };

        public static SolidColorBrush GetBrush(string name)
        {
            return Brushes.TryGetValue(name, out SolidColorBrush brush) ? brush : Brushes["Grey"];
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush brush = GetBrush(value as string);

            if (targetType == typeof(Color))
            {
                return brush.Color;
            }

            if (parameter is double opacity)
            {
                brush = brush.Clone();
                brush.Opacity = opacity;
            }

            return brush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
