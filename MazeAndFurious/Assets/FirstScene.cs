using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
public class FirstScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        FB.Init();
    }
}
