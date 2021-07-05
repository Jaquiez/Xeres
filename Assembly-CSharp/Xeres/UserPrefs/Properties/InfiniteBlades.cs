using System;
using System.Reflection;
namespace UserPrefs.Properties
{
    class InfiniteBlades : Property
    {
        private bool ting;
        private string propertyName = "infBlades";
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
