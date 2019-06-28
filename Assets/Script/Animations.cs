using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Animations : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform rt;

    public void OnPointerDown(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(0.9f, 0.9f, 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.transform.localScale = new Vector3(1, 1, 1);
    }
}
