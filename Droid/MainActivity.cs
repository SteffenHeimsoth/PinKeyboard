using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Content.PM;
//using com.xign.util;
using System.IO;
using System.Security.Cryptography;
using Android.Views.Animations;
//using XignQR.Droid.Util;
//using com.xign;
using Android.Support.V4.Hardware.Fingerprint;
using System.Threading.Tasks;
using Android.Security.Keystore;
using Android.Telephony;
using Android.Content.Res;
using Android.Views.InputMethods;
using System.Threading;
using Android.Support.V4.View;


namespace PinKeyboard.Droid
{
    [Activity(Label = "PIN", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class PinActivity : AppCompatActivity, TextView.IOnEditorActionListener, View.IOnFocusChangeListener, PinKeyBoardFragment.IOnKeyPressed
    {

        private Button revokeButton;
        private Button button;
        private Button inputMaskButton;
        private EditText pinText;
        private EditText pinText2;
        private Android.App.AlertDialog dialog;

        private FingerprintManagerCompat fingerprintManager;
        private Android.App.AlertDialog fpDialog;
        private Android.Support.V4.OS.CancellationSignal cancellationSignal;
        private FingerprintManagerCompat.CryptoObject cryptoObject;
        private bool SkippedFp = false;
        private PinKeyBoardFragment pinKeyBoardFragment;
        private PinInputFragment pinInputFragment;
        private bool pinKeyFragmentVisible = false;

        int count = 1;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Pin);
            button = FindViewById<Button>(Resource.Id.button);
            revokeButton = FindViewById<Button>(Resource.Id.revokebutton);
            pinText = FindViewById<EditText>(Resource.Id.edittext);
            inputMaskButton = FindViewById<Button>(Resource.Id.button1);
            pinText2 = FindViewById<EditText>(Resource.Id.edittext1);
            //button.Click += delegate { Login(); };
            //revokeButton.Click += delegate { RevokePersonalizationQuestion(); };
            revokeButton.Visibility = ViewStates.Gone;

            //Animate();

            pinInputFragment = new PinInputFragment();
            pinKeyBoardFragment = new PinKeyBoardFragment();
         

            PinKeyBoardFragment.DisableSoftInputFromAppearing(pinText);
            PinKeyBoardFragment.DisableSoftInputFromAppearing(pinText2);
            pinText.OnFocusChangeListener = this;
            pinText2.OnFocusChangeListener = this;
            pinKeyFragmentVisible = true;

            inputMaskButton.Click += delegate
            {
                openPinInputFrag();
            };

           
        }

        internal void FragmentButtonClicked(string text)
        {
            Toast.MakeText(this, text, ToastLength.Short).Show();
            if (String.Compare(text, "123456") == 0)
            {
                Toast.MakeText(this, "Correct", ToastLength.Short).Show();

                RunOnUiThread(() =>
                {
                    var transaction = SupportFragmentManager.BeginTransaction();
                    transaction.Remove(pinInputFragment);
                    transaction.AddToBackStack(null).Commit();
                });
    

            }
        }

        public bool OnEditorAction(TextView v, [GeneratedEnum] ImeAction actionId, KeyEvent e)
        {
            throw new NotImplementedException();
        }


        private void openPinInputFrag(){
            SupportFragmentManager.BeginTransaction()
            .Replace(Resource.Id.rlforfrag, pinInputFragment, "PINFRAGMENT")
            .AddToBackStack(null)
            .Commit();
            SupportFragmentManager.ExecutePendingTransactions();
        }
        public void OnFocusChange(View v, bool hasFocus)
        {
            if (hasFocus && v.GetType() == typeof(Android.Support.V7.Widget.AppCompatEditText))
            {
                pinKeyFragmentVisible = true;
                SupportFragmentManager.BeginTransaction()
                            .Replace(Resource.Id.rlforfrag, pinKeyBoardFragment, "PINKEYBOARDFRAGMENT")
                            .Commit();
                SupportFragmentManager.ExecutePendingTransactions();
            }
            else
            {
                RunOnUiThread(() =>
                {
                    var transaction = SupportFragmentManager.BeginTransaction();
                    transaction.Remove(pinKeyBoardFragment);
                    transaction.Commit();

                    SupportFragmentManager.ExecutePendingTransactions();
                                    
                });
                pinKeyFragmentVisible = false;
            }
        }

        public Keycode OnKeyPressed(Keycode keycode)
        {
            if(CurrentFocus.GetType() == typeof(Android.Support.V7.Widget.AppCompatEditText)){
                CurrentFocus.DispatchKeyEvent(new KeyEvent(KeyEventActions.Down, keycode));
                CurrentFocus.DispatchKeyEvent(new KeyEvent(KeyEventActions.Up, keycode));
                if (keycode == Keycode.Enter)
                {
                    CurrentFocus.ClearFocus();
                }
            }
            return keycode;
        }
    }
}

