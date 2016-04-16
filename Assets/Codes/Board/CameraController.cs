using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject Kamera;
	private GameObject MiniMapKamera;

	private Vector2 cameraVelocity;
	private float posX, posY;
	public float smoothTimeX, smoothTimeY;

	void Start () {
		Kamera = GameObject.Find("Main Camera");
		MiniMapKamera = GameObject.Find("Camera");
	}
	
	
	void FixedUpdate () {

		posX = Mathf.SmoothDamp(Kamera.transform.position.x , transform.position.x , ref cameraVelocity.x, smoothTimeX);
		posY = Mathf.SmoothDamp(Kamera.transform.position.y, transform.position.y, ref cameraVelocity.y, smoothTimeY);

		Kamera.transform.position = new Vector3(posX, posY, Kamera.transform.position.z);

		MiniMapKamera.transform.position = new Vector3(posX, posY, MiniMapKamera.transform.position.z);


		
	}
}
