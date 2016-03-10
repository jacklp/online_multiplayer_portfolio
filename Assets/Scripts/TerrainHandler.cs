using UnityEngine;
using System.Collections;

public class TerrainHandler : MonoBehaviour {

	Renderer rend;
	Material mouseOverMat = Resources.Load("terrainMouseOverMat", typeof(Material)) as Material;
	Material normalMat = Resources.Load("terrainMat", typeof(Material)) as Material;
	bool btnPressed = false;

	void Start(){
		rend = GetComponent<Renderer>();
	}
	void OnMouseEnter(){
		rend.material = mouseOverMat;
	}

	void OnMouseExit(){
		rend.material = normalMat;
	}

	void OnGUI(){
		if (btnPressed) {	
			GUILayout.BeginArea (new Rect (0, 0, 400, 300));

			//Towers
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("MachineGun"))
			{
				buildTurrent ("MachineGun");
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("CannonGun"))
			{
				buildTurrent ("CannonGun");
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("LaserGun"))
			{
				buildTurrent ("LaserGun");
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("RocketGun"))
			{
				buildTurrent ("RocketGun");
			}
			GUILayout.EndHorizontal();
			GUILayout.EndArea ();
		}
	}

	void buildTurrent(string type){
		btnPressed = false;

		Vector3 vec3 = new Vector3 (transform.position.x, transform.position.y + 10, transform.position.z);
		if (type == "MachineGun") {
			PhotonNetwork.Instantiate("MachineGun", vec3 , Quaternion.identity, 0);
		} else if (type == "CannonGun") {
			PhotonNetwork.Instantiate("CannonGun", vec3 , Quaternion.identity, 0);
		} else if (type == "LaserGun") {
			PhotonNetwork.Instantiate("LaserGun", vec3 , Quaternion.identity, 0);
		} else if (type == "RocketGun") {
			PhotonNetwork.Instantiate("RocketGun", vec3 , Quaternion.identity, 0);
		}
	}

	void OnMouseDown(){
		btnPressed = true;
		Debug.Log (btnPressed);
	}
}
