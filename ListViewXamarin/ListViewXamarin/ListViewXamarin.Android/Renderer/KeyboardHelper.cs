using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
#if Android
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Views.InputMethods;
using ListViewXamarin.Droid;
#elif iOS
using ListViewXamarin.iOS;
using Xamarin.Forms.Internals;
using UIKit;
#endif

[assembly: Dependency(typeof(KeyboardHelper))]
#if Android
namespace ListViewXamarin.Droid 
#elif iOS
namespace ListViewXamarin.iOS 
#endif
{
    [Preserve(AllMembers = true)]
    public class KeyboardHelper : IKeyboardHelper
    {
        public KeyboardHelper()
        {

        }

#if Android
        static Context _context;

        public static void Init(Context context)
        {
            _context = context;
        }
#endif

        public void HideKeyboard()
        {
#if Android
            var inputMethodManager = _context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (inputMethodManager != null && _context is Activity) 
            { 
                var activity = _context as Activity; 
                var token = activity.CurrentFocus?.WindowToken; 
                inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None); 
                activity.Window.DecorView.ClearFocus(); 
            } 
#elif iOS
            UIApplication.SharedApplication.KeyWindow.EndEditing(true); 
#endif
        }
    }
} 