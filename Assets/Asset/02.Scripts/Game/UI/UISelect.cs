using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISelect : MonoBehaviour
{
    [SerializeField]
    UnityEvent onSelectEvent;
    
    public UnityEvent OnSelectEvent
    {
        get { return onSelectEvent; }
    }
}
