using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;

namespace XamarinAndroidSupportWidgets
{
    public class MyFragment: Fragment
    {
        private Android.Views.View _view;
        private SwipeRefreshLayout _swipeRefreshLayout;
        private RecyclerView _recyclerView;
        private RecyclerView.LayoutManager _layoutManager;
    }
}
