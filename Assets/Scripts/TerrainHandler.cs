using UnityEngine;


public class TerrainHandler : MonoBehaviour {

	Renderer rend;
    Material mouseOverMat;
	Material normalMat;
	bool btnPressed = false;
    Vector2 mousePos;
    int currentGold;
    public int machineGunPrice;
    public int cannonGunPrice;
    public int LaserGunPrice;
    public int rocketGunPrice;
    private bool builtOn = false;
    private Font f;
    private GUIStyle backgroundStyle;
    private GUIStyle myButtonStyle;

    void Awake()
    {

        f = (Font)Resources.Load("inktank");
    }

    void Start(){
		rend = GetComponent<Renderer>();
        mouseOverMat = Resources.Load("terrainMouseOverMat", typeof(Material)) as Material;
        normalMat = Resources.Load("terrainMat", typeof(Material)) as Material;
    }
	void OnMouseEnter(){
        if(!builtOn) rend.material = mouseOverMat;
	}

	void OnMouseExit(){
		if (!builtOn) rend.material = normalMat;
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
    void OnGUI(){

        if (!builtOn)
        {
            if (btnPressed)
            {

                backgroundStyle = new GUIStyle();
                backgroundStyle.normal.background = MakeTex(600, 1, new Color(0f, 0f, 0f, 1.0f));
                GUI.depth = 1;

                myButtonStyle = new GUIStyle(GUI.skin.button);
                myButtonStyle.fontSize = 30;
                myButtonStyle.font = f;

                GUI.depth = 0;
                GUILayout.BeginArea(new Rect(0, Screen.height - 100, Screen.width / 2, 100), backgroundStyle);

                //Towers
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("MachineGun (£" + machineGunPrice + ")", myButtonStyle, GUILayout.Width(250)))
                {
                    buildTurrent("MachineGun");
                }
                if (GUILayout.Button("CannonGun (£" + cannonGunPrice + ")", myButtonStyle, GUILayout.Width(250)))
                {
                    buildTurrent("CannonGun");
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("LaserGun (£" + LaserGunPrice + ")", myButtonStyle, GUILayout.Width(250)))
                {
                    buildTurrent("LaserGun");
                }
                if (GUILayout.Button("RocketGun (£" + rocketGunPrice + ")", myButtonStyle, GUILayout.Width(250)))
                {
                    buildTurrent("RocketGun");
                }
                GUILayout.EndHorizontal();
                GUILayout.EndArea();
            }
        } 
    }

	void buildTurrent(string type){
		btnPressed = false;

		Vector3 vec3 = new Vector3 (transform.position.x, transform.position.y + 2, transform.position.z);
		if (type == "MachineGun" && (currentGold - machineGunPrice) >= 0) {
			PhotonNetwork.Instantiate("MachineGun", vec3 , Quaternion.identity, 0);
            UpdateGold(10);
		} else if (type == "CannonGun" && (currentGold - cannonGunPrice) >= 0) {
			PhotonNetwork.Instantiate("CannonGun", vec3 , Quaternion.identity, 0);
            UpdateGold(20);
        } else if (type == "LaserGun" && (currentGold - LaserGunPrice) >= 0) {
			PhotonNetwork.Instantiate("LaserGun", vec3 , Quaternion.identity, 0);
            UpdateGold(50);
        } else if (type == "RocketGun" && (currentGold - rocketGunPrice) >= 0) {
			PhotonNetwork.Instantiate("RocketGun", vec3 , Quaternion.identity, 0);
            UpdateGold(70);
        }
	}

    void UpdateGold(int MinusGold)
    {
        if (!builtOn)
        {
            currentGold = currentGold - MinusGold;
            GameObject.Find("money").GetComponent<MoneyManager>().gold = currentGold;
            builtOn = true;
        }
    }
	void OnMouseDown(){
        if (!builtOn)
        {
            btnPressed = true;
            currentGold = GameObject.Find("money").GetComponent<MoneyManager>().gold;
        }
	}
}
