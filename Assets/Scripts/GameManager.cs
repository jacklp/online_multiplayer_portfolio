using UnityEngine;
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


        if (gameStartTime != 0)
        {
            
            if (lives == 0)
            {
                Debug.Log("YOUR DEAD");
            }
            //increase Enemy HP based on number of players in room.
            enemy.gameObject.GetComponent<HWRWeaponSystem.DamageManager>().HP = enemy.gameObject.GetComponent<HWRWeaponSystem.DamageManager>().HP * (1 +PhotonNetwork.otherPlayers.Length);

            if (numberOfSpawns > 0) {

			    if ((Time.time - gameStartTime) >= (timeFromLastSpawn + Delay)) {

                    Transform newPlayer = Instantiate(enemy, new Vector3 (-34.5f, 0f, 45f) , Quaternion.Euler(0, 180, 0)) as Transform;

                    newPlayer.gameObject.GetComponent<HWRWeaponSystem.DamageManager>().HP = newPlayer.gameObject.GetComponent<HWRWeaponSystem.DamageManager>().HP + (roundCount*10);

				    numberOfSpawns--;
                    timeFromLastSpawn = Time.time;
			    }
		    }
            else
            {
                if((Time.time - gameStartTime) >= timeFromLastSpawn + roundStartDelay)
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
