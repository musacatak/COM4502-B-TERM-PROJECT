using UnityEngine;
using UnityEngine.UI;

public class AdsUI : MonoBehaviour
{
    #region Button Events

    public void ButtonClick_ShowInterstitialAd()
    {
        AdsManager.Instance.ShowInterstitialAd();
    }

    public void ButtonClick_ShowRewardedAd()
    {
        AdsManager.Instance.ShowRewardedAd();
    }

    public void ButtonClick_ShowBannerAd()
    {
        AdsManager.Instance.ShowBannerAd();
    }

    public void ButtonClick_HideBannerAd()
    {
        AdsManager.Instance.HideBannerAd();
    }

    public void ButtonClick_ShowSplashImage()
    {
        AdsManager.Instance.ShowSplashImage();
    }

    public void ButtonClick_ShowSplashVideo()
    {
        AdsManager.Instance.ShowSplashVideo();
    }

    #endregion
}
