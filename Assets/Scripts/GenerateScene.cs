using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateScene : MonoBehaviour {

	GameObject terrain;
	string cubePrefabName ="Cube";

	public void levelone(){

		// EDGES //
		addTerrainToScene (new Vector3 (-45f, 0f, 45f));
		addTerrainToScene (new Vector3 (-45f, 0f, 35f));
		addTerrainToScene (new Vector3 (-45f, 0f, 25f));
		addTerrainToScene (new Vector3 (-45f, 0f, 15f));
		addTerrainToScene (new Vector3 (-45f, 0f, 05f));
		addTerrainToScene (new Vector3 (-45f, 0f, -05f));
		addTerrainToScene (new Vector3 (-45f, 0f, -15f));
		addTerrainToScene (new Vector3 (-45f, 0f, -25f));
		addTerrainToScene (new Vector3 (-45f, 0f, -35f));
		addTerrainToScene (new Vector3 (-45f, 0f, -45f));


		addTerrainToScene (new Vector3 (-45f, 0f, 45f));
		addTerrainToScene (new Vector3 (-25f, 0f, 45f));
		addTerrainToScene (new Vector3 (-15f, 0f, 45f));
		addTerrainToScene (new Vector3 (-05f, 0f, 45f));
		addTerrainToScene (new Vector3 (05f, 0f, 45f));
		addTerrainToScene (new Vector3 (15f, 0f, 45f));
		addTerrainToScene (new Vector3 (25f, 0f, 45f));
		addTerrainToScene (new Vector3 (35f, 0f, 45f));
		addTerrainToScene (new Vector3 (45f, 0f, 45f));

		addTerrainToScene (new Vector3 (45f, 0f, 45f));
		addTerrainToScene (new Vector3 (45f, 0f, 35f));
		addTerrainToScene (new Vector3 (45f, 0f, 25f));
		addTerrainToScene (new Vector3 (45f, 0f, 15f));
		addTerrainToScene (new Vector3 (45f, 0f, 05f));
		addTerrainToScene (new Vector3 (45f, 0f, -05f));
		addTerrainToScene (new Vector3 (45f, 0f, -15f));
		addTerrainToScene (new Vector3 (45f, 0f, -25f));
		addTerrainToScene (new Vector3 (45f, 0f, -35f));
		addTerrainToScene (new Vector3 (45f, 0f, -45f));

		addTerrainToScene (new Vector3 (-45f, 0f, -45f));
		addTerrainToScene (new Vector3 (-35f, 0f, -45f));
		addTerrainToScene (new Vector3 (-25f, 0f, -45f));
		addTerrainToScene (new Vector3 (-15f, 0f, -45f));
		addTerrainToScene (new Vector3 (-05f, 0f, -45f));
		addTerrainToScene (new Vector3 (05f, 0f, -45f));
		addTerrainToScene (new Vector3 (15f, 0f, -45f));
		addTerrainToScene (new Vector3 (25f, 0f, -45f));
		addTerrainToScene (new Vector3 (45f, 0f, -45f));



		//INSIDE

		addTerrainToScene (new Vector3 (-25f, 0f, 35f));
		addTerrainToScene (new Vector3 (-25f, 0f, 25f));
		addTerrainToScene (new Vector3 (-25f, 0f, 15f));
		addTerrainToScene (new Vector3 (-25f, 0f, 05f));
		addTerrainToScene (new Vector3 (-25f, 0f, -05f));
		addTerrainToScene (new Vector3 (-25f, 0f, -15f));
		addTerrainToScene (new Vector3 (-25f, 0f, -35f));

	}



	void addTerrainToScene(Vector3 vec3Pos){
		PhotonNetwork.Instantiate(this.cubePrefabName, vec3Pos, Quaternion.identity, 0);
	}
}
