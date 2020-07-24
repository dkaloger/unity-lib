using UnityEngine;
using System.Collections;

public class FX_CameraCtrl : MonoBehaviour {

	Transform PlayerCamera;
	public float CameraSpeed = 5;

	// Use this for initialization
	void Start () {
		PlayerCamera = transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newDir = Vector3.zero;

		if(Input.mousePosition.x >= Screen.width){
			newDir.x = 1;
		}

		if(Input.mousePosition.x <= 0){
			newDir.x = -1;
		}

		if(Input.mousePosition.y >= Screen.height){
			newDir.z = 1;
		}

		if(Input.mousePosition.y <= 0){
			newDir.z = -1;
		}

		PlayerCamera.position += newDir * (CameraSpeed * Time.deltaTime);
	}
}
