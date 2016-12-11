using System.Collections.Generic;
using Android.App;
using Android.Media;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace XamarinAndroidSupportWidgets
{
    [Activity(Label = "XamarinAndroidSupportWidgets", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private DrawerLayout _drawerLayout;
        private CoordinatorLayout _coordinatorLayout;
        private AppBarLayout _appBarLayout;
        private Toolbar _toolbar;
        private TabLayout _tabLayout;
        private ViewPager _viewPager;
        private FloatingActionButton _floatingActionButton;
        private NavigationView _navigationView;

        public string[] _titles;
        private List<Fragment> _fragments;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            InitViews();
            InitData();
            ConfigViews();
        }

        private void InitViews()
        {
            _drawerLayout = FindViewById<DrawerLayout>(Resource.Id.id_drawerlayout);
            _coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.id_coordinatorlayout);
            _appBarLayout = FindViewById<AppBarLayout>(Resource.Id.id_appbarlayout);
            _toolbar = FindViewById<Toolbar>(Resource.Id.id_toolbar);
            _tabLayout = FindViewById<TabLayout>(Resource.Id.id_tablayout);
            _viewPager = FindViewById<ViewPager>(Resource.Id.id_viewpager);
            _floatingActionButton = FindViewById<FloatingActionButton>(Resource.Id.id_floatingactionbutton);
            _navigationView = FindViewById<NavigationView>(Resource.Id.id_navigationview);
        }

        private void InitData()
        {
            // tab titles defined in res/values/arrays.xml
            _titles = Resources.GetStringArray(Resource.Array.tab_titles);

            _fragments = new List<Fragment>();
            int index = 0;
            foreach (var title in _titles)
            {
                var bundle = new Bundle();
                bundle.PutInt("flag", index++);
                //var fragment = new MyFragment();
            }
        }

        private void ConfigViews()
        {
            SetSupportActionBar(_toolbar);

            var drawerToggle = new ActionBarDrawerToggle(
                activity:this,
                drawerLayout:_drawerLayout,
                toolbar:_toolbar,
                openDrawerContentDescRes: Resource.String.open,
                closeDrawerContentDescRes:Resource.String.close);
            drawerToggle.SyncState();
            _drawerLayout.SetDrawerListener(drawerToggle);

            _navigationView.InflateHeaderView(Resource.Layout.header_nav);
        }
    }
}

