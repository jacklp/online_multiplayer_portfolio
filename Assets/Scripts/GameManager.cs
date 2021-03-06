﻿using UnityEngine;
using System.Collections;

public class GameManager : Photon.MonoBehaviour {

    public Transform enemy;
    public Transform aStar;


	public float timeFromLastSpawn;
	public float Delay;
    public float roundStartDelay;
	public int numberOfSpawns = 10;
    private int roundCount = 1;
    public float gameStartTime;
    public int lives;

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

        enemy.gameObject.GetComponent<HWRWeaponSystem.DamageManager>().HP = 30;

        GenerateScene generateScene = GameObject.Find ("Obstacles").GetComponent<GenerateScene> ();
		generateScene.levelone ();

        Instantiate(aStar, new Vector3(0f, 0f, 0f), Quaternion.identity);

	}



	private void Update ()
	{
        // if the game is not over
        if (lives == 0)
        {
            Debug.Log("YOUR DEAD");
            return;
        }




        if (PhotonNetwork.isMasterClient)
        {
            
            //get server time.
    
            enemy.gameObject.GetComponent<HWRWeaponSystem.DamageManager>().HP = enemy.gameObject.GetComponent<HWRWeaponSystem.DamageManager>().HP * (1 +PhotonNetwork.otherPlayers.Length);

            Debug.Log(numberOfSpawns);
            Debug.Log(gameStartTime);
            Debug.Log(timeFromLastSpawn);
            Debug.Log(Delay);

            if (numberOfSpawns > 0) {

			    if ((Time.time) >= (timeFromLastSpawn + Delay)) {

                    GameObject newPlayer = PhotonNetwork.Instantiate("TankEnemy", new Vector3(-34.5f, 0f, 45f) , Quaternion.Euler(0, 180, 0), 0 );

                    newPlayer.GetComponent<HWRWeaponSystem.DamageManager>().HP = newPlayer.gameObject.GetComponent<HWRWeaponSystem.DamageManager>().HP + (roundCount*20);

				    numberOfSpawns--;
                    timeFromLastSpawn = Time.time;
			    }
		    }
            else
            {
                if((Time.time) >= timeFromLastSpawn + roundStartDelay)
                {
                    roundCount++;
                    numberOfSpawns = 10 + (2 * roundCount);
                }
            }
        }
    }

	void OnDisconnectedFromPhoton()
	{
		Debug.LogWarning("OnDisconnectedFromPhoton");
	}   
}


// all i need to do is create a bigger loop that spawns 10 rounds.
