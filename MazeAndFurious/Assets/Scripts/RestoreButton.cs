using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreButton : MonoBehaviour
{
    private void Start()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer &&
              Application.platform != RuntimePlatform.OSXPlayer)
        {
            gameObject.SetActive(false);
        }
    }

    public void ClickRestore()
    {
        IAPManager.Instance.RestorePurchases();
    }
}