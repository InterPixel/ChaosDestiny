using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public GameObject Bullet;
	

	void OnCollisionEnter2D (Collision2D Coll){
		//When bullet hits enemy
		if (Coll.gameObject.name == "Enemy") {
			Destroy (Coll.gameObject);
			Destroy (Bullet);
		}
		//When bullet hits wall
		if (Coll.gameObject.name == "Wall(Clone)") {
			Destroy (Bullet);
		}
	}

	
}
