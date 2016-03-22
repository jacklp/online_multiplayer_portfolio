using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour
{

    public int gold;
    GUIStyle backgroundStyle;
    GUIStyle myLabelStyle;
    private Font f;

    void Awake()
    {
        f = (Font)Resources.Load("inktank");
    }

    void OnGUI()
    {
        backgroundStyle = new GUIStyle();
        backgroundStyle.normal.background = MakeTex(600, 1, new Color(0f, 0f, 0f, 1.0f));

        myLabelStyle = new GUIStyle(GUI.skin.label);
        myLabelStyle.fontSize = 50;
        myLabelStyle.font = f;
        myLabelStyle.fixedWidth = 250;


        GUILayout.BeginArea(new Rect(Screen.width/2, Screen.height-100,Screen.width/2,100), backgroundStyle);

        //Towers
        GUILayout.BeginHorizontal();
        GUILayout.Label("Gold: " + gold.ToString(), myLabelStyle, GUILayout.Width(150));
        GUILayout.EndHorizontal();

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
}
