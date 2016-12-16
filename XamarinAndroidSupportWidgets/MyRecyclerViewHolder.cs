using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Widget;

namespace XamarinAndroidSupportWidgets
{
    public class MyRecyclerViewHolder : RecyclerView.ViewHolder
    {
        public MyRecyclerViewHolder(Android.Views.View itemView) : base(itemView)
        {
            ItemView = itemView.FindViewById<TextView>(Resource.Id.id_textview);
        }

        public string Text
        {
            set { ItemView.Text = value; }
            get { return ItemView.Text; }
        }

        public new TextView ItemView { get; }
    }
}