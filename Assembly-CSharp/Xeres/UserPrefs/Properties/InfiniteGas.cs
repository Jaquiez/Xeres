
using System;
using System.Reflection;
namespace UserPrefs.Properties
{
    class InfiniteGas : Property
    {
        private bool ting;
        private string propertyName = "infGas";
        public override Type type
        {
            get
            {
                return typeof(bool);
            }
        }
        public override Object defaultValue { 
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
