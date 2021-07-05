using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Xeres.Tools
{
    public class XeresScoreboard
{
        public static void sortPlayerList()
        {
            string newPlayerList = "";
            //Check each player in the playerlists specific values then assign them to the playerlist string

            foreach (PhotonPlayer player in PhotonNetwork.playerList)
            {
                if (FengGameManagerMKII.ignoreList.Contains(player.ID))
                {
                    newPlayerList += "[ff0000] IGNORED [-]";
                }
                /*
                if (FengGameManagerMKII.muteList.Contains(player.ID))
                {
                    newPlayerList += "[ff0000] MUTED [-]";
                }*/
                newPlayerList += "[ffffff]|[075285]" + RCextensions.returnIntFromObject(player.ID) + "[ffffff]" + "| ";
                string team = "H | ";
                if (RCextensions.returnIntFromObject(player.customProperties[PhotonPlayerProperty.team]) == 2) { team = "[ff0000]A [-]| "; }
                if (RCextensions.returnIntFromObject(player.customProperties[PhotonPlayerProperty.isTitan]) == 2) { team = "[e3923b]T [-]| "; }
                if (RCextensions.returnBoolFromObject(player.customProperties[PhotonPlayerProperty.dead]))
                {
                    team = "[ff0000]*dead* [-]| " + team;
                }
                if (RCextensions.returnBoolFromObject(player.isMasterClient))
                {
                    team += "[095c13]MC [-]| ";
                }

                newPlayerList += team;
                newPlayerList += RCextensions.returnStringFromObject(player.customProperties[PhotonPlayerProperty.name]) + "[ffffff] | ";
                newPlayerList += RCextensions.returnIntFromObject(player.customProperties[PhotonPlayerProperty.kills]) + " | ";
                newPlayerList += RCextensions.returnIntFromObject(player.customProperties[PhotonPlayerProperty.deaths]) + " | ";
                newPlayerList += RCextensions.returnIntFromObject(player.customProperties[PhotonPlayerProperty.max_dmg]) + " | ";
                string modProp = showModProperties(player.customProperties);
                newPlayerList += RCextensions.returnIntFromObject(player.customProperties[PhotonPlayerProperty.total_dmg]) + " | " + modProp + "\n[-]";
            }
            FengGameManagerMKII.instance.playerList = newPlayerList;
        }
        public static string showModProperties(ExitGames.Client.Photon.Hashtable props)
        {
            //Checks for custom keys in mod props that are associated with specific mods
            if (props.ContainsKey("Xeres"))
            {
                string mod = "";
                mod += "[000000] ~| Xeres |~ [-]" ;
                if (props.ContainsKey("infGas"))
                {
                    if (RCextensions.returnBoolFromObject(props["infGas"]) == true) { mod += "[00ff00] G[-]"; }
                    else if (RCextensions.returnBoolFromObject(props["infGas"]) == false) { mod += "[ff0000] G[-]"; }
                    else { mod += "[ffffff] G?[-]"; }
                }
                else { mod += " G?"; }
                if (props.ContainsKey("infBlades"))
                {
                    if (RCextensions.returnBoolFromObject(props["infBlades"]) == true) { mod += " [00ff00] B[-]"; }
                    else if (RCextensions.returnBoolFromObject(props["infBlades"]) == false) { mod += " [ff0000] B[-]"; }
                    else { mod += " [ffffff] B?[-]"; }
                }
                if (props.ContainsKey("infAHSS"))
                {
                    if (RCextensions.returnBoolFromObject(props["infAHSS"]) == true) { mod += " [00ff00] A[-]"; }
                    else if (RCextensions.returnBoolFromObject(props["infAHSS"]) == false) { mod += " [ff0000] A[-]"; }
                    else { mod += " [ffffff] A?[-]"; }
                }
                else { mod += "G?"; }
                return mod;
            }
            if(props.ContainsKey("CheBurroDondeDejasteLasCebollas"))
            {
                return "[000000] Kaizo";
            }
            if (props.ContainsKey("GuardianMod"))
            {
                return "[00ff00][ Gaurdian ][ffffff]";
            }
            if (props.ContainsKey("DiscipleMod"))
            {
                return "[000000][ D[-][1f1f1f]i[-][3f3f3f]s[-][5f5f5f]c[-][7f7f7f]i[-][9f9f9f]p[-][bfbfbf]l[-][dfdfdf]e[-][ffffff] ][-]";
            }
            if (props.ContainsKey("Ignis"))
            {
                return "[00ff00][ Ignis ][ffffff]";
            }
            if (props.ContainsKey("ExpMod") || props.ContainsKey("EMID"))
            {
                return "[00ff00][ EXP ][ffffff]";
            }
            if (props.ContainsKey("ZMOD"))
            {
                //Courtesy of Disciple AKA Mr. Lurkin
                string mod = "";
                mod += "[59117d][ ZMOD([ffffff] Inf: ";
                if (props.ContainsKey("infGas"))
                {
                    if (RCextensions.returnBoolFromObject(props["infGas"]) == true) { mod += "[00ff00] G[-]"; }
                    else if (RCextensions.returnBoolFromObject(props["infGas"]) == false) { mod += "[ff0000] G[-]"; }
                    else { mod += "[ffffff] G?[-]"; }
                }
                else { mod += " G?"; }
                if (props.ContainsKey("infBlades"))
                {
                    if (RCextensions.returnBoolFromObject(props["infBlades"]) == true) { mod += " [00ff00] B[-]"; }
                    else if (RCextensions.returnBoolFromObject(props["infBlades"]) == false) { mod += " [ff0000] B[-]"; }
                    else { mod += " [ffffff] B?[-]"; }
                }
                if (props.ContainsKey("infAHSS"))
                {
                    if (RCextensions.returnBoolFromObject(props["infAHSS"]) == true) { mod += " [00ff00] A[-]"; }
                    else if (RCextensions.returnBoolFromObject(props["infAHSS"]) == false) { mod += " [ff0000] A[-]"; }
                    else { mod += " [ffffff] A?[-]"; }
                }
                else { mod += "G?"; }
                return mod;
            }
            if (props.ContainsKey("coins"))
            {
                return "[aa00ee][ Universe ][-]";
            }
            if (props.ContainsKey("AnarchyFlags"))
            {
                return "[0aafee][ Anarchy ][-]";
            }
            if (props.ContainsKey("PBModRC"))
            {
                return "[aa55dd][ PB-RC ][-]";
            }
            if (props.ContainsKey("RCteam"))
            {
                return "[9999FF][ RC ]";
            }
            return "[ Vanilla ]";
        }
    }
}
