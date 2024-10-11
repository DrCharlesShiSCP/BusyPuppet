using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Net.Sockets;
using System.IO;
using UnityEngine.SceneManagement;

public class TwitchConnect : MonoBehaviour
{
    public UnityEvent<string, string> OnChatMessage;
    //public ShitpostTest shitpostTest;
    PuppetControl puppetControl;

    TcpClient Twitch;
    StreamReader Reader;
    StreamWriter Writer;

    const string URL = "irc.chat.twitch.tv";
    const int PORT = 6667;

    //put your twitch username here - make a new account for security reasons - i don't understand why but it's recommended
    string User = "busypuppet";

    //copy and paste OAuth from     twitchapps.com/tmi
    string OAuth = "oauth:pv37l0889bbimtcnd4il1iqv4cb63q";  //your OAuth is basically as good as a password, so you should make a new account before doing this

    //this is the channel you want to connect to
    string Channel = "busypuppet";

    public float pingCounter;

    private void Start()
    {
        puppetControl = FindObjectOfType<PuppetControl>();
    }
    private void ConnectToTwitch()
    {
        Twitch = new TcpClient(URL, PORT);
        Reader = new StreamReader(Twitch.GetStream());
        Writer = new StreamWriter(Twitch.GetStream());

        Writer.WriteLine("PASS " + OAuth);
        Writer.WriteLine("NICK " + User.ToLower()); //"NICK" = nickname
        Writer.WriteLine("JOIN #" + Channel.ToLower());
        Writer.Flush(); // sends all the stuff you wrote to the tcp so it actually connects
    }

    void Awake()
    {
        //shitpostTest = FindObjectOfType<ShitpostTest>();
        ConnectToTwitch();
    }

    void Update()
    {
        pingCounter += Time.deltaTime;
        if (pingCounter > 60)
        {
            Writer.WriteLine("PING " + URL);
            Writer.Flush();
            pingCounter = 0;
        }

        if (!Twitch.Connected)
        {
            ConnectToTwitch();
        }

        if (Twitch.Available > 0)
        {
            //if something is available in the TCP that we can grab with the stream reader
            string message = Reader.ReadLine(); //reads the next available line in our TCP

            if (message.Contains("PRIVMSG"))    //code that will come with any message that's written by a user
            {


                int splitPoint = message.IndexOf("!");  //notice the '!' in front of the message - we can use this '!' to isolate the username
                string chatter = message.Substring(1, splitPoint - 1);  //extracts the first word... in this case, 'soomoh'
                                                                        //aka the person speaking

                splitPoint = message.IndexOf(":", 1);   //so everything after that colon is the message that the user typed... in this case, 'hello world'
                string msg = message.Substring(splitPoint + 1);    //anything that's passed that colon, bring it in to that string

                //This UnityEvent is what will look at the messager, and their message - then it will invoke a method from another script that we assign! 
                //You can assign the method it invokes in the inspector.
                OnChatMessage?.Invoke(chatter, msg);

                print(msg);

                if (msg == "Raise Left Arm")
                {
                    Debug.Log("Raise Left Arm");
                    puppetControl.RaiseLeftArm();
                }

                if (msg == "Lower Left Arm")
                {
                    Debug.Log("Lower Left Arm");
                    puppetControl.LowerLeftArm();
                }

                if (msg == "Raise Left Forearm")
                {
                    Debug.Log("Raise Left Forearm");
                    puppetControl.RaiseLeftForearm();
                }

                if (msg == "Lower Left Forearm")
                {
                    Debug.Log("Lower Left Forearm");
                    puppetControl.LowerLeftForearm();
                }

                if (msg == "Raise Right Forearm")
                {
                    Debug.Log("Raise Right Forearm");
                    puppetControl.RaiseRightForearm();
                }

                if (msg == "Lower Right Forearm")
                {
                    Debug.Log("Lower Right Forearm");
                    puppetControl.LowerRightForearm();
                }

                if (msg == "Raise Right Arm")
                {
                    Debug.Log("Raise Right Arm");
                    puppetControl.RaiseRightArm();
                }

                if (msg == "Lower Right Arm")
                {
                    Debug.Log("Lower Right Arm");
                    puppetControl.LowerRightArm();
                }
                if (msg == "reset")
                {
                    SceneManager.LoadScene("PuppetTestScene");
                }
            }
        }
    }
}