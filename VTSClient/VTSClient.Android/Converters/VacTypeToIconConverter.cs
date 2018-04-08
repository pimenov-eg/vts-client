using MvvmCross.Platform.Converters;
using System;
using System.Globalization;
using VTSClient.Services.VTSService.Entities;

namespace VTSClient.Android.Converters
{
    public class VacTypeToIconConverter : MvxValueConverter<VacationType, int>
    {
        protected override int Convert(VacationType value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case VacationType.Regular:
                    return Droid.Resource.Mipmap.Icon_Request_Green;
                case VacationType.Sick:
                    return Droid.Resource.Mipmap.Icon_Request_Plum;
                case VacationType.Undefined:
                case VacationType.Exceptional:
                case VacationType.LeaveWithoutPay:
                    return Droid.Resource.Mipmap.Icon_Request_Gray;
                case VacationType.Overtime:
                    return Droid.Resource.Mipmap.Icon_Request_Blue;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }
    }
}