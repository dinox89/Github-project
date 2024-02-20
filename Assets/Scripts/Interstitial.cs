using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class Interstitial : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener
{
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    public Heathl heathl;
    string _adUnitId;

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    // Method to show interstitial ad (static)
    public static void ShowInterstitialAd()
    {
        Interstitial interstitial = FindObjectOfType<Interstitial>();
        if (interstitial != null)
        {
            interstitial.LoadAd(); // Load ad first
        }
        else
        {
            Debug.LogError("Interstitial script not found in the scene!");
        }
    }

    // Implement Load Listener and Show Listener interface methods:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
        ShowAd(); // Once ad is loaded, show it
    }

    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void PlayerReviveAfterAd()
    {
        Debug.Log("Ad was successfully watched. Player will now revive.");

        // Réinitialisez la position du joueur au dernier checkpoint
        heathl.Respaw();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnUnityAdsShowStart(string _adUnitId) { }
    public void OnUnityAdsShowClick(string _adUnitId) { }

    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Ad was successfully watched. Player will now revive.");
            PlayerReviveAfterAd();
        }
    }
}
