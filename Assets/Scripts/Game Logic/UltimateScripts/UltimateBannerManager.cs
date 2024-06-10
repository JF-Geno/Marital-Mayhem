using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UltimateBannerManager : MonoBehaviour
{
    public GameObject UltBanner;

    public void ActivateUltBanner(Sprite ultName, GameObject? ultActivatedVoiceCue)
    {
        Debug.Log("Activate Banner");
        UltBanner.GetComponent<Image>().sprite = ultName;
        if (ultActivatedVoiceCue != null)
        {
            ultActivatedVoiceCue.SetActive(false);
            ultActivatedVoiceCue.SetActive(true);
        }
        gameObject.SetActive(true);
    }
    public void DeactivateUltBanner()
    {
        Debug.Log("Deactivate Banner");
        gameObject.SetActive(false);
    }
    public void UltReady(GameObject? ultReadyVoiceCue)
    {
        Debug.Log("Ult Ready");
        if (ultReadyVoiceCue != null)
        {
            ultReadyVoiceCue.SetActive(false);
            ultReadyVoiceCue.SetActive(true);
        }
    }
}