using UnityEngine;
using System.Collections;

public class GameManager : Photon.MonoBehaviour {

    public Transform enemy;
    public Transform aStar;


	public float timeSpawnTemp;
	public float Delay;
	public int numberOfSpawns = 10;


    void OnJoinedRoom()
	{
		StartGame();
	}
	
	void StartGame()
	{
		if (GetComponent<Renderer>())
			GetComponent<Renderer>().enabled = false;

		Camera.main.farClipPlane = 1000; //Main menu set this to 0.4 for a nicer BG

		// Spawn our local player
		//PhotonNetwork.Instantiate(this.playerPrefabName, transform.position, Quaternion.identity, 0);


		GenerateScene generateScene = GameObject.Find ("Obstacles").GetComponent<GenerateScene> ();
		generateScene.levelone ();

        Instantiate(aStar, new Vector3(0f, 0f, 0f), Quaternion.identity);

	}

	void OnGUI()
	{
		if (PhotonNetwork.room == null) return; //Only display this GUI when inside a room

		if (GUILayout.Button("Leave Room"))
		{
			PhotonNetwork.LeaveRoom();
		}
	}

	private void Update ()
	{

		if (numberOfSpawns > 0) {

			if (Time.time >= (timeSpawnTemp + Delay)) {

				Instantiate(enemy, new Vector3 (-34.5f, 0f, 45f) , Quaternion.Euler(0, 180, 0));
				numberOfSpawns--;
				timeSpawnTemp = Time.time;
			}
		}
	}

	void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("OnDisconnectedFromPhoton");
	}   
}