using System;
using System.Reflection;
namespace UserPrefs.Properties
{
    class GasBurst : Property
    {
        private string ting;
        private string propertyName = "gasBurst";
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
                return "FX/boost_smoke";
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
