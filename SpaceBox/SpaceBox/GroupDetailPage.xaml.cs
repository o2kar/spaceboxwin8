using SpaceBox.Data;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage für die Seite "Gruppendetails" ist unter http://go.microsoft.com/fwlink/?LinkId=234229 dokumentiert.

namespace SpaceBox
{
    /// <summary>
    /// Eine Seite, auf der eine Übersicht über eine einzelne Gruppe einschließlich einer Vorschau der Elemente
    /// in der Gruppe angezeigt wird.
    /// </summary>
    public sealed partial class GroupDetailPage : SpaceBox.Common.LayoutAwarePage
    {
        public GroupDetailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            var group = SampleDataSource.GetGroup((String)navigationParameter);
            this.DefaultViewModel["Group"] = group;
            this.DefaultViewModel["Items"] = group.Items;
        }

        /// <summary>
        /// Wird aufgerufen, wenn auf ein Element geklickt wird.
        /// </summary>
        /// <param name="sender">GridView (oder ListView, wenn die Anwendung angedockt ist),
        /// die das angeklickte Element anzeigt.</param>
        /// <param name="e">Ereignisdaten, die das angeklickte Element beschreiben.</param>
        void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigieren Sie zur entsprechenden Zielseite, und konfigurieren Sie die neue Seite,
            // indem Sie die erforderlichen Informationen als Navigationsparameter übergeben.
            var itemId = ((SampleDataItem)e.ClickedItem).UniqueId;
            this.Frame.Navigate(typeof(ItemDetailPage), itemId);
        }
    }
}
