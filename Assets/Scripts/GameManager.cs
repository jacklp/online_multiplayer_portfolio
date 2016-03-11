using UnityEngine;
using System.Collections;

public class GameManager : Photon.MonoBehaviour {

    public Transform enemy;
    public Transform aStar;

    void OnJoinedRoom()
	{
		StartGame();
	}
	
	void StartGame()
	{
		Camera.main.farClipPlane = 1000; //Main menu set this to 0.4 for a nicer BG

		// Spawn our local player
		//PhotonNetwork.Instantiate(this.playerPrefabName, transform.position, Quaternion.identity, 0);

		Instantiate(enemy, new Vector3 (-35f, 2.5f, 45f) , Quaternion.Euler(0, 180, 0));


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

	void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("OnDisconnectedFromPhoton");
	}   
}
