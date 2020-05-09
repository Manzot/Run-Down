using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickUI : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	public Image bgImage;
	public Image JoystickImage;

	public Vector2 InputDirection { set; get; }
	// Use this for initialization
	void Start ()
	{
		InputDirection = Vector2.zero;
	}
	
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos = Vector2.zero;

		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImage.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			
			pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

			float x = (bgImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (bgImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;		

			InputDirection = new Vector2 (x, y);
			InputDirection = (InputDirection.magnitude > 0.1) ? InputDirection.normalized : InputDirection;

			JoystickImage.rectTransform.anchoredPosition = new Vector2 (InputDirection.x * (bgImage.rectTransform.sizeDelta.x / 2.5f ), InputDirection.y * (bgImage.rectTransform.sizeDelta.y / 2.5f ));
		}


	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		InputDirection = Vector2.zero;
		JoystickImage.rectTransform.anchoredPosition = Vector2.zero;
	}
}
