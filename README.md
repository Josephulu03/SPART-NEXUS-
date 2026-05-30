# SPART-NEXUS — AdMob Ads Integration for Unity

A ready-to-use Unity integration for Google AdMob ads, supporting **Banner**, **Interstitial**, and **Rewarded Ads** for both Android and iOS apps and games.

## 🚀 Features
- ✅ Banner Ads — persistent ads shown at top or bottom of screen
- ✅ Interstitial Ads — full-screen ads shown between scenes or levels
- ✅ Rewarded Ads — optional ads that reward users with in-game items or currency
- ✅ Works for both Mobile Games and Apps
- ✅ Supports Android & iOS

## 📋 Requirements
- Unity 2020.3 or higher
- [Google Mobile Ads Unity Plugin](https://github.com/googleads/googleads-mobile-unity)
- Android Build Support module
- iOS Build Support module
- An active [Google AdMob account](https://admob.google.com)

## ⚙️ Setup
1. Clone or download this repository
2. Open the project in Unity
3. Install the **Google Mobile Ads Unity Plugin**
4. In your AdMob dashboard, create your Ad Units and copy the IDs
5. Replace the placeholder Ad Unit IDs in the scripts with your own
6. Set your **AdMob App ID** in:
   - Android: `Assets/Plugins/Android/AndroidManifest.xml`
   - iOS: Unity will prompt during build

## 📱 Usage
Attach the ad scripts to any GameObject in your scene and call:

```csharp
// Banner Ad
AdsManager.Instance.LoadBannerAd();

// Interstitial Ad
AdsManager.Instance.LoadInterstitialAd();
AdsManager.Instance.ShowInterstitialAd();

// Rewarded Ad
AdsManager.Instance.LoadRewardedAd();
AdsManager.Instance.ShowRewardedAd();
