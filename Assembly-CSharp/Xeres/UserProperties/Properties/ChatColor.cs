using System;
using System.Reflection;
namespace UserPrefs.Properties
{
    class ChatColor : Property
    {
        private string ting;
        private string propertyName = "chatColor";
        public override Type type
        {
            get
            {
                return typeof(string);
            }
        }
        public override Object defaultValue
        {
            get
            {
                return "";
            }
            set
            {
                ting = Convert.ToString(value);
            }
        }
        public override string name
        {
            get { return propertyName; }
        }
    }
}
