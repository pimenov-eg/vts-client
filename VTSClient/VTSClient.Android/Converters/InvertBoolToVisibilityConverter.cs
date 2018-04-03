using Android.Views;
using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace VTSClient.Android.Converters
{
    public class InvertBoolToVisibilityConverter : MvxValueConverter<bool, ViewStates>
    {
        protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return value ? ViewStates.Invisible : ViewStates.Visible;
        }
    }
}