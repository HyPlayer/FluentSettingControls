using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;

namespace FluentSettingControls
{
    public partial class CornerRadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is CornerRadius cornerRadius)
            {
                return new CornerRadius(0, 0, cornerRadius.BottomRight, cornerRadius.BottomLeft);
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
