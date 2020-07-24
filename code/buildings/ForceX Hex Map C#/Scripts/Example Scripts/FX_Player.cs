/*
 * This is an example script that demonstrates how to do simple distance calculations
 * based on a starting Hex and a target Hex.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FX_Player : MonoBehaviour {
	public Camera PlayerCameraC;
	Transform PlayerCameraT;

	public Transform CurrentHex;
	public Transform TargetHex;

	public int MoveDistance;
	public Text DistanceText;

	// Use this for initialization
	void Start () {
	    DistanceText = GameObject.Find ("Distance Text").GetComponent<Text>();
		PlayerCameraT = PlayerCameraC.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = PlayerCameraC.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, 100)){
			if(TargetHex && TargetHex != CurrentHex){
				if(hit.transform != TargetHex){
					TargetHex.GetComponent<Renderer>().material.color = Color.white;
				}
				TargetHex = hit.transform;
				TargetHex.GetComponent<Renderer>().material.color = Color.red;
			}

			if(hit.transform != CurrentHex){
				TargetHex = hit.transform;
			}

			if(Input.GetMouseButtonDown(0)){
				if(CurrentHex){
					CurrentHex.GetComponent<Renderer>().material.color = Color.white;
				}
				CurrentHex = hit.transform;
				CurrentHex.GetComponent<Renderer>().material.color = Color.green;
			}
		}

		if(CurrentHex && TargetHex){
			CalculateDistance();
		}
	}

	void CalculateDistance(){
		Vector3 CurrentHexInfo = CurrentHex.GetComponent<FX_HexInfo>().HexPosition;
		Vector3 TargetHexInfo = TargetHex.GetComponent<FX_HexInfo>().HexPosition;;

		int dx = (int)Mathf.Abs(TargetHexInfo.x - CurrentHexInfo.x);
		int dy = (int)Mathf.Abs(TargetHexInfo.y - CurrentHexInfo.y);
		int dz = (int)Mathf.Abs(TargetHexInfo.z - CurrentHexInfo.z);
		
		MoveDistance = (int)Mathf.Max(dx, dy, dz);
		DistanceText.text = "Current Hex : (" + CurrentHexInfo.ToString() + ")   Target Hex : (" + TargetHexInfo.ToString() +")   Distance : " + MoveDistance.ToString();
	}
}
