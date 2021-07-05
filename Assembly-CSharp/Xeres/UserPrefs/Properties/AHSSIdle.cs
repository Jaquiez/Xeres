using System;
using System.Reflection;
namespace UserPrefs.Properties
{
    class AHSSIdle : Property
    {
        private bool ting=false;
        private string propertyName = "AHSSIdle";
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
