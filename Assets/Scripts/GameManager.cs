using UnityEngine;
using System.Collections;

public class GameManager : Photon.MonoBehaviour {

	public string playerPrefabName = "Charprefab";

	void OnJoinedRoom()
	{
		StartGame();
	}
	
	void StartGame()
	{
		Camera.main.farClipPlane = 1000; //Main menu set this to 0.4 for a nicer BG

		// Spawn our local player
		PhotonNetwork.Instantiate(this.playerPrefabName, transform.position, Quaternion.identity, 0);
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
