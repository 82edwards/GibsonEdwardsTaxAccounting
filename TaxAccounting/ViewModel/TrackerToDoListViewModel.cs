using System.Collections.Generic;
using TrackerModel;

namespace TaxAccounting.ViewModel
{
    public class TrackerToDoListViewModel
    {
        public IEnumerable<TrackerItem> ToDoList {
            get { return TrackerItem.GetOpenItems(); }
        }
    }
}