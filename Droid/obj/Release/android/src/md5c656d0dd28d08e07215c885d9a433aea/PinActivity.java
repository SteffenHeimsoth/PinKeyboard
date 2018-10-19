package md5c656d0dd28d08e07215c885d9a433aea;


public class PinActivity
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer,
		android.widget.TextView.OnEditorActionListener,
		android.view.View.OnFocusChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onEditorAction:(Landroid/widget/TextView;ILandroid/view/KeyEvent;)Z:GetOnEditorAction_Landroid_widget_TextView_ILandroid_view_KeyEvent_Handler:Android.Widget.TextView/IOnEditorActionListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"n_onFocusChange:(Landroid/view/View;Z)V:GetOnFocusChange_Landroid_view_View_ZHandler:Android.Views.View/IOnFocusChangeListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("PinKeyboard.Droid.PinActivity, PinKeyboard.Droid", PinActivity.class, __md_methods);
	}


	public PinActivity ()
	{
		super ();
		if (getClass () == PinActivity.class)
			mono.android.TypeManager.Activate ("PinKeyboard.Droid.PinActivity, PinKeyboard.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onEditorAction (android.widget.TextView p0, int p1, android.view.KeyEvent p2)
	{
		return n_onEditorAction (p0, p1, p2);
	}

	private native boolean n_onEditorAction (android.widget.TextView p0, int p1, android.view.KeyEvent p2);


	public void onFocusChange (android.view.View p0, boolean p1)
	{
		n_onFocusChange (p0, p1);
	}

	private native void n_onFocusChange (android.view.View p0, boolean p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
