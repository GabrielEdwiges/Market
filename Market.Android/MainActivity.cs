﻿
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Naxam.Controls.Platform.Droid;

namespace Market.Droid
{
    [Activity(Label = "Market", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            //Customizações
            BottomTabbedRenderer.BackgroundColor = new Android.Graphics.Color(228, 229, 230);
            BottomTabbedRenderer.FontSize = 10;
            BottomTabbedRenderer.IconSize = 30;
            BottomTabbedRenderer.ItemSpacing = 5;
            BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(0);
            BottomTabbedRenderer.BottomBarHeight = 60;

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Messier16.Forms.Android.Controls.Messier16Controls.InitAll();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}