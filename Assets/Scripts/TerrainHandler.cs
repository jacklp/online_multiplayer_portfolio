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

	void OnGUI(){

        if (!builtOn)
        {
            if (btnPressed)
            {
                GUILayout.BeginArea(new Rect(0, 0, 130, 300));

                //Towers
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("MachineGun (£" + machineGunPrice + ")"))
                {
                    buildTurrent("MachineGun");
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("CannonGun (£" + cannonGunPrice + ")"))
                {
                    buildTurrent("CannonGun");
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("LaserGun (£" + LaserGunPrice + ")"))
                {
                    buildTurrent("LaserGun");
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("RocketGun (£" + rocketGunPrice + ")"))
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
