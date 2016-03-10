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
			GUILayout.EndArea ();
		}
	}

	void buildTurrent(string type){
		btnPressed = false;

	}

	void OnMouseDown(){
		btnPressed = true;
		Debug.Log (btnPressed);
	}
}
