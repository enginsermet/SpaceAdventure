using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool btnDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        btnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        btnDown = false;
    }
}
