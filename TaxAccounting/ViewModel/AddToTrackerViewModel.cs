using System.Collections.Generic;
using System.Web.Mvc;
using TrackerModel;

namespace TaxAccounting.ViewModel
{
    public class AddToTrackerViewModel
    {
        #region Properties
        public TrackerItem TrackerItem { get; set; }
        #endregion

        public SelectList CompleteTaskSelectList
        {
            get
            {
                return new SelectList(new Dictionary<int, string>
                {
                    {1, "Item 1"}, 
                    {2, "Item 2"}, 
                    {3, "Item 3"}
                });
            }
        }
    }
}