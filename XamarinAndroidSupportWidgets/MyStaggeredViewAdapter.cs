using System;
using System.Collections.Generic;
using Android.Content;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Math = Java.Lang.Math;

namespace XamarinAndroidSupportWidgets
{
    public class MyStaggeredViewAdapter : RecyclerView.Adapter
    {
        private Context _context;
        private List<string> _datas;
        private List<int> _heights;
        private LayoutInflater _layoutInflater;

        public MyStaggeredViewAdapter(Context context)
        {
            _context = context;
            _layoutInflater = LayoutInflater.From(_context);
            _datas = new List<string>();
            _heights = new List<int>();

            var rand = new Random();
            for (int i = 'A'; i <= 'z'; ++i)
            {
                _datas.Add($"{(char)i}");
                _heights.Add(rand.Next(200, 500));
            }

        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var myHolder = holder as MyRecyclerViewHolder;
            var layoutParams = myHolder.ItemView.LayoutParameters;
            layoutParams.Height = _heights[position];
            myHolder.ItemView.LayoutParameters = layoutParams;
            myHolder.ItemView.Text = _datas[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = _layoutInflater.Inflate(Resource.Layout.item_main, parent, false);
            var viewHolder = new MyRecyclerViewHolder(view);
            return viewHolder;
        }

        public override int ItemCount => _datas.Count;

        public void PushFront(dynamic o)
        {
            _datas.Insert(0, (string)o.value);
            _heights.Insert(0, (int)o.height);
        }
    }
}