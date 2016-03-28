using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private Font f;
    GUIStyle myLabelStyle;
    GUIStyle backgroundStyle;
    GUIStyle textFieldStyle;
    GUIStyle buttonStyle;

    void Awake()
	{
		//PhotonNetwork.logLevel = NetworkLogLevel.Full;

		//Connect to the main photon server. This is the only IP and port we ever need to set(!)
		if (!PhotonNetwork.connected)
			PhotonNetwork.ConnectUsingSettings("v1.0"); // version of the game/demo. used to separate older clients from newer ones (e.g. if incompatible)

		//Load name from PlayerPrefs
		PhotonNetwork.playerName = PlayerPrefs.GetString("playerName", "Guest" + Random.Range(1, 9999));

		//Set camera clipping for nicer "main menu" background
		Camera.main.farClipPlane = Camera.main.nearClipPlane + 0.1f;
        f = (Font)Resources.Load("inktank");
    }

	private string roomName = "myRoom";
	private Vector2 scrollPos = Vector2.zero;

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];

        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();

        return result;
    }

    void OnGUI()
	{

        myLabelStyle = new GUIStyle(GUI.skin.label);
        myLabelStyle.fontSize = 50;
        myLabelStyle.font = f;
        myLabelStyle.fixedWidth = 250;

        textFieldStyle = new GUIStyle(GUI.skin.textField);
        textFieldStyle.fontSize = 50;
        textFieldStyle.font = f;

        buttonStyle = new GUIStyle(GUI.skin.button);
        buttonStyle.fontSize = 50;
        buttonStyle.font = f;

        backgroundStyle = new GUIStyle();
        backgroundStyle.normal.background = MakeTex(600, 1, new Color(0f, 0f, 0f, 1.0f));


        if (!PhotonNetwork.connected)
		{
			ShowConnectingGUI(backgroundStyle, myLabelStyle);
			return;   //Wait for a connection
		}
        

		if (PhotonNetwork.room != null)
            
            return; //Only when we're not in a Room

		GUILayout.BeginArea(new Rect(0,0, Screen.width, Screen.height), backgroundStyle);

		GUILayout.Label("Main Menu", myLabelStyle);

		//Player name
		GUILayout.BeginHorizontal();
		GUILayout.Label("Player name:", myLabelStyle);
		PhotonNetwork.playerName = GUILayout.TextField(PhotonNetwork.playerName, textFieldStyle, GUILayout.Width(500), GUILayout.Height(50));
		if (GUI.changed)//Save name
			PlayerPrefs.SetString("playerName", PhotonNetwork.playerName);
		GUILayout.EndHorizontal();

		GUILayout.Space(15);


		//Join room by title
		GUILayout.BeginHorizontal();
		GUILayout.Label("JOIN ROOM:", myLabelStyle);
		roomName = GUILayout.TextField(roomName, textFieldStyle, GUILayout.Width(500), GUILayout.Height(50));
		if (GUILayout.Button("GO", buttonStyle))
		{
            PhotonNetwork.JoinRoom(roomName);
        }
		GUILayout.EndHorizontal();

		//Create a room (fails if exist!)
		GUILayout.BeginHorizontal();
		GUILayout.Label("CREATE ROOM:", myLabelStyle);
		roomName = GUILayout.TextField(roomName, textFieldStyle, GUILayout.Width(500), GUILayout.Height(50));
		if (GUILayout.Button("GO", buttonStyle))
		{
            
            GameObject.Find("code").GetComponent<GameManager>().gameStartTime = Time.time;
            
            // using null as TypedLobby parameter will also use the default lobby
            PhotonNetwork.CreateRoom(roomName, new RoomOptions() { maxPlayers = 10 }, TypedLobby.Default);
		}
		GUILayout.EndHorizontal();

		//Join random room
		GUILayout.BeginHorizontal();
		GUILayout.Label("JOIN RANDOM ROOM:", myLabelStyle);
		if (PhotonNetwork.GetRoomList().Length == 0)
		{
			GUILayout.Label("..no games available...", myLabelStyle);
		}
		else
		{
			if (GUILayout.Button("GO", buttonStyle))
			{
                PhotonNetwork.JoinRandomRoom();
            }
		}
		GUILayout.EndHorizontal();

		GUILayout.Space(30);
		GUILayout.Label("ROOM LISTING:", myLabelStyle);
		if (PhotonNetwork.GetRoomList().Length == 0)
		{
			GUILayout.Label("..no games available..", myLabelStyle);
		}
		else
		{
			//Room listing: simply call GetRoomList: no need to fetch/poll whatever!
			scrollPos = GUILayout.BeginScrollView(scrollPos);
			foreach (RoomInfo game in PhotonNetwork.GetRoomList())
			{
				GUILayout.BeginHorizontal();
				GUILayout.Label(game.name + " " + game.playerCount + "/" + game.maxPlayers, myLabelStyle);
				if (GUILayout.Button("JOIN", buttonStyle))
				{
                    PhotonNetwork.JoinRoom(game.name);
                   
                }
				GUILayout.EndHorizontal();
			}
			GUILayout.EndScrollView();
		}

		GUILayout.EndArea();
	}


	void ShowConnectingGUI(GUIStyle backgroundStyle, GUIStyle myLabelStyle)
	{
        myLabelStyle.fixedWidth = 500;

        GUILayout.BeginArea(new Rect(0,0, Screen.width, Screen.height), backgroundStyle);

		GUILayout.Label("Connecting to Photon server.", myLabelStyle);
		GUILayout.Label("Hint: This demo uses a settings file and logs the server address to the console.", myLabelStyle);

		GUILayout.EndArea();
	}

	public void OnConnectedToMaster()
	{
		// this method gets called by PUN, if "Auto Join Lobby" is off.
		// this demo needs to join the lobby, to show available rooms!

		PhotonNetwork.JoinLobby();  // this joins the "default" lobby
	}
}
