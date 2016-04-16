using UnityEngine;
using System.Collections;

public class EnemyAgro : MonoBehaviour {

	private GameObject Nyna;
	private readonly RaycastHit2D[] hit = new RaycastHit2D[10];
	private int objectInBetween, inBetweenRay;
	private bool chasing = false, around = false, horizontal = false, patrol = false;
	private Vector2 relativePos;
	private Vector3 lastSeenLocation;

	void Start(){
		Nyna = GameObject.Find("Nyna");
	}


	void FixedUpdate(){
		objectInBetween = Physics2D.LinecastNonAlloc (new Vector2 (transform.position.x, transform.position.y),
			new Vector2 (Nyna.transform.position.x, Nyna.transform.position.y), hit);

		if (objectInBetween == 3) {
			chasing = true;
			lastSeenLocation = Nyna.transform.position;		
		}

		if (objectInBetween > 6) {
			chasing = false;
		}

		if (chasing) {
			float angle;
			if (objectInBetween == 3) {
				relativePos = Nyna.transform.position - transform.position;
				angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
				transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
				GetComponent<Rigidbody2D> ().velocity = transform.up;
				around = false;
				patrol = false;
			} else {
				if (patrol == false) {
					relativePos = lastSeenLocation - transform.position;
					angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
					transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
					GetComponent<Rigidbody2D> ().velocity = transform.up;
					around = true;
				}
			}
			if (around == true && patrol == false) {
				if (horizontal == true) {
					if (Mathf.RoundToInt(transform.position.y) == Mathf.RoundToInt(lastSeenLocation.y) && Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(lastSeenLocation.x)) {
						patrol = true;
					} else if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(lastSeenLocation.x)) {
						if (relativePos.y > 0) {
							transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);
						} else {
							transform.rotation = Quaternion.AngleAxis (-180, Vector3.forward);
						}
						GetComponent<Rigidbody2D> ().velocity = transform.up;
					} else if (relativePos.x > 0) {
						transform.rotation = Quaternion.AngleAxis (-90, Vector3.forward);
					} else {
						transform.rotation = Quaternion.AngleAxis (90, Vector3.forward);
					}
					GetComponent<Rigidbody2D> ().velocity = transform.up;
				}
				if (horizontal == false) {
					if (Mathf.RoundToInt(transform.position.x) == Mathf.RoundToInt(lastSeenLocation.x) && Mathf.RoundToInt(transform.position.y) == Mathf.RoundToInt(lastSeenLocation.y)) {
						patrol = true;
					} else if (Mathf.RoundToInt(transform.position.y) == Mathf.RoundToInt(lastSeenLocation.y)) {
						if (relativePos.x > 0) {
							transform.rotation = Quaternion.AngleAxis (-90, Vector3.forward);
						} else {
							transform.rotation = Quaternion.AngleAxis (90, Vector3.forward);
						}

						GetComponent<Rigidbody2D> ().velocity = transform.up;
					} else if (relativePos.y > 0) {
						transform.rotation = Quaternion.AngleAxis (0, Vector3.forward);
					} else {
						transform.rotation = Quaternion.AngleAxis (-180, Vector3.forward);
					}
					GetComponent<Rigidbody2D> ().velocity = transform.up;
				}
			}
		}
	}

	public void OnCollisionStay2D(Collision2D Coll){
		if (Coll.gameObject.name == "Wall(Clone)" && patrol == false) {
			inBetweenRay = Physics2D.RaycastNonAlloc (transform.position, transform.up, hit);
			if (inBetweenRay == 10) {
				if (horizontal == true) {
					transform.position = transform.position - transform.up/25;
					horizontal = false;
				} else {
					transform.position = transform.position - transform.up/25;
					horizontal = true;
				}
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D coll){

		//gw comment soalnya gw ga ada gameObjectnya	
		
		if(coll.gameObject.name == "Nyna"){
			Nyna.GetComponent<PlayerStat>().TakeDamage(10);
		}
		
		if (patrol == true) {
			transform.Rotate (Vector3.forward*180);
			GetComponent<Rigidbody2D> ().velocity = transform.up;
		}
	}
	public void Wait(){
	}
}
/*
using UnityEngine;
using System.Collections;

public class EnemyAgro : MonoBehaviour {

	public GameObject Enemy;
	private GameObject Nyna;
	public bool straight = true;
	public Quaternion rotationEnemy;

	void Start(){
		Nyna = GameObject.Find ("Nyna");
	}

	public void OnTriggerStay2D(Collider2D Coll){
		if (straight) {
			if (Coll.gameObject.name == "Nyna") {
				//get Nyna Position relative to object
				Vector2 Delta = (Nyna.transform.position) - (transform.position);

				//get angle of delta
				float rotationAngle = Mathf.Atan2 (Delta.y, Delta.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis (rotationAngle - 90, Vector3.forward);
				GetComponent<Rigidbody2D> ().velocity = (transform.up);
			}
		}
	}

	//enemy hit wall
	public void OnCollisionStay2D(Collision2D Coll){
		if (Coll.gameObject.name == "Wall(Clone)") {
			Debug.Log ("Wall Hit");
			straight = false;
			Vector2 delta = Coll.gameObject.transform.position - this.transform.position;
			float rotationAngle1 = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

			Vector2 deltaNynaEnemy = Nyna.transform.position - this.transform.position;
			float rotationAngle2 = Mathf.Atan2(deltaNynaEnemy.y, deltaNynaEnemy.x) * Mathf.Rad2Deg;

			if (rotationAngle1 < rotationAngle2) {
				Debug.Log ("Align to the right");
				Debug.Log (rotationAngle1);
				Debug.Log (rotationAngle2);
				if (rotationAngle1 <= -145 && rotationAngle1 >= -180 && rotationAngle2 < 180 && rotationAngle2 > 90) {
					rotationEnemy = Quaternion.AngleAxis (((Mathf.FloorToInt (rotationAngle2 / 90)) * 90) - 90, Vector3.forward);
				} else {
					rotationEnemy = Quaternion.AngleAxis (((Mathf.CeilToInt (rotationAngle2 / 90)) * 90) - 90, Vector3.forward);
				}
				this.transform.rotation = rotationEnemy;
				this.GetComponent<Rigidbody2D> ().velocity = this.transform.up;

			} else if (rotationAngle1 > rotationAngle2){
				Debug.Log ("Align to the left");
				Debug.Log (rotationAngle1);
				Debug.Log (rotationAngle2);
				if (rotationAngle1 < 180 && rotationAngle1 >= 145 && rotationAngle2 > -180 && rotationAngle2 < -90) {
					rotationEnemy = Quaternion.AngleAxis (((Mathf.CeilToInt (rotationAngle2 / 90)) * 90) - 90, Vector3.forward);
				} else {
					rotationEnemy = Quaternion.AngleAxis (((Mathf.FloorToInt (rotationAngle2 / 90)) * 90) - 90, Vector3.forward);
				}
				this.transform.rotation = rotationEnemy;
				this.GetComponent<Rigidbody2D> ().velocity = this.transform.up;
			}
		}
	}

	//enemy exit wall
	public void OnCollisionExit2D(Collision2D Coll){
		if (Coll.gameObject.name == "Wall(Clone)") {
			Invoke ("ExitWall", 0.4f);
		}
	}
	public void ExitWall(){
		straight = true;
	}
}
*/
/*using UnityEngine;
using System.Collections;

public class EnemyAgro : MonoBehaviour {

	private GameObject Nyna;
	private readonly RaycastHit2D[] hit = new RaycastHit2D[10];
	private int objectInBetween;
	private bool chasing = false;
	private Vector2 relativePos;
	private Vector3 lastSeenLocation;
	private PlayerStat player; 

	void Start(){
		Nyna = GameObject.Find("Nyna");
		player = Nyna.GetComponent<PlayerStat>();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "Nyna"){
			player.TakeDamage(10);
			player.Stun(5);
		}
	}

	void FixedUpdate(){

		objectInBetween = Physics2D.LinecastNonAlloc(new Vector2(transform.position.x, transform.position.y),
									new Vector2(Nyna.transform.position.x,Nyna.transform.position.y), hit);

		if(objectInBetween == 3){
			chasing = true;
			lastSeenLocation = Nyna.transform.position;		
		}

		if(objectInBetween > 6){
			chasing = false;
		}

		if(chasing){
			if(objectInBetween == 3){
				relativePos = Nyna.transform.position - transform.position;
	            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
	            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	            GetComponent<Rigidbody2D>().velocity = transform.up;
	       	}else{
	       		relativePos = lastSeenLocation - transform.position;
	            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg - 90;
	            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	            GetComponent<Rigidbody2D>().velocity = transform.up;
	       	}
		}

		//Debug.Log(objectInBetween);
	}*/

	// public GameObject Enemy;
	// private GameObject Nyna;
	// public bool straight = true;
	// public string mathRound;
	// public Quaternion rotationEnemy;

	// void Start(){
	// 	Nyna = GameObject.Find ("Nyna");
	// }

	// public void OnTriggerStay2D(Collider2D Coll){
	// 	if (straight) {
	// 		if (Coll.gameObject.name == "Nyna") {
	// 			//get Nyna Position relative to object
	// 			Vector2 Delta = (Coll.transform.position) - (transform.position);

	// 			//get angle of delta
	// 			float rotationAngle = Mathf.Atan2 (Delta.y, Delta.x) * Mathf.Rad2Deg;
	// 			transform.rotation = Quaternion.AngleAxis (rotationAngle - 90, Vector3.forward);
	// 			GetComponent<Rigidbody2D> ().velocity = (transform.up);
	// 		}
	// 	}
	// }


	// //enemy hit wall
	// public void OnCollisionStay2D(Collision2D Coll){
	// 	Nyna = GameObject.Find ("Nyna");
	// 	if (Coll.gameObject.name == "Wall(Clone)") {
	// 		Debug.Log ("Wall Hit");
	// 		straight = false;
	// 		Vector2 delta = Coll.gameObject.transform.position - this.transform.position;
	// 		float rotationAngle1 = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

	// 		Vector2 deltaNynaEnemy = Nyna.transform.position - this.transform.position;
	// 		float rotationAngle2 = Mathf.Atan2(deltaNynaEnemy.y, deltaNynaEnemy.x) * Mathf.Rad2Deg;

	// 		if (rotationAngle1 < rotationAngle2) {
	// 			Debug.Log ("Align to the right");
	// 			Debug.Log (rotationAngle1);
	// 			Debug.Log (rotationAngle2);
	// 			if (rotationAngle1 <= -145 && rotationAngle1 >= -180 && rotationAngle2 < 180 && rotationAngle2 > 90) {
	// 				rotationEnemy = Quaternion.AngleAxis (((Mathf.FloorToInt (rotationAngle2 / 90)) * 90) - 90, Vector3.forward);
	// 			} else {
	// 				rotationEnemy = Quaternion.AngleAxis (((Mathf.CeilToInt (rotationAngle2 / 90)) * 90) - 90, Vector3.forward);
	// 			}
	// 			this.transform.rotation = rotationEnemy;
	// 			this.GetComponent<Rigidbody2D> ().velocity = this.transform.up;

	// 		} else if (rotationAngle1 > rotationAngle2){
	// 			Debug.Log ("Align to the left");
	// 			Debug.Log (rotationAngle1);
	// 			Debug.Log (rotationAngle2);
	// 			if (rotationAngle1 < 180 && rotationAngle1 >= 145 && rotationAngle2 > -180 && rotationAngle2 < -90) {
	// 				rotationEnemy = Quaternion.AngleAxis (((Mathf.CeilToInt (rotationAngle2 / 90)) * 90) - 90, Vector3.forward);
	// 			} else {
	// 				rotationEnemy = Quaternion.AngleAxis (((Mathf.FloorToInt (rotationAngle2 / 90)) * 90) - 90, Vector3.forward);
	// 			}
	// 			this.transform.rotation = rotationEnemy;
	// 			this.GetComponent<Rigidbody2D> ().velocity = this.transform.up;
	// 		}

	// 		//cek floor ato ceil
	// 		/*
	// 		if (Mathf.CeilToInt(rotationAngle1/90) - rotationAngle1/90 < Mathf.FloorToInt(rotationAngle1/90) - rotationAngle1/90){
	// 			mathRound = "CeilToInt";
	// 			if (rotationAngle2 > (((Mathf.CeilToInt(rotationAngle1/90))+1)*90) || rotationAngle2 < (((Mathf.CeilToInt(rotationAngle1/90))-1)*90)){
	// 				straight = true;
	// 				this.GetComponent<Rigidbody2D> ().velocity = this.transform.up;
	// 			}
	// 		} else {
	// 			if (rotationAngle2 > (((Mathf.FloorToInt(rotationAngle1/90))+1)*90) || rotationAngle2 < (((Mathf.FloorToInt(rotationAngle1/90))-1)*90)){
	// 				straight = true;
	// 				this.GetComponent<Rigidbody2D> ().velocity = this.transform.up;
	// 			}			
	// 		}
	// 		*/
	// 	}
	// }

	//  //enemy exit wall
 // public void OnCollisionExit2D(Collision2D Coll){
 //  if (Coll.gameObject.name == "Wall(Clone)") {
 //   Invoke ("ExitWall", 0.4f);
 //  }
 // }
 // public void ExitWall(){
 //  straight = true;
 // }
//}

// using UnityEngine;
// using System.Collections;

// public class EnemyAgro : MonoBehaviour {

// 	public GameObject Enemy;
// 	private GameObject Nyna;

// 	void Start(){
// 		Nyna = GameObject.Find ("Nyna");
// 	}

// 	public void OnTriggerStay2D(Collider2D Coll){
		
// 		if (Coll.gameObject.name == "Nyna") {
// 			//get Nyna Position relative to object
// 			Vector2 Delta = (Nyna.transform.position) - (transform.position);

// 			//get angle of delta
// 			float rotationAngle = Mathf.Atan2(Delta.y, Delta.x) * Mathf.Rad2Deg;
// 			transform.rotation = Quaternion.AngleAxis(rotationAngle - 90, Vector3.forward);
// 			GetComponent<Rigidbody2D> ().velocity = (transform.up);
// 		}
// 	}
// }
