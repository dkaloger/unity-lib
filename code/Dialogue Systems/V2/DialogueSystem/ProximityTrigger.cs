using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DS.ScriptableObjects;
public class ProximityTrigger : MonoBehaviour
{
    
    [Serializable]
    public class ProximityEvent : UnityEvent{ }

    [FormerlySerializedAs("onAproach")]
    [SerializeField]
    ProximityEvent Event;
    private void OnTriggerEnter2D(Collider2D collision)
    {          
        Event.Invoke();
    }

  
}
