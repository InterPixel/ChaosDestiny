using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstantiateBullet : MonoBehaviour {

	public GameObject Bullet;
	private GameObject Nyna;
	private GameObject Projectiles;

	void Start () {
		Projectiles = new GameObject("Projectiles");
	}

	public void OnFireButtonClick () {
		Nyna = GameObject.Find("Nyna");
		//instantiate bulletnya
		GameObject BulletObject = Instantiate(Bullet, Nyna.transform.position+(Nyna.transform.up / 4), Nyna.transform.rotation) as GameObject;
		BulletObject.transform.parent = Projectiles.transform;
		//addforce bulletnya
		BulletObject.GetComponent<Rigidbody2D>().AddRelativeForce (transform.up * 100);
	}

	void Update () {
		if(Input.GetKey(KeyCode.Space)){
			OnFireButtonClick();
		}
	}
}
