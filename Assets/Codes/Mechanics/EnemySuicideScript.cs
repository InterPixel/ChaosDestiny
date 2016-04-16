using UnityEngine;
using System.Collections;

public class EnemySuicideScript : MonoBehaviour {

	private Vector3 currentPosition;
	public GameObject enemyPrefab;

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.name == "Wall(Clone)" || coll.gameObject.name == "Enemy"){
			

			Vector2 position = new Vector2(Random.Range(0F, 100F), Random.Range(0F, 100F));
			transform.position = position;
		}
	}


	void OnCollisionExit2D(){
		StartCoroutine(SuicideScript());
	}

	void Start(){
		StartCoroutine(SuicideScript());
	}

	void Update(){
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}

	IEnumerator SuicideScript(){
		currentPosition = transform.position;

		yield return new WaitForSeconds(1);

			if(transform.position == currentPosition){
				yield return new WaitForSeconds(1);					
				
				if(transform.position == currentPosition){
					yield return new WaitForSeconds(1);
					
					if(transform.position == currentPosition){
						Destroy(this);
					}
			
				}
			}

	}
}
