using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using ObjCRuntime;
using System.Collections.Generic;
using CoreGraphics;

namespace PinKeyboard.iOS

{

    public partial class CustomKeyBoard : UIView
    {
        private Random rng = new Random();
        private UIButton[] keyArray = new UIButton[12];

        public CustomKeyBoard (IntPtr handle) : base (handle)
        {
            Initalize();
        }
        public CustomKeyBoard (){
           
            Initalize();
        }


        private void Initalize()
        {

            NSBundle.MainBundle.LoadNib("CustomKeyBoardView", this, null);
   
            AddSubview(TopView);

            Bounds = TopView.Bounds;
            
            //AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

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
     
            TranslatesAutoresizingMaskIntoConstraints = false;
         
        }



        [Export ("TextKeyClicked:")]
        private void TextKeyClicked(UIButton sender){

            var firstResponder = ResponderUtils.GetFirstResponder() as UITextField;
            string key = sender.TitleLabel.Text;
            if (int.TryParse(key, out int result))
            {
                firstResponder.InsertText(key);
            }
            else if (sender == btn11)
            {
                firstResponder.DeleteBackward();
            }
            else if (sender == btn12)
            {
                firstResponder.EndEditing(true);
            }

        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
  
            StackView.Frame = Frame;
            StackView.Bounds = new CGRect(0, 0, Bounds.Width -10, 200);
            TopView.BackgroundColor = UIColor.FromRGB(201, 211, 217);


            Console.WriteLine("customkeyboard");
            Console.WriteLine("{0}", Frame);
            Console.WriteLine("{0}", Bounds);
        }


        private void RandomizeKeyboard()
        {
            List<int> numbers = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            Shuffle(numbers);

            for (int i = 0; i < 10; i++)
            {
                keyArray[i].SetTitle(numbers.IndexOf(i).ToString(), UIControlState.Normal);
                keyArray[i].TitleLabel.Text = numbers.IndexOf(i).ToString();


            }
            foreach (UIButton button in keyArray){

                button.BackgroundColor = UIColor.White;
                button.SetTitleColor(UIColor.Black, UIControlState.Normal);
                button.Font = UIFont.SystemFontOfSize(25);

                //rounded
                button.Layer.CornerRadius = 5;
                button.ClipsToBounds = true;

                // shadow
                button.Layer.MasksToBounds = false;
                button.Layer.ShadowColor = UIColor.Black.CGColor;
                button.Layer.ShadowOpacity = 1;
                button.Layer.ShadowRadius = 0;
                button.Layer.ShadowOffset = new CGSize(0, 0.5);
                                        
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