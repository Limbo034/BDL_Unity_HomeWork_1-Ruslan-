using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MobileJustik : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
	private Image joystikBG;
	[SerializeField] private Image joystik;
	private Vector2 inputVector;

	private void Start() 
	{
		joystikBG = GetComponent<Image>();
		joystik = transform.GetChild(0).GetComponent<Image>();
	}

  public virtual void OnPointerDown(PointerEventData ped)
  {
  	OnDrag(ped);
  }

  public virtual void OnPointerUp(PointerEventData ped)
  {
  	inputVector = Vector2.zero;
		joystik.rectTransform.anchoredPosition = Vector2.zero;
  }

  public virtual void OnDrag(PointerEventData ped)
  {
		
  	Vector2 pos;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(joystikBG.rectTransform,ped.position,ped.pressEventCamera, out pos))
		{
			pos.x = (pos.x / joystikBG.rectTransform.sizeDelta.x);
			pos.y = (pos.y / joystikBG.rectTransform.sizeDelta.y); 

			inputVector = new Vector2(pos.x,pos.y);
			inputVector=(inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
			Debug.Log(inputVector.x);
			Debug.Log(inputVector.y);

			joystik.rectTransform.anchoredPosition = new Vector2(inputVector.x*(joystikBG.rectTransform.sizeDelta.x/2), inputVector.y*(joystikBG.rectTransform.sizeDelta.y/2));
		}
  }

	public float Horizontal()
	{
		if(inputVector.x!=0) return inputVector.x;
		else return Input.GetAxis("Horizontal");
	}

	public float Vertical()
	{
		if(inputVector.y!=0) return inputVector.y;
		else return Input.GetAxis("Vertical");
	}
}