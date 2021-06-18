
using System.Collections.ObjectModel;

namespace TelecomSoftwareTask.Model
{
    /// <summary>
    /// This Class makes declaration for Property of Name for generation of the Collection
    /// </summary>
    public class Name
    {
        public string IncommingName { get; set; }
        public string WholeChangedName { get; set; }
        public ObservableCollection<string> ParticalChangedName { get; set; } = new ObservableCollection<string>();
    }
}
