using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class InteractableObject : MonoBehaviour
{
    public static Action<Vector3> PointerClick;
    public static Action PointerEnter;
    public static Action PointerExit;

    public void OnPointerEnter()
    {
        PointerEnter?.Invoke();
    }

    public void OnPointerExit()
    {
        PointerExit?.Invoke();
    }

    public void OnPointerClick()
    {
        PointerClick?.Invoke(transform.position);
    }

}
