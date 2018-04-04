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
using MvvmCross.Binding.Droid.Views;

namespace VTSClient.Droid.Views
{
    [Activity(MainLauncher = false)]
    public class VacListView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.VacListView);

            var vacListLayout = FindViewById<LinearLayout>(Resource.Id.vacListViewLayout);
            vacListLayout.SetBackgroundColor(Color.White);

            //var set = this.CreateBindingSet<VacListView, VacListViewModel>();
            //
            //var vacationRequests = new MvxListView(ApplicationContext,);
            //
            //set.Bind(vacationRequests).To(vm => vm.VacationRequests);
            //set.Apply();
            //
            //vacListLayout.AddView(vacationRequests);
        }


        protected override void OnViewModelSet()
        {
            
        }
    }
}