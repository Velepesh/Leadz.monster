using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BallInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event UnityAction ButtonPressed;
    public event UnityAction UpButtonReleased;

    public void OnPointerDown(PointerEventData data)
    {
        ButtonPressed?.Invoke();
    }

    public void OnPointerUp(PointerEventData data)
    {
        UpButtonReleased?.Invoke();
    }
}
