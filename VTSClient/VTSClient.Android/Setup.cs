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
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform.Converters;
using VTSClient.Android.Converters;

namespace VTSClient.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
        : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);
            registry.AddOrOverwrite("VacTypeToIcon", new VacTypeToIconConverter());
        }
    }
}