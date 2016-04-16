using UnityEngine;
using System.Collections;

//Class with all skill function
public class SkillBase : MonoBehaviour {

	private GameObject Nyna;
	public GameObject Bullet;
	private GameObject Projectiles;

	void Start(){
		Nyna = GameObject.Find("Nyna");
		Projectiles = new GameObject("Projectiles");
	}

	public void ShootBullet(){

			
		//instantiate bulletnya
		GameObject BulletObject = Instantiate(Bullet, Nyna.transform.position+(Nyna.transform.up / 4), Nyna.transform.rotation) as GameObject;
		BulletObject.transform.parent = Projectiles.transform;
		//addforce bulletnya
		BulletObject.GetComponent<Rigidbody2D>().AddRelativeForce (transform.up * 100);
	}
}