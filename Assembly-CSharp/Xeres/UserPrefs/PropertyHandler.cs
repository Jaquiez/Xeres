using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
namespace Xeres.UserPrefs
{
    public class PropertyHandler : Photon.MonoBehaviour
    {
        public ExitGames.Client.Photon.Hashtable XeresPropeties = new ExitGames.Client.Photon.Hashtable();
        public  IEnumerable<Property> xerProps;
        public PropertyHandler instance;
        public void Start()
        {
            xerProps = getCommandList();
            setProperties();
        }
        public static IEnumerable<Property> getCommandList()
        {
            //Got this implementation from a Stack Overflow post
            IEnumerable<Property> exporters = typeof(Property) //Exporters is IEnumerable of Command Types
                .Assembly.GetTypes() //Gets all Command type classes that are not abstract
                .Where(t => t.IsSubclassOf(typeof(Property)) && !t.IsAbstract)
                .Select(t => (Property)Activator.CreateInstance(t)); //Creates an Instance of each Command  when it adds it to exporter
            return exporters;
        }
        public void setProperties() 
        {
            //Slightly less ugly code but not good yet, There might be a better way to do this but I don't know
            string[] properties = File.ReadAllLines(System.Environment.CurrentDirectory+@"/Preferences.txt");
            ArgumentException badValue = new ArgumentException();
            foreach (Property prop in xerProps)
            {
                for(int k=0; k<properties.Length;k++)
                {
                    string key = properties[k].Substring(0, properties[k].IndexOf("="));
                    if (prop.name.Equals(key))
                    {
                        Object value = properties[k].Substring(1 + properties[k].IndexOf("="))!="" ? properties[k].Substring(1 + properties[k].IndexOf("=")):null;
                        try
                        {
                            if (value == null)
                            {
                                throw badValue;
                            }
                            if (!XeresPropeties.ContainsKey(prop.name))
                                XeresPropeties.Add(prop.name, Convert.ChangeType(value, prop.type));
                            else
                                XeresPropeties[prop.name] = Convert.ChangeType(value, prop.type);
                        }
                        catch (Exception err)
                        {
                            if (!XeresPropeties.ContainsKey(prop.name))
                                XeresPropeties.Add(prop.name, prop.defaultValue);
                            else
                                XeresPropeties[prop.name] = prop.defaultValue;
                            continue;
                        }
                    }
                }                                                       
            }
            Console.WriteLine(XeresPropeties);
        }
        public void loadProperties()
        {
            ExitGames.Client.Photon.Hashtable propsToChange = new ExitGames.Client.Photon.Hashtable();
            foreach (DictionaryEntry pair in XeresPropeties)
            {
                if (PhotonNetwork.player.customProperties.ContainsKey(pair.Key))
                {
                    propsToChange.Add(pair.Key, pair.Value);
                }
            }
            PhotonNetwork.player.SetCustomProperties(propsToChange);
        }
    }
}
