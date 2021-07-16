using System;
using System.Collections.Generic;
using System.Linq;
using SimpleJSON;
using UnityEngine;
using ExitGames.Client.Photon;
namespace Xeres.Options
{
    public class SettingHandler : Photon.MonoBehaviour
    {
        public IEnumerable<Setting> settings;
        public Hashtable mainData;
        public void Start()
        {
            Settings.MainSettings setting = new Settings.MainSettings();
            setting.setUserData("ValuesToUse.txt");
            mainData = setting.userData;
            Console.WriteLine(mainData.ToStringFull());

            settings = getSettings();
            
            foreach(Setting thing in settings)
            {
                thing.setUserData(mainData[thing.name].ToString());
                Console.WriteLine(thing.userData.ToStringFull());
            }
        }
        private IEnumerable<Setting> getSettings()
        {
            //Got this implementation from a Stack Overflow post
            IEnumerable<Setting> exporters = typeof(Setting) //Exporters is IEnumerable of Command Types
                .Assembly.GetTypes() //Gets all Command type classes that are not abstract
                .Where(t => t.IsSubclassOf(typeof(Setting)) && !t.IsAbstract && !t.Name.Contains("MainS"))
                .Select(t => (Setting)Activator.CreateInstance(t)); //Creates an Instance of each Command  when it adds it to exporter
            return exporters;
        }

       
    }
}
