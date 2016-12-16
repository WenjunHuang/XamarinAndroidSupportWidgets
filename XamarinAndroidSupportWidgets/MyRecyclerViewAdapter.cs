using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace XamarinAndroidSupportWidgets
{
    public class MyRecyclerViewAdapter : RecyclerView.Adapter
    {
        private Context _context;
        private List<string> _datas;
        private LayoutInflater _layoutInflater;

        public MyRecyclerViewAdapter(Context context)
        {
            _context = context;
            _layoutInflater = LayoutInflater.From(_context);
            _datas = new List<string>();
            for (int i = 'A'; i <= 'z'; ++i)
            {
                _datas.Add($"{(char) i}");
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var myHolder = holder as MyRecyclerViewHolder;
            if (position >= 0 && position < _datas.Count && myHolder != null)
                myHolder.Text = _datas[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = _layoutInflater.Inflate(Resource.Layout.item_main, parent, false);
            var viewHolder = new MyRecyclerViewHolder(view);
            return viewHolder;
        }

        public void PushFront(string newItem)
        {
            _datas.Insert(0, newItem);
        }
        

        public override int ItemCount => _datas.Count;
    }
}