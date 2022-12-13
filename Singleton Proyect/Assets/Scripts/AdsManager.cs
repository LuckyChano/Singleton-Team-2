using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string gameID = "5059821";
    [SerializeField] string adToShow = "Rewarded_Android";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID);
    }

    public void PlayAd()
    {
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(adToShow);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ads Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android")
        {
            if (ShowResult.Finished == showResult)
            {
                if (GameManager.instance.stamina < 5)
                {
                    GameManager.instance.stamina++;
                }
                CurrencyManager.instance.currencyCoins += 5;
                Debug.Log("Te doy la recompensa");
            }
            else
            {
                Debug.Log("Dudo, no te doy nada");
            }
        }
    }
}
