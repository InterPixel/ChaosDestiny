using UnityEngine;
using System.Collections;

public class Aspect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Camera>().aspect = 16f/9f;
	}
}
