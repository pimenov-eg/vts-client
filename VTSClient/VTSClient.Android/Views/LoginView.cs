using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Core;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using VTSClient.ViewModels;
using VTSClient.Converters;

namespace VTSClient.Droid.Views
{
    [Activity(Label = "Login", MainLauncher = false)]
    public class LoginView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginView);

            var test = FindViewById<LinearLayout>(Resource.Id.myViewController);
            test.SetBackgroundResource(Resource.Drawable.Splash_bg);

            var isLoggedLabel = new TextView(ApplicationContext);
            isLoggedLabel.Text = "IsLogged";
            test.AddView(isLoggedLabel);

            var isLogged = new EditText(ApplicationContext);

            var bindingSet = this.CreateBindingSet<LoginView, LoginViewModel>();
            
            bindingSet
                .Bind(isLogged)
                .To(vm => vm.IsNotificatinMessageVisible)
                .WithConversion(new BoolToStringConverter());
            
            bindingSet.Apply();

            test.AddView(isLogged);


        }


        protected override void OnViewModelSet()
        {
            
        }
    }
}