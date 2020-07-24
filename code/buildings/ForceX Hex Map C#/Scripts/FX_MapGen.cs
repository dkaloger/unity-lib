/*
 * This script is responsible for generating a Hex map.
 * 
 * Input Values:
 * 		1. Map Width : Determines how many hex units wide the map will be.
 * 		2. Mah Height : Determines how may hex units tall the map will be.
 * 		3. Rotate Hex : Determines the rotation of the hex mesh;
 * 			Rotate Hex (false) = Hex mesh will have a pointed top
 * 			Rotate Hex (True) = Hex mesh will have a flat top
 * 
*/
using UnityEngine;
using System.Collections;

public class FX_MapGen : MonoBehaviour {

	public int MapWidth = 2;
	public int MapHeight = 2;

	public bool RotateHex;
   public Transform Map;
   public float sizzer;

    void Start () {

		 Map = new GameObject("Map").transform;

		if(!RotateHex){
			GenerateMapRotA(Map);
		}else{
			GenerateMapRotB(Map);
		}
	}

	Vector2 GetHexSize(){
		GameObject Temp;

		if(!RotateHex){
			Temp = GetComponent<FX_HexGen>().MakeHex(30, sizzer);
		}else{
			Temp = GetComponent<FX_HexGen>().MakeHex(0, sizzer);
		}

		Bounds bounds = Temp.GetComponent<Renderer>().bounds;
		Vector2 extent = new Vector2(bounds.extents.x, bounds.extents.z);

		Destroy (Temp);

		return extent;
	}

	void GenerateMapRotA(Transform Map){//Generate a map with the pointy part of the Hex on top
		
		Vector2 extent = GetHexSize();
		
		float PosX = 0;
		float PosY = 0;
		
		for(int x = 0; x < MapWidth; x++){
			for(int y = 0; y < MapHeight; y++){
				
				Transform h = GetComponent<FX_HexGen>().MakeHex(30,sizzer).transform;
				
				SetHexInfo(x,y,h);
				
				PosY = y * (extent.y * 1.5f);
				
				if(y%2==0){
					PosX = (x * (extent.x * 2f));
				}else{
					PosX = x * (extent.x * 2f) + extent.x;
				}
				
				h.position = new Vector3(PosX, 0, PosY);
				h.parent = Map;
			}
		}
	}

	void GenerateMapRotB(Transform Map){ //Generate a map with the flat part of the Hex on top

		Vector2 extent = GetHexSize();

		float PosX = 0;
		float PosY = 0;

		for(int x = 0; x < MapWidth; x++){
			for(int y = 0; y < MapHeight; y++){

				Transform h = GetComponent<FX_HexGen>().MakeHex(0,sizzer).transform;

				SetHexInfo(y,x,h);

				PosX = x * (extent.x * 1.5f);

				if(x%2==0){
					PosY = (y * (extent.y * 2f));
				}else{
					PosY = y * (extent.y * 2f) + extent.y;
				}

				h.position = new Vector3(PosX, 0, PosY);
				h.parent = Map;
			}
		}
	}

	void SetHexInfo(int x, int y, Transform h){

		int newX = x;
		int newZ = -(x+y);
		
		if(y > 1){
			newX = Mathf.CeilToInt(x - (y * sizzer));
			newZ = -(newX+y);
		}

		h.GetComponent<FX_HexInfo>().HexPosition = new Vector3(newX, y, newZ);

		h.name = ("(" + newX.ToString() + "," + y.ToString() + "," + newZ.ToString() + ")");
	}
}
