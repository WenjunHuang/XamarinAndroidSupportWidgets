using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace XamarinAndroidSupportWidgets
{
    public class MyFragment : Fragment, SwipeRefreshLayout.IOnRefreshListener
    {
        private Android.Views.View _view;
        private SwipeRefreshLayout _swipeRefreshLayout;
        private RecyclerView _recyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private MyRecyclerViewAdapter _recyclerViewAdapter;
        private MyStaggeredViewAdapter _staggeredAdapter;

        private const int VerticalList = 0;
        private const int HorizontalList = 1;
        private const int VerticalGrid = 2;
        private const int HorizontalGrid = 3;
        private const int StaggeredGrid = 4;
        private const int SpanCount = 4;

        private int _flag = 0;

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container,
            Bundle savedInstanceState)
        {
            _view = inflater.Inflate(Resource.Layout.frag_main, container, false);
            return _view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            _swipeRefreshLayout = _view.FindViewById<SwipeRefreshLayout>(Resource.Id.id_swiperefreshlayout);
            _recyclerView = _view.FindViewById<RecyclerView>(Resource.Id.id_recyclereview);

            _flag = (int) Arguments.Get("flag");
            ConfigRecyclerView();

            // 刷新时，指示器旋转后变化的颜色
            _swipeRefreshLayout.SetColorSchemeResources(Resource.Color.main_blue_light,
                Resource.Color.main_blue_dark);
            _swipeRefreshLayout.SetOnRefreshListener(this);
        }

        private void ConfigRecyclerView()
        {
            switch (_flag)
            {
                case VerticalList:
                    _layoutManager = new LinearLayoutManager(Activity,
                        LinearLayoutManager.Vertical, false);
                    break;
                case HorizontalList:
                    _layoutManager = new LinearLayoutManager(
                        Activity, LinearLayoutManager.Horizontal, false);
                    break;
                case VerticalGrid:
                    _layoutManager = new GridLayoutManager(Activity,
                        SpanCount, GridLayoutManager.Vertical, false);
                    break;
                case HorizontalGrid:
                    _layoutManager = new GridLayoutManager(Activity,
                        SpanCount, GridLayoutManager.Horizontal, false);
                    break;
                case StaggeredGrid:
                    _layoutManager = new StaggeredGridLayoutManager(SpanCount, StaggeredGridLayoutManager.Vertical);
                    break;
            }

            if (_flag != StaggeredGrid)
            {
                _recyclerViewAdapter = new MyRecyclerViewAdapter(Activity);
                _recyclerView.SetAdapter(_recyclerViewAdapter);
            }
            else
            {
                _staggeredAdapter = new MyStaggeredViewAdapter(Activity);
                _recyclerView.SetAdapter(_staggeredAdapter);
            }

            _recyclerView.SetLayoutManager(_layoutManager);
        }

        public void OnRefresh()
        {
            Task.Delay(TimeSpan.FromSeconds(1))
                .ContinueWith(t =>
                {
                    _swipeRefreshLayout.Refreshing = false;
                    var rand = new Random();
                    var temp = rand.Next(10);

                    if (_flag != StaggeredGrid)
                    {
                        _recyclerViewAdapter.PushFront($"new{temp}");
                        _recyclerViewAdapter.NotifyDataSetChanged();
                    }
                    else
                    {
                        _staggeredAdapter.PushFront(new {value = $"new{temp}", height = rand.Next(200, 500)});
                        _staggeredAdapter.NotifyDataSetChanged();
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}