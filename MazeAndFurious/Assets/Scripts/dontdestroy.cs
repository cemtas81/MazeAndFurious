using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontdestroy : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
