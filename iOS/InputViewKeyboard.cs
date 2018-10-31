//using System;
//using System.Linq;
//using UIKit;
//using Foundation;
//using ObjCRuntime;

//namespace PinKeyboard.iOS
//{
//    [Register("InputViewKeyboard")]
//    public partial class InputViewKeyboard : UIView
//    {
//        private const string BackspaceSelectorName = "deleteBackward";
//        private static readonly Selector BackspaceSelector = new Selector(BackspaceSelectorName);

//        public InputViewKeyboard()
//        {
//            Initialize();
//        }

//        public InputViewKeyboard(IntPtr p) : base(p)
//        {
//            Initialize();
//        }

//        public override void AwakeFromNib()
//        {
//            Initialize();
//        }

//        private void Initialize()
//        {
//            NSBundle.MainBundle.LoadNib("InputViewKeyboard", this, null);
//            AddSubview(TopView);
//            Bounds = TopView.Bounds;

//            //NSArray array = NSBundle.MainBundle.LoadNib("InputViewKeyboard", this, null);
//            //UIView view = Runtime.GetNSObject(array.ValueAt(0)) as UIView;
//            //AddSubview(view);
//            //Bounds = view.Bounds;

//            AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
//        }

//        public override void LayoutSubviews()
//        {
//            base.LayoutSubviews();

//            Console.WriteLine("{0}", this.Frame);
//        }

//        [Export("ReturnClicked")]
//        private void ReturnClicked()
//        {
//            Console.WriteLine("ReturnClicked");
//        }

//        [Export("BackspaceClicked")]
//        private void BackspaceClicked()
//        {
//            UIApplication.SharedApplication.SendAction(BackspaceSelector, null, this, null);
//        }

//        [Export("TextKeyClicked:")]
//        private void TextKeyClicked(UIButton button)
//        {
//            var firstResponder = ResponderUtils.GetFirstResponder() as UITextField;

//            if (firstResponder != null)
//            {
//                firstResponder.InsertText(button.Title(UIControlState.Normal));
//            }
//        }
//    }
//}

