using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour
{

    public int gold;

    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(650, 0, 100, 300));

        //Towers
        GUILayout.BeginHorizontal();
        GUILayout.Label("Gold: " + gold.ToString(), GUILayout.Width(150));
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
}
