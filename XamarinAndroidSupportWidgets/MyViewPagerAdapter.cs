using System.Collections.Generic;
using Android.Support.V4.App;
using Java.Lang;

namespace XamarinAndroidSupportWidgets
{
    public class MyViewPagerAdapter : FragmentStatePagerAdapter
    {
        private string[] _titles;
        private List<Fragment> _fragments;

        public MyViewPagerAdapter(FragmentManager fm,
            string[] titles,
            List<Fragment> fragments ) : base(fm)
        {
            _titles = titles;
            _fragments = fragments;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(_titles[position]);
        }

        public override int Count => _fragments.Count;

        public override Fragment GetItem(int position)
        {
            return _fragments[position];
        }
    }
}