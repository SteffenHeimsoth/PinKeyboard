
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace PinKeyboard.Droid
{


    public class PinKeyBoardFragment : Android.Support.V4.App.Fragment
    {

        private TextView[] keyArray = new TextView[12];
        private Random rng = new Random();
        private IOnKeyPressed mCallback;

        public interface IOnKeyPressed
        {
            Keycode OnKeyPressed(Keycode keycode);
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            try{
                mCallback = (IOnKeyPressed)context;
            }
            catch(ClassCastException e){
                throw new ClassCastException(context.ToString()
                    + " must implement IOnKeyPressed");
            }
                
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return inflater.Inflate(Resource.Layout.pinKeyBoard, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            keyArray[0] = View.FindViewById<TextView>(Resource.Id.tv1);
            keyArray[1] = View.FindViewById<TextView>(Resource.Id.tv2);
            keyArray[2] = View.FindViewById<TextView>(Resource.Id.tv3);
            keyArray[3] = View.FindViewById<TextView>(Resource.Id.tv4);
            keyArray[4] = View.FindViewById<TextView>(Resource.Id.tv5);
            keyArray[5] = View.FindViewById<TextView>(Resource.Id.tv6);
            keyArray[6] = View.FindViewById<TextView>(Resource.Id.tv7);
            keyArray[7] = View.FindViewById<TextView>(Resource.Id.tv8);
            keyArray[8] = View.FindViewById<TextView>(Resource.Id.tv9);
            keyArray[9] = View.FindViewById<TextView>(Resource.Id.tv0);
            keyArray[10] = View.FindViewById<TextView>(Resource.Id.tvBackspace);
            keyArray[11] = View.FindViewById<TextView>(Resource.Id.tvEnter);

            RandomizeKeyboard();
            initDelegates();

        }

        private void initDelegates()
        {
            for (int i = 0; i < 10;i++){
                int number;
                Keycode keycode;
                int.TryParse(keyArray[i].Text, out number);
                switch(number){
                    case 0: keycode = Keycode.Num0; break;
                    case 1: keycode = Keycode.Num1; break;
                    case 2: keycode = Keycode.Num2; break;
                    case 3: keycode = Keycode.Num3; break;
                    case 4: keycode = Keycode.Num4; break;
                    case 5: keycode = Keycode.Num5; break;
                    case 6: keycode = Keycode.Num6; break;
                    case 7: keycode = Keycode.Num7; break;
                    case 8: keycode = Keycode.Num8; break;
                    case 9: keycode = Keycode.Num9; break;
                    default: keycode = Keycode.Num0; break;
                }
            keyArray[i].Click += delegate {
                   
                mCallback.OnKeyPressed(keycode);
                };        
            }
            keyArray[10].Click += delegate {
                mCallback.OnKeyPressed(Keycode.Del);
            };
            keyArray[11].Click += delegate {
                mCallback.OnKeyPressed(Keycode.Enter);
            };

        }

        private void RandomizeKeyboard()
        {
            List<int> numbers = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Shuffle(numbers);

            for (int i = 0; i < 10;i++){

                keyArray[i].Text = numbers.ElementAt(i).ToString();
            }
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
 

        public static void DisableSoftInputFromAppearing(EditText editText)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                editText.ShowSoftInputOnFocus = false;
            }
            else
            {
                editText.SetTextIsSelectable(true);
            }
        }

    }


}
