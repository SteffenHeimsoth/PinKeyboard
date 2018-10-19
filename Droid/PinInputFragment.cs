using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace PinKeyboard.Droid
{
    public class PinInputFragment : Android.Support.V4.App.Fragment
    {
        TextView t1;
        TextView t2;
        TextView t3;
        TextView t4;
        TextView t5;
        TextView t6;
        TextView t7;
        TextView t8;
        TextView t9;
        TextView t0;
        TextView BackSpace;
        List<ImageView> ivDigitList = new List<ImageView>();
        ImageView iv1, iv2, iv3, iv4, iv5, iv6;
        Drawable dEmptyDigit;
        Drawable dFullDigit;
        TextView pw;
        //Button button;

        private Random rng = new Random();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.materialKeyboard, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            t1 = view.FindViewById<TextView>(Resource.Id.t1);
            t2 = view.FindViewById<TextView>(Resource.Id.t2);
            t3 = view.FindViewById<TextView>(Resource.Id.t3);
            t4 = view.FindViewById<TextView>(Resource.Id.t4);
            t5 = view.FindViewById<TextView>(Resource.Id.t5);
            t6 = view.FindViewById<TextView>(Resource.Id.t6);
            t7 = view.FindViewById<TextView>(Resource.Id.t7);
            t8 = view.FindViewById<TextView>(Resource.Id.t8);
            t9 = view.FindViewById<TextView>(Resource.Id.t9);
            t0 = view.FindViewById<TextView>(Resource.Id.t0);
            iv1 = view.FindViewById<ImageView>(Resource.Id.iv1);
            iv2 = view.FindViewById<ImageView>(Resource.Id.iv2);
            iv3 = view.FindViewById<ImageView>(Resource.Id.iv3);
            iv4 = view.FindViewById<ImageView>(Resource.Id.iv4);
            iv5 = view.FindViewById<ImageView>(Resource.Id.iv5);
            iv6 = view.FindViewById<ImageView>(Resource.Id.iv6);
            ivDigitList.Add(iv1);
            ivDigitList.Add(iv2);
            ivDigitList.Add(iv3);
            ivDigitList.Add(iv4);
            ivDigitList.Add(iv5);
            ivDigitList.Add(iv6);

            dEmptyDigit = Activity.GetDrawable(Resource.Drawable.emptyDigit);
            dFullDigit = Activity.GetDrawable(Resource.Drawable.fullDigit);
            //var font = Typeface.CreateFromAsset(((PinActivity)Activity).Assets, "Roboto-Thin.ttf");
            //t1.Typeface = font;
            //t2.Typeface = font;
            //t3.Typeface = font;
            //t4.Typeface = font;
            //t5.Typeface = font;
            //t6.Typeface = font;
            //t7.Typeface = font;
            //t8.Typeface = font;
            //t9.Typeface = font;
            //t0.Typeface = font;
            BackSpace = view.FindViewById<TextView>(Resource.Id.Backspace);

            pw = view.FindViewById<TextView>(Resource.Id.pw);

            pw.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                drawDigits(pw.Text.Length);
                if (pw.Text.Length >= 6){
                    // add interface to main activity to send pin
                    ((PinActivity)Activity).FragmentButtonClicked(pw.Text);
                    pw.Text = "";
                   
                }
            
            };

            RandomizeKeyboard();

            //button = view.FindViewById<Button>(Resource.Id.button);
            //button.Click += delegate
            //{
            //    if (Activity is PinActivity)
            //    {
            //        PinActivity pinActivity = (PinActivity)Activity;
            //        pinActivity.FragmentButtonClicked(pw.Text);
            //    }
            //};

            t1.Click += delegate
            {
                pw.Text += t1.Text;
            };

            t2.Click += delegate
            {
                pw.Text += t2.Text;
            };
            t3.Click += delegate
            {
                pw.Text += t3.Text;
            };
            t4.Click += delegate
            {
                pw.Text += t4.Text;
            };
            t5.Click += delegate
            {
                pw.Text += t5.Text;
            };
            t6.Click += delegate
            {
                pw.Text += t6.Text;
            };
            t7.Click += delegate
            {
                pw.Text += t7.Text;
            };
            t8.Click += delegate
            {
                pw.Text += t8.Text;
            };
            t9.Click += delegate
            {
                pw.Text += t9.Text;
            };
            t0.Click += delegate
            {
                pw.Text += t0.Text;
            };
            BackSpace.Click += delegate
            {
                if (pw.Text.Length > 0)
                {
                    pw.Text = pw.Text.Remove(pw.Text.Length - 1);
                }
            };


        }

        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void drawDigits(int textLength){
            for (int i = 0; i < ivDigitList.Count; i++)
            {
                if (textLength > i)
                {
                    ivDigitList.ElementAt(i).SetImageDrawable(dFullDigit);
                } else {
                    ivDigitList.ElementAt(i).SetImageDrawable(dEmptyDigit);
                }   
            }
            //if(textLength > 0){
            //    iv1.SetImageDrawable(
            //}
        }

        private void RandomizeKeyboard()
        {
            List<int> numbers = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Shuffle(numbers);

            t1.Text = numbers.ElementAt(0).ToString();
            t2.Text = numbers.ElementAt(1).ToString();
            t3.Text = numbers.ElementAt(2).ToString();
            t4.Text = numbers.ElementAt(3).ToString();
            t5.Text = numbers.ElementAt(4).ToString();
            t6.Text = numbers.ElementAt(5).ToString();
            t7.Text = numbers.ElementAt(6).ToString();
            t8.Text = numbers.ElementAt(7).ToString();
            t9.Text = numbers.ElementAt(8).ToString();
            t0.Text = numbers.ElementAt(9).ToString();
        }
    }
}