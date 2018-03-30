using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;

namespace VTSClient.Droid
{
    [Activity(Label = "VTSClient", MainLauncher = false, NoHistory = true, Icon = "@mipmap/icon")]
    public class MainActivity : MvxSplashScreenActivity
    {
        public MainActivity()
            : base(Resource.Drawable.Splash_bg)
        {

        }
    }
}
