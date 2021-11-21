using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
    public UnityEvent OnPlayerMissed;

    // Start is called before the first frame update
    void Awake()
    {
        OnPlayerMissed = new UnityEvent();
    }
}
