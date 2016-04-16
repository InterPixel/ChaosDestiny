using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

 // public float minFlickerSpeed = 0.1F;
 // public float maxFlickerSpeed = 10000.0F;
 // public Light light;

 // void Start () {
 //  StartCoroutine(goFlicker());
 // }

 // IEnumerator goFlicker() { 
 //  while (true) {
 //   yield return new WaitForSeconds (1);
 //   light.intensity = 1;
 //   yield return new WaitForSeconds (1);
 //   light.intensity = 2;
 //  }
 // }

	public Light myLight;
	public float maxIntensity;
	public float minIntensity;



	void Update (){
		myLight.intensity = Random.Range(minIntensity, maxIntensity);

	}

}