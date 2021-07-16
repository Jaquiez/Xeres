using System;
using System.Reflection;
namespace UserPrefs.Properties
{
    class ItalicsChat : Property
    {
        private bool ting;
        private string propertyName = "chatItalics";
        public override Type type
        {
            get
            {
                return typeof(bool);
            }
        }
        public override Object defaultValue
        {
            get
            {
                return false;
            }
            set
            {
                ting = Convert.ToBoolean(value);
            }
        }
        public override string name
        {
            get { return propertyName; }
        }
    }
}
