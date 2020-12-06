using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Coins : MonoBehaviour, IPointerDownHandler
{
    public int contador=0;

    public void OnPointerDown(PointerEventData eventData)
    {
        Aumentar.contador += 1;
        Destroy(this.gameObject);
    }
}
