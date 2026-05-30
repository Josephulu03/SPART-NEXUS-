using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Unity Ads Settings")]
    [SerializeField] private string androidGameId = "YOUR_ANDROID_GAME_ID";
    [SerializeField] private string iosGameId = "YOUR_IOS_GAME_ID";
    [SerializeField] private bool testMode = true;

    private string gameId;
    private bool initialized = false;

    public static AdManager Instance { get; private set; }

    // Ad Placement IDs
    public const string INTERSTITIAL = "Interstitial_Android";
    public const string REWARDED = "Rewarded_Android";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeAds();
    }

    private void InitializeAds()
    {
#if UNITY_IOS
        gameId = iosGameId;
#elif UNITY_ANDROID
        gameId = androidGameId;
#else
        gameId = androidGameId;
#endif

        if (!Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId, testMode, this);
        }
    }

    // === Initialization Callback ===
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialized successfully");
        initialized = true;
        LoadInterstitial();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Unity Ads Initialization Failed: {error} - {message}");
    }

    // === Load Ads ===
    public void LoadInterstitial()
    {
        Advertisement.Load(INTERSTITIAL, this);
    }

    public void LoadRewarded()
    {
        Advertisement.Load(REWARDED, this);
    }

    // === Show Ads ===
    public void ShowInterstitial()
    {
        if (initialized)
            Advertisement.Show(INTERSTITIAL, this);
    }

    public void ShowRewarded(System.Action onSuccess)
    {
        // You can use events or callbacks here
        Advertisement.Show(REWARDED, this);
    }

    // Load & Show Listeners
    public void OnUnityAdsAdLoaded(string placementId) => Debug.Log($"Ad loaded: {placementId}");
    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Failed to load ad {placementId}: {error} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Ad show failed: {placementId} - {error}");
    }

    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == REWARDED && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Rewarded ad completed - Give reward to player!");
            // Give player reward here
        }
    }
}
