using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Widget;

namespace XamarinAndroidSupportWidgets.View
{
    public class RoundedImageView : ImageView
    {
        public RoundedImageView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        protected override void OnDraw(Canvas canvas)
        {
            var drawable = Drawable;

            if (Width == 0 || Height == 0)
                return;

            var b = ((BitmapDrawable) drawable).Bitmap;
            var bitmap = b.Copy(Bitmap.Config.Argb8888, true);

            var w = Width;
            var roundBitmap = GetCroppedBitmap(bitmap, w);
            canvas.DrawBitmap(roundBitmap, 0, 0, null);
        }

        private static Bitmap GetCroppedBitmap(Bitmap bitmap, int radius)
        {
            Bitmap sbmap = null;
            if (bitmap.Width != radius || bitmap.Height != radius)
            {
                sbmap = Bitmap.CreateScaledBitmap(bitmap, radius, radius, false);
            }
            else
            {
                sbmap = bitmap;
            }

            var output = Bitmap.CreateBitmap(sbmap.Width, sbmap.Height, Bitmap.Config.Argb8888);
            var canvas = new Canvas(output);

            var paint = new Paint
            {
                AntiAlias = true,
                FilterBitmap = true,
                Dither = true
            };
            var rect = new Rect(0, 0, sbmap.Width, sbmap.Height);
            canvas.DrawARGB(0, 0, 0, 0);
            paint.Color = Color.ParseColor("#BAB399");
            canvas.DrawCircle(sbmap.Width / 2 + 0.7f, sbmap.Height / 2 + 0.7f, sbmap.Width / 2 + 0.1f, paint);
            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.SrcIn));
            canvas.DrawBitmap(sbmap, rect, rect, paint);

            return output;
        }
    }
}
