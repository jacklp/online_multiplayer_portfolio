using UnityEngine;


public class TerrainHandler : MonoBehaviour {

	Renderer rend;
	Material mouseOverMat = Resources.Load("terrainMouseOverMat", typeof(Material)) as Material;
	Material normalMat = Resources.Load("terrainMat", typeof(Material)) as Material;
	bool btnPressed = false;
    Vector2 mousePos;
    int currentGold;
    public int machineGunPrice;
    public int cannonGunPrice;
    public int LaserGunPrice;
    public int rocketGunPrice;

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
			GUILayout.BeginArea (new Rect (mousePos.x, mousePos.y, 130, 300));

			//Towers
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("MachineGun (£" + machineGunPrice + ")"))
			{
				buildTurrent ("MachineGun");
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("CannonGun (£" + cannonGunPrice + ")"))
			{
				buildTurrent ("CannonGun");
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("LaserGun (£" + LaserGunPrice + ")"))
			{
				buildTurrent ("LaserGun");
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("RocketGun (£" + rocketGunPrice + ")"))
			{
				buildTurrent ("RocketGun");
			}
			GUILayout.EndHorizontal();
			GUILayout.EndArea ();
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
        currentGold = currentGold - MinusGold;
        GameObject.Find("money").GetComponent<MoneyManager>().gold = currentGold;
    }
	void OnMouseDown(){
		btnPressed = true;
        currentGold = GameObject.Find("money").GetComponent<MoneyManager>().gold;
        mousePos = new Vector2(Input.mousePosition.x, 700-Input.mousePosition.y);
	}
}
