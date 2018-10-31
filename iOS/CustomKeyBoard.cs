using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using ObjCRuntime;
using System.Collections.Generic;

namespace PinKeyboard.iOS

{
    public partial class CustomKeyBoard : UIView
    {
        private IOnKeyPressed mCallback;
        private Random rng = new Random();
        private UIButton[] keyArray = new UIButton[12];

        public interface IOnKeyPressed
        {
            string OnKeyPressed(string key);
        }



        public CustomKeyBoard (IntPtr handle) : base (handle)
        {
            Initalize();
        }
        public CustomKeyBoard (){
           
            Initalize();
        }

        [Export("awakeFromNib")]
        public override void  AwakeFromNib()
        {
        //    keyArray.SetValue(btn1, 0);
        //    keyArray.SetValue(btn2, 1);
        //    keyArray.SetValue(btn3, 2);
        //    keyArray.SetValue(btn4, 3);
        //    keyArray.SetValue(btn5, 4);
        //    keyArray.SetValue(btn6, 5);
        //    keyArray.SetValue(btn7, 6);
        //    keyArray.SetValue(btn8, 7);
        //    keyArray.SetValue(btn9, 8);
        //    keyArray.SetValue(btn10, 9);
        //    keyArray.SetValue(btn11, 10);
        //    keyArray.SetValue(btn12, 11);

        //    RandomizeKeyboard();
        }



        private void Initalize()
        {
            NSBundle.MainBundle.LoadNib("CustomKeyBoardView", this, null);
            AddSubview(TopView);

            Bounds = TopView.Bounds;

            AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

            keyArray.SetValue(btn1, 0);
            keyArray.SetValue(btn2, 1);
            keyArray.SetValue(btn3, 2);
            keyArray.SetValue(btn4, 3);
            keyArray.SetValue(btn5, 4);
            keyArray.SetValue(btn6, 5);
            keyArray.SetValue(btn7, 6);
            keyArray.SetValue(btn8, 7);
            keyArray.SetValue(btn9, 8);
            keyArray.SetValue(btn10, 9);
            keyArray.SetValue(btn11, 10);
            keyArray.SetValue(btn12, 11);

            RandomizeKeyboard();
        
    }

        private void RandomizeKeyboard()
        {
            List<int> numbers = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Shuffle(numbers);

            for (int i = 0; i < 10; i++)
            {
                //keyArray[i].SetTitle(numbers.IndexOf(i).ToString(), UIControlState.Normal);
                //keyArray[i].TitleLabel.Text = numbers.IndexOf(i).ToString();

                //keyArray[i].Font = UIFont.SystemFontOfSize(35);
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



    }
}