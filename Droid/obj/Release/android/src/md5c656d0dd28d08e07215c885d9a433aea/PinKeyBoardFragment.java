package md5c656d0dd28d08e07215c885d9a433aea;


public class PinKeyBoardFragment
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onAttach:(Landroid/content/Context;)V:GetOnAttach_Landroid_content_Context_Handler\n" +
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onViewCreated:(Landroid/view/View;Landroid/os/Bundle;)V:GetOnViewCreated_Landroid_view_View_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("PinKeyboard.Droid.PinKeyBoardFragment, PinKeyboard.Droid", PinKeyBoardFragment.class, __md_methods);
	}


	public PinKeyBoardFragment ()
	{
		super ();
		if (getClass () == PinKeyBoardFragment.class)
			mono.android.TypeManager.Activate ("PinKeyboard.Droid.PinKeyBoardFragment, PinKeyboard.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onAttach (android.content.Context p0)
	{
		n_onAttach (p0);
	}

	private native void n_onAttach (android.content.Context p0);


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onViewCreated (android.view.View p0, android.os.Bundle p1)
	{
		n_onViewCreated (p0, p1);
	}

	private native void n_onViewCreated (android.view.View p0, android.os.Bundle p1);

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
