using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateScene : MonoBehaviour {


    public Transform Terrain;
    private GUIStyle backgroundStyle;

    public void levelone(){

        //Row 1
        addTerrainToScene(new Vector3(-45f, 0f, 45f));
        addTerrainToScene(new Vector3(-25f, 0f, 45f));
        addTerrainToScene(new Vector3(-15f, 0f, 45f));
        addTerrainToScene(new Vector3(-05f, 0f, 45f));
        addTerrainToScene(new Vector3(05f, 0f, 45f));
        addTerrainToScene(new Vector3(15f, 0f, 45f));
        addTerrainToScene(new Vector3(25f, 0f, 45f));
        addTerrainToScene(new Vector3(35f, 0f, 45f));


        //Row 10
        
        addTerrainToScene(new Vector3(-35f, 0f, -45f));
        addTerrainToScene(new Vector3(-25f, 0f, -45f));
        addTerrainToScene(new Vector3(-15f, 0f, -45f));
        addTerrainToScene(new Vector3(-05f, 0f, -45f));
        addTerrainToScene(new Vector3(05f, 0f, -45f));
        addTerrainToScene(new Vector3(15f, 0f, -45f));
        addTerrainToScene(new Vector3(25f, 0f, -45f));
        addTerrainToScene(new Vector3(45f, 0f, -45f));

        //Col 1
        
		addTerrainToScene (new Vector3 (-45f, 0f, 35f));
		addTerrainToScene (new Vector3 (-45f, 0f, 25f));
		addTerrainToScene (new Vector3 (-45f, 0f, 15f));
		addTerrainToScene (new Vector3 (-45f, 0f, 05f));
		addTerrainToScene (new Vector3 (-45f, 0f, -05f));
		addTerrainToScene (new Vector3 (-45f, 0f, -15f));
		addTerrainToScene (new Vector3 (-45f, 0f, -25f));
		addTerrainToScene (new Vector3 (-45f, 0f, -35f));
		addTerrainToScene (new Vector3 (-45f, 0f, -45f));

        //Col 2
        addTerrainToScene(new Vector3(-35f, 0f, -35f));

        //Col 3
        addTerrainToScene (new Vector3 (-25f, 0f, 35f));
		addTerrainToScene (new Vector3 (-25f, 0f, 25f));
		addTerrainToScene (new Vector3 (-25f, 0f, 15f));
		addTerrainToScene (new Vector3 (-25f, 0f, 05f));
		addTerrainToScene (new Vector3 (-25f, 0f, -05f));
		addTerrainToScene (new Vector3 (-25f, 0f, -15f));
		addTerrainToScene (new Vector3 (-25f, 0f, -35f));

        //Col 4
        addTerrainToScene(new Vector3(-15f, 0f, -35f));

        //Col 5
        addTerrainToScene(new Vector3(-05f, 0f, 25f));
        addTerrainToScene(new Vector3(-05f, 0f, 15f));
        addTerrainToScene(new Vector3(-05f, 0f, 05f));
        addTerrainToScene(new Vector3(-05f, 0f, -05f));
        addTerrainToScene(new Vector3(-05f, 0f, -15f));
        addTerrainToScene(new Vector3(-05f, 0f, -25f));
        addTerrainToScene(new Vector3(-05f, 0f, -35f));

        //Col 6
        addTerrainToScene(new Vector3(05f, 0f, 25f));
        addTerrainToScene(new Vector3(05f, 0f, -15f));
        addTerrainToScene(new Vector3(05f, 0f, -25f));
        addTerrainToScene(new Vector3(05f, 0f, -35f));


        //Col 7
        addTerrainToScene(new Vector3(15f, 0f, 25f));
        addTerrainToScene(new Vector3(15f, 0f, 05f));
        addTerrainToScene(new Vector3(15f, 0f, -25f));
        addTerrainToScene(new Vector3(15f, 0f, -35f));

        //Col 8
        addTerrainToScene(new Vector3(25f, 0f, 25f));
        addTerrainToScene(new Vector3(25f, 0f, 05f));
        addTerrainToScene(new Vector3(25f, 0f, -05f));
        addTerrainToScene(new Vector3(25f, 0f, -35f));

        //Col 9
        addTerrainToScene(new Vector3(35f, 0f, 05f));
        addTerrainToScene(new Vector3(35f, 0f, -05f));
        addTerrainToScene(new Vector3(35f, 0f, -15f));

        //Col 10
        addTerrainToScene(new Vector3(45f, 0f, 45f));
        addTerrainToScene(new Vector3(45f, 0f, 35f));
        addTerrainToScene(new Vector3(45f, 0f, 25f));
        addTerrainToScene(new Vector3(45f, 0f, 15f));
        addTerrainToScene(new Vector3(45f, 0f, 05f));
        addTerrainToScene(new Vector3(45f, 0f, -05f));
        addTerrainToScene(new Vector3(45f, 0f, -15f));
        addTerrainToScene(new Vector3(45f, 0f, -25f));
        addTerrainToScene(new Vector3(45f, 0f, -35f));
     
    }

    void OnGUI()
    {
        backgroundStyle = new GUIStyle();
        backgroundStyle.normal.background = MakeTex(600, 1, new Color(0f, 0f, 0f, 1.0f));

        GUILayout.BeginArea(new Rect(0, Screen.height - 100, Screen.width / 2, 100), backgroundStyle);
        GUI.depth = 1;
        GUILayout.EndArea();
    }

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

    void addTerrainToScene(Vector3 vec3Pos){
        
        Instantiate(Terrain, vec3Pos, Quaternion.identity);
      
	}
}
