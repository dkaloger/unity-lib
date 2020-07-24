using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
	public health p;
	public adiomanager_main au;
	private void Start()
	{
		p= GameObject.FindGameObjectWithTag("Player").GetComponent<health>();
		au = GameObject.Find("player_hurt").GetComponent<adiomanager_main>();
	}
	void OnCollisionEnter(Collision collision) {
		switch (collision.gameObject.tag) {
			case "Player":
				p.HP_now -= 10;
				Destroy(gameObject);
				au.Play_hurt();
				break;
		}
	}
}
