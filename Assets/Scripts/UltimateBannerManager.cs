using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UltimateBannerManager : MonoBehaviour
{
    public TextMeshProUGUI UltBanner;

    public void ActivateUltBanner(string ultName, GameObject ultActivatedVoiceCue)
    {
        UltBanner.text = ultName;
        ultActivatedVoiceCue.SetActive(true);
        gameObject.SetActive(true);
    }
    public void DeactivateUltBanner()
    {
        gameObject.SetActive(false);
    }
    public void UltReady(GameObject ultReadyVoiceCue)
    {
        ultReadyVoiceCue.SetActive(true);
    }
}