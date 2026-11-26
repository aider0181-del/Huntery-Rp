
using UnityEngine;
using UnityEngine.EventSystems;
 
public class MobileJoystick : MonoBehaviour,
    IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform background;
    public RectTransform handle;

    public Vector2 Direction { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out position
        );

        float radius = background.sizeDelta.x / 2f;

        Direction = Vector2.ClampMagnitude(
            position / radius, 1f
        );

        handle.anchoredPosition = Direction * radius * 0.65f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}
