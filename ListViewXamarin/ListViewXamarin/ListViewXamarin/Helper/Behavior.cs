using Syncfusion.DataSource.Extensions;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    #region Behavior
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields
        SfListView ListView;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = bindable.FindByName<SfListView>("listView");
            ListView.ScrollStateChanged += ListView_ScrollStateChanged;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView.ScrollStateChanged -= ListView_ScrollStateChanged;
            ListView = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion

        #region Call back
        private void ListView_ScrollStateChanged(object sender, ScrollStateChangedEventArgs e)
        {
            if (e.ScrollState != ScrollState.Idle)
            {
                DependencyService.Get<IKeyboardHelper>().HideKeyboard();
            }
        }
        #endregion
    }
    #endregion

    #region IKeyboardHelper

    public interface IKeyboardHelper
    {
        void HideKeyboard();
    }
    #endregion
}