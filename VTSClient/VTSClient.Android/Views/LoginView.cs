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
using VTSClient.Android.Converters;
using Android.Graphics;

namespace VTSClient.Droid.Views
{
    [Activity(MainLauncher = false)]
    public class LoginView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LoginView);

            var loginViewLayout = FindViewById<LinearLayout>(Resource.Id.loginViewLayout);
            loginViewLayout.SetBackgroundResource(Resource.Drawable.Splash_bg);
            loginViewLayout.Background.SetAlpha(150); 
            loginViewLayout.SetPadding(100, 50, 100, 100);

            var set = this.CreateBindingSet<LoginView, LoginViewModel>();

            var isNotLoggedText = new TextView(ApplicationContext)
            {
                
            };
            var loginNameText = new EditText(ApplicationContext)
            {
                Hint = "Login name"
            };
            var passwordText = new EditText(ApplicationContext)
            {
                Hint = "Password"
            };
            var loginButton = new Button(ApplicationContext) { Text = "SIGN IN" };
            loginButton.SetBackgroundColor(Color.Argb(255, 59, 196, 214));

            set.Bind(isNotLoggedText).To(vm => vm.IsNotLoggedMessage);
            set.Bind(isNotLoggedText)
                .For(v => v.Visibility)
                .To(vm => vm.IsLoggedIn)
                .WithConversion(new InvertBoolToVisibilityConverter());
            set.Bind(loginNameText).To(vm => vm.LoginName);
            set.Bind(passwordText).To(vm => vm.Password);
            set.Bind(loginButton).To(vm => vm.LoginCommand);
            set.Apply();

            loginViewLayout.AddView(isNotLoggedText);
            loginViewLayout.AddView(loginNameText);
            loginViewLayout.AddView(passwordText);
            loginViewLayout.AddView(loginButton);
        }


        protected override void OnViewModelSet()
        {
            
        }
    }
}