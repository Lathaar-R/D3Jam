using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Transform interactionTransform;
    void Trasnformation()
    {
        if(interactionTransform == null)
            interactionTransform = transform;
    }
}
