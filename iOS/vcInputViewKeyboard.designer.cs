// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PinKeyboard.iOS
{
    //[Register ("CustomPinKeyboard")]
    partial class PinKeyboard
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView TopView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TopView != null) {
                TopView.Dispose ();
                TopView = null;
            }
        }
    }
}