using System.Reflection;
using System.Windows.Forms;

namespace HomeEditor.Rules {
    /// <summary>
    /// Holds a <see cref="PropertyInfo"/> in a <see cref="ComboBox"/>, while displaying its name.
    /// </summary>
    struct PropertyInfoListItem {
        public PropertyInfo item;
        public PropertyInfoListItem(PropertyInfo item) => this.item = item;
        public override string ToString() => item != null ? item.Name : "None";
    }

    /// <summary>
    /// Holds a <see cref="PropertyInfo"/> in a <see cref="ComboBox"/>, while displaying its name.
    /// </summary>
    struct RoomListItem {
        public Room item;
        public RoomListItem(Room item) => this.item = item;
        public override string ToString() => item != null ? item.Name : "None";
    }
}