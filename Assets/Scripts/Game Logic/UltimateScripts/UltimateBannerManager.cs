using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UltimateBannerManager : MonoBehaviour
{
    public TextMeshProUGUI UltBanner;

    public void ActivateUltBanner(string ultName, GameObject? ultActivatedVoiceCue)
    {
        Debug.Log("Activate Banner");
        UltBanner.text = ultName;
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