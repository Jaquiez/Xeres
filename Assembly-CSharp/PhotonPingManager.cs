//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using ExitGames.Client.Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PhotonPingManager
{
    public static int Attempts = 5;
    public static bool IgnoreInitialAttempt = true;
    public static int MaxMilliseconsPerPing = 800;
    private int PingsRunning;
    public bool UseNative;

    [DebuggerHidden]
    public IEnumerator PingSocket(Region region)
    {
        return new PingSocketcIteratorB { region = region, Sregion = region, fthis = this };
    }

    public static string ResolveHost(string hostName)
    {
        try
        {
            IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
            if (hostAddresses.Length == 1)
            {
                return hostAddresses[0].ToString();
            }
            for (int i = 0; i < hostAddresses.Length; i++)
            {
                IPAddress address = hostAddresses[i];
                if (address != null)
                {
                    string str2 = address.ToString();
                    if (str2.IndexOf('.') >= 0)
                    {
                        return str2;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            UnityEngine.Debug.Log("Exception caught! " + exception.Source + " Message: " + exception.Message);
        }
        return string.Empty;
    }

    public Region BestRegion
    {
        get
        {
            Region region = null;
            int ping = 0x7fffffff;
            foreach (Region region2 in PhotonNetwork.networkingPeer.AvailableRegions)
            {
                UnityEngine.Debug.Log("BestRegion checks region: " + region2);
                if ((region2.Ping != 0) && (region2.Ping < ping))
                {
                    ping = region2.Ping;
                    region = region2;
                }
            }
            return region;
        }
    }

    public bool Done
    {
        get
        {
            return (this.PingsRunning == 0);
        }
    }

    [CompilerGenerated]
    private sealed class PingSocketcIteratorB : IEnumerator, IDisposable, IEnumerator<object>
    {
        internal object Scurrent;
        internal int SPC;
        internal Region Sregion;
        internal PhotonPingManager fthis;
        internal string cleanIpOfRegion3;
        internal Exception e8;
        internal int i5;
        internal int indexOfColon4;
        internal bool overtime6;
        internal PhotonPing ping0;
        internal int replyCount2;
        internal int rtt9;
        internal float rttSum1;
        internal Stopwatch sw7;
        internal Region region;

        [DebuggerHidden]
        public void Dispose()
        {
            this.SPC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.SPC;
            this.SPC = -1;
            switch (num)
            {
                case 0:
                    this.region.Ping = PhotonPingManager.Attempts * PhotonPingManager.MaxMilliseconsPerPing;
                    this.fthis.PingsRunning++;
                    if (PhotonHandler.PingImplementation != typeof(PingNativeDynamic))
                    {
                        this.ping0 = (PhotonPing) Activator.CreateInstance(PhotonHandler.PingImplementation);
                        break;
                    }
                    UnityEngine.Debug.Log("Using constructor for new PingNativeDynamic()");
                    this.ping0 = new PingNativeDynamic();
                    break;

                case 1:
                    //goto Label_01B9;

                case 2:
                    //goto Label_0265;

                case 3:
                    this.SPC = -1;
                    goto Label_02B0;

                default:
                    goto Label_02B0;
            }
            this.rttSum1 = 0f;
            this.replyCount2 = 0;
            this.cleanIpOfRegion3 = this.region.HostAndPort;
            this.indexOfColon4 = this.cleanIpOfRegion3.LastIndexOf(':');
            if (this.indexOfColon4 > 1)
            {
                this.cleanIpOfRegion3 = this.cleanIpOfRegion3.Substring(0, this.indexOfColon4);
            }
            this.cleanIpOfRegion3 = PhotonPingManager.ResolveHost(this.cleanIpOfRegion3);
            this.i5 = 0;
            while (this.i5 < PhotonPingManager.Attempts)
            {
                this.overtime6 = false;
                this.sw7 = new Stopwatch();
                this.sw7.Start();
                try
                {
                    this.ping0.StartPing(this.cleanIpOfRegion3);
                }
                catch (Exception exception)
                {
                    this.e8 = exception;
                    UnityEngine.Debug.Log("catched: " + this.e8);
                    this.fthis.PingsRunning--;
                    break;
                }
            Label_01B9:
                while (!this.ping0.Done())
                {
                    if (this.sw7.ElapsedMilliseconds >= PhotonPingManager.MaxMilliseconsPerPing)
                    {
                        this.overtime6 = true;
                        break;
                    }
                    this.Scurrent = 0;
                    this.SPC = 1;
                    goto Label_02B2;
                }
                this.rtt9 = (int) this.sw7.ElapsedMilliseconds;
                if ((!PhotonPingManager.IgnoreInitialAttempt || (this.i5 != 0)) && (this.ping0.Successful && !this.overtime6))
                {
                    this.rttSum1 += this.rtt9;
                    this.replyCount2++;
                    this.region.Ping = (int) (this.rttSum1 / ((float) this.replyCount2));
                }
                this.Scurrent = new WaitForSeconds(0.1f);
                this.SPC = 2;
                goto Label_02B2;
            Label_0265:
                this.i5++;
            }
            this.fthis.PingsRunning--;
            this.Scurrent = null;
            this.SPC = 3;
            goto Label_02B2;
        Label_02B0:
            return false;
        Label_02B2:
            return true;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.Scurrent;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.Scurrent;
            }
        }
    }
}

