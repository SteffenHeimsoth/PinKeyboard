using System;

using UIKit;

namespace PinKeyboard.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", count++);
                Button.SetTitle(title, UIControlState.Normal);
            };
            CustomKeyBoard customKeyBoard = new CustomKeyBoard();
            //customKeyBoard.Bounds = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, 400);
            tfPin.InputView = customKeyBoard;
            tfpin2.InputView = customKeyBoard;

        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);


        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);



            Console.WriteLine("controller");
            Console.WriteLine("{0}", TopView.Frame);

        }

        

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            //tfPin.InputView.Frame = TopView.Frame;
    
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

      
    
    
    
    }
       
}
