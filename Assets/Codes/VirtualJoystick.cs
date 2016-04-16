using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {


	private Image joystickImg;
	private Image joystickBG;
	private Vector3 inputVector;

	private void Start(){

		joystickBG = GetComponent<Image>();
		joystickImg = transform.GetChild(0).GetComponent<Image>();

	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag(ped);

	}

	public virtual void OnPointerUp(PointerEventData ped){
		
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, ped.position,ped.pressEventCamera, out pos)){

			pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);
			pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.y);

			inputVector = new Vector3(pos.x * 2 + 1, 0 , pos.y * 2 - 1);
			inputVector = (inputVector.magnitude > 1.0f)?inputVector.normalized: inputVector;

			joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (joystickBG.rectTransform.sizeDelta.x/3)
																	,inputVector.z * (joystickBG.rectTransform.sizeDelta.y/3));
		}

	}

	public float Horizontal(){

		if(inputVector.x != 0){
			return inputVector.x;
		}else{
			return Input.GetAxis("Horizontal");
		}
	}

	public float Vertical(){

		if(inputVector.x != 0){
			return inputVector.z;
		}else{
			return Input.GetAxis("Vertical");
		}
	}
}
