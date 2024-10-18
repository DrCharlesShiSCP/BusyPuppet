using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using System.Net.Sockets;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class TwitchConnect : MonoBehaviour
{
    public TextMeshProUGUI leaderBoard;
    public TextMeshProUGUI recentCommandsText;
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

    private Dictionary<string, int> userCommandCounts = new Dictionary<string, int>();
    private List<string> recentCommands = new List<string>();
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

                if (userCommandCounts.ContainsKey(chatter))
                {
                    userCommandCounts[chatter]++;
                }
                else
                {
                    userCommandCounts[chatter] = 1;
                }
                //This UnityEvent is what will look at the messager, and their message - then it will invoke a method from another script that we assign! 
                //You can assign the method it invokes in the inspector.
                UpdateLeaderboard();
                UpdateRecentCommands($"{chatter}: {msg}");
                OnChatMessage?.Invoke(chatter, msg);
                print(msg);


                if (msg == "Raise Left Arm" || msg == "raise left arm" || msg == "raiseleftarm" ||
                    msg == "Raise left arm" || msg == "Raise Left arm" || msg == "Raiseleftarm" ||
                    msg == "Raise L_A" || msg == "Raise L A" || msg == "Raise l a" || msg == "raise la" ||
                    msg == "up la" || msg == "up LA" || msg == "up L a")
                {
                    Debug.Log("Raise Left Arm");
                    puppetControl.RaiseLeftArm();
                }

                if (msg == "Lower Left Arm" || msg == "lower left arm" || msg == "lowerleftarm" ||
                     msg == "Lower left arm" || msg == "Lower Left arm" || msg == "Lowerleftarm" ||
                      msg == "Lower L_A" || msg == "Lower L A" || msg == "Lower l a" || msg == "lower la" ||
                      msg == "down la" || msg == "down LA" || msg == "down L a")
                {
                    Debug.Log("Lower Left Arm");
                    puppetControl.LowerLeftArm();
                }

                if (msg == "Raise Left Forearm" || msg == "raise left forearm" || msg == "raiseleftforearm" ||
                    msg == "Raise left forearm" || msg == "Raise Left forearm" || msg == "Raiseleftforearm" ||
                    msg == "Raise L_F" || msg == "Raise L F" || msg == "Raise l f" || msg == "raise lf" ||
                    msg == "up lf" || msg == "up LF" || msg == "up L f")
                {
                    Debug.Log("Raise Left Forearm");
                    puppetControl.RaiseLeftForearm();
                }

                if (msg == "Lower Left Forearm" || msg == "lower left forearm" || msg == "lowerleftforearm" ||
                    msg == "Lower left forearm" || msg == "Lower Left forearm" || msg == "Lowerleftforearm" ||
                    msg == "Lower L_F" || msg == "Lower L F" || msg == "Lower l f" || msg == "lower lf" ||
                    msg == "down lf" || msg == "down LF" || msg == "down L f")
                {
                    Debug.Log("Lower Left Forearm");
                    puppetControl.LowerLeftForearm();
                }

                if (msg == "Raise Right Forearm" || msg == "raise right forearm" || msg == "raiserightforearm" ||
                    msg == "Raise right forearm" || msg == "Raise Right forearm" || msg == "Raiserightforearm" ||
                    msg == "Raise R_F" || msg == "Raise R F" || msg == "Raise r f" || msg == "raise rf" ||
                    msg == "up rf" || msg == "up RF" || msg == "up R f")
                {
                    Debug.Log("Raise Right Forearm");
                    puppetControl.RaiseRightForearm();
                }

                if (msg == "Lower Right Forearm" || msg == "lower right forearm" || msg == "lowerrightforearm" ||
                    msg == "Lower right forearm" || msg == "Lower Right forearm" || msg == "Lowerrightforearm" ||
                    msg == "Lower R_F" || msg == "Lower R F" || msg == "Lower r f" || msg == "lower rf" ||
                    msg == "down rf" || msg == "down RF" || msg == "down R f")
                {
                    Debug.Log("Lower Right Forearm");
                    puppetControl.LowerRightForearm();
                }

                if (msg == "Raise Right Arm" || msg == "raise right arm" || msg == "raiserightarm" ||
                    msg == "Raise right arm" || msg == "Raise Right arm" || msg == "Raiserightarm" ||
                    msg == "Raise R_A" || msg == "Raise R A" || msg == "Raise r a" || msg == "raise ra" ||
                    msg == "up ra" || msg == "up RA" || msg == "up R a")
                {
                    Debug.Log("Raise Right Arm");
                    puppetControl.RaiseRightArm();
                }

                if (msg == "Lower Right Arm" || msg == "lower right arm" || msg == "lowerrightarm" ||
                    msg == "Lower right arm" || msg == "Lower Right arm" || msg == "Lowerrightarm" ||
                    msg == "Lower R_A" || msg == "Lower R A" || msg == "Lower r a" || msg == "lower ra" ||
                    msg == "down ra" || msg == "down RA" || msg == "down R a")
                {
                    Debug.Log("Lower Right Arm");
                    puppetControl.LowerRightArm();
                }

                if (msg == "Raise Left Thigh" || msg == "raise left thigh" || msg == "raiseleftthigh" ||
                    msg == "Raise left thigh" || msg == "Raise Left thigh" || msg == "Raiseleftthigh" ||
                    msg == "Raise L_T" || msg == "Raise L T" || msg == "Raise l t" || msg == "raise lt" ||
                    msg == "up lt" || msg == "up LT" || msg == "up L t")
                {
                    Debug.Log("Raise Left Thigh");
                    puppetControl.RaiseLeftThigh();
                }

                if (msg == "Lower Left Thigh" || msg == "lower left thigh" || msg == "lowerleftthigh" ||
                    msg == "Lower left thigh" || msg == "Lower Left thigh" || msg == "Lowerleftthigh" ||
                    msg == "Lower L_T" || msg == "Lower L T" || msg == "Lower l t" || msg == "lower lt" ||
                    msg == "down lt" || msg == "down LT" || msg == "down L t")
                {
                    Debug.Log("Lower Left Thigh");
                    puppetControl.LowerLeftThigh();
                }

                if (msg == "Raise Right Thigh" || msg == "raise right thigh" || msg == "raiserightthigh" ||
                    msg == "Raise right thigh" || msg == "Raise Right thigh" || msg == "Raiserightthigh" ||
                    msg == "Raise R_T" || msg == "Raise R T" || msg == "Raise r t" || msg == "raise rt" ||
                    msg == "up rt" || msg == "up RT" || msg == "up R t")
                {
                    Debug.Log("Raise Right Thigh");
                    puppetControl.RaiseRightThigh();
                }

                if (msg == "Lower Right Thigh" || msg == "lower right thigh" || msg == "lowerrightthigh" ||
                    msg == "Lower right thigh" || msg == "Lower Right thigh" || msg == "Lowerrightthigh" ||
                    msg == "Lower R_T" || msg == "Lower R T" || msg == "Lower r t" || msg == "lower rt" ||
                    msg == "down rt" || msg == "down RT" || msg == "down R t")
                {
                    Debug.Log("Lower Right Thigh");
                    puppetControl.LowerRightThigh();
                }

                if (msg == "Raise Left Calf" || msg == "raise left calf" || msg == "raiseleftcalf" ||
                    msg == "Raise left calf" || msg == "Raise Left calf" || msg == "Raiseleftcalf" ||
                    msg == "Raise L_C" || msg == "Raise L C" || msg == "Raise l c" || msg == "raise lc" ||
                    msg == "up lc" || msg == "up LC" || msg == "up L c")
                {
                    Debug.Log("Raise Left Calf");
                    puppetControl.RaiseLeftCalf();
                }

                if (msg == "Lower Left Calf" || msg == "lower left calf" || msg == "lowerleftcalf" ||
                    msg == "Lower left calf" || msg == "Lower Left calf" || msg == "Lowerleftcalf" ||
                    msg == "Lower L_C" || msg == "Lower L C" || msg == "Lower l c" || msg == "lower lc" ||
                    msg == "down lc" || msg == "down LC" || msg == "down L c")
                {
                    Debug.Log("Lower Left Calf");
                    puppetControl.LowerLeftCalf();
                }

                if (msg == "Raise Right Calf" || msg == "raise right calf" || msg == "raiserightcalf" ||
                    msg == "Raise right calf" || msg == "Raise Right calf" || msg == "Raiserightcalf" ||
                    msg == "Raise R_C" || msg == "Raise R C" || msg == "Raise r c" || msg == "raise rc" ||
                    msg == "up rc" || msg == "up RC" || msg == "up R c")
                {
                    Debug.Log("Raise Right Calf");
                    puppetControl.RaiseRightCalf();
                }

                if (msg == "Lower Right Calf" || msg == "lower right calf" || msg == "lowerrightcalf" ||
                    msg == "Lower right calf" || msg == "Lower Right calf" || msg == "Lowerrightcalf" ||
                    msg == "Lower R_C" || msg == "Lower R C" || msg == "Lower r c" || msg == "lower rc" ||
                    msg == "down rc" || msg == "down RC" || msg == "down R c")
                {
                    Debug.Log("Lower Right Calf");
                    puppetControl.LowerRightCalf();
                }
                if (msg == "reset"|| msg == "Reset" || msg == "RESET")
                {
                    StaticValue.completedTurn = 0;
                    StaticValue.currentTurn = 0;
                    SceneManager.LoadScene("PuppetTestScene");
                }
            }
        }
    }
    void UpdateLeaderboard()
    {
        // Sort the userCommandCounts dictionary by command count in descending order and take the top 5
        var topUsers = userCommandCounts.OrderByDescending(x => x.Value).Take(5);

        // Format the leaderboard text
        string leaderboard = "Top 5 Command Users:\n";
        int rank = 1;
        foreach (var user in topUsers)
        {
            leaderboard += $"{rank}. {user.Key}: {user.Value} commands\n";
            rank++;
        }

        leaderBoard.text = leaderboard;
    }
    void UpdateRecentCommands(string newCommand)
    {
        recentCommands.Insert(0, newCommand);

        if (recentCommands.Count > 5)
        {
            recentCommands.RemoveAt(recentCommands.Count - 1);
        }

        recentCommandsText.text = "Recent Commands:\n";
        foreach (string command in recentCommands)
        {
            recentCommandsText.text += command + "\n";
        }
    }
}