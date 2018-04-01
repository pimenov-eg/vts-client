using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Views;

namespace VTSClient.Droid.Views
{
    [Activity(MainLauncher = true, NoHistory = true, Icon = "@mipmap/icon")]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
        public SplashScreenActivity()
            : base(Resource.Layout.SplashScreenView)
        {

        }
    }
}
