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

namespace AndroidTelecomSample.Droid
{
    [Activity(Label = "OnCallActivity")]
    public class OnCallActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.OnCallActivity);
        }

        protected override void OnStart()
        {
            base.OnStart();

            OnBackPressed();
        }
    }
}