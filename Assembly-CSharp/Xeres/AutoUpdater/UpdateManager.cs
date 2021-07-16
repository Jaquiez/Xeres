using UnityEngine;
using System.IO;
using System.Collections;
using System;
using System.Net;
using System.ComponentModel;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace Xeres.AutoUpdater
{
    public class UpdateManager : MonoBehaviour
    {
        public static UpdateStatus status;
        private string localVersion;
        private static string gameZip;
        public void Start()
        {
            localVersion = File.ReadAllText(Application.dataPath + @"/Version.txt");
            status = UpdateStatus.Checking;
            gameZip = Environment.CurrentDirectory + @"\XeresUpdate.zip";
            /*
            if(!checkForInternetConnect())
            {
                status = UpdateStatus.Updated;
            }
            Console.WriteLine("STATUS " + status);*/

            StartCoroutine(checkVersion());
        }
        private IEnumerator checkVersion()
        {
            WWW onlineVersion = new WWW("https://www.dropbox.com/s/d4xaxlwtp7ued0k/Version.txt?dl=1");
            yield return onlineVersion;
            if (localVersion.Equals(onlineVersion.text))
            {
                status = UpdateStatus.Updated;
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.PreferenceSetter>();
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.MainMenuButtons>();
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.Title>();
                GameObject.Destroy(GameObject.Find("updater"));
            }
            else
            {
                status = UpdateStatus.Updating;
                ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;
                downloadUpdate();
            }

        }
        private static void installUpdate(object sender, AsyncCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                status = UpdateStatus.Failed;
                Console.WriteLine(e);
                return;
            }
            if (e.Error != null)
            {
                Console.WriteLine("An error occured when downloading" + e.Error);
                status = UpdateStatus.Failed;
                return;
            }
            ZipConstants.DefaultCodePage = System.Text.Encoding.UTF8.CodePage;
            ZipFile file = new ZipFile(gameZip);
            foreach (ZipEntry entry in file)
            {
                if (entry.Name.Contains("Data") && !entry.Name.Contains("Config") && !entry.Name.Contains("dll") && !entry.Name.Contains("output") && !entry.Name.Contains(".assets") && !entry.Name.Contains(@"/Resources/unity")|| entry.Name.Contains("Assembly"))
                {
                    if (!entry.IsDirectory)
                    {
                        Console.WriteLine(entry.Name);
                        Stream stream = file.GetInputStream(entry);
                        FileStream streamWriter = new FileStream(Path.Combine(Environment.CurrentDirectory, entry.Name),
                                       FileMode.OpenOrCreate,
                                       FileAccess.ReadWrite,
                                       FileShare.None);//File.Create(Path.Combine(Environment.CurrentDirectory, entry.Name);
                        if(!File.Exists(Path.Combine(Environment.CurrentDirectory, entry.Name)))
                        {
                            File.Create(Path.Combine(Environment.CurrentDirectory, entry.Name));
                        }
                        StreamUtils.Copy(stream, streamWriter, new byte[4096]);

                    }
                }
            }
            status = UpdateStatus.NeedRestart;
        }
        private static void downloadUpdate()
        {
            try
            {
                WebClient client = new WebClient();
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(installUpdate);
                client.DownloadFileAsync(new Uri("https://www.dropbox.com/s/igzejamuxu2ynbe/Xeres.zip?dl=1"),gameZip);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        //Got this from Unity forum post, you need to validate your request properly if you are gonna use a web client in Unity for some reason. Not entirely sure why but it makes it work so I'll take it ...
        public static bool MyRemoteCertificateValidationCallback(System.Object sender,
    X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            bool isOk = true;
            // If there are errors in the certificate chain,
            // look at each error to determine the cause.
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                for (int i = 0; i < chain.ChainStatus.Length; i++)
                {
                    if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                    {
                        continue;
                    }
                    chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                    chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                    chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                    chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                    bool chainIsValid = chain.Build((X509Certificate2)certificate);
                    if (!chainIsValid)
                    {
                        isOk = false;
                        break;
                    }
                }
            }
            return isOk;
        }
        public static bool checkForInternetConnect()
        {
            try
            {
                Ping ping = new Ping("https://github.com/Jaquiez");
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
