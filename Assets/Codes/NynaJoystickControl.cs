using UnityEngine;
using System.Collections;

public class NynaJoystickControl : MonoBehaviour {

	public float moveForce = 1000;
	private VirtualJoystick joystick;
	Rigidbody2D nynaBody;


	void Start () {
		joystick = GameObject.Find("JoystickBG").GetComponent<VirtualJoystick>();
		nynaBody = GetComponent<Rigidbody2D>();
	}
	
	
	void FixedUpdate () {

		float x = joystick.Horizontal();
		float y = joystick.Vertical();
	
		Vector2 moveVec = new Vector2(x, y);
		moveVec = (moveVec.magnitude > 1.0f) ? moveVec.normalized : moveVec;
		nynaBody.AddForce(moveVec * moveForce);
	
		//rotation
		//change Vector to degrees
		float rotationAngle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

		rotationAngle = (rotationAngle + 360) % 360;
		
		if(x != 0f || y != 0f){
		//applying degrees euler
		transform.Rotate(0,0,(270 - (transform.eulerAngles.z - rotationAngle)));
		}
		
	}
}