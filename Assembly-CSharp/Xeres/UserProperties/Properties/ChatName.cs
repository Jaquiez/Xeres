using System;
using System.Reflection;
namespace UserPrefs.Properties
{
    class ChatName : Property
    {
        private string ting;
        private string propertyName = "chatName";
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
                return  FengGameManagerMKII.instance.name;
            }
            set
            {
                ting = RCextensions.returnStringFromObject(value).hexColor();
            }
        }
        public override string name
        {
            get { return propertyName; }
        }
    }
}
