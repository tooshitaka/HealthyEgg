using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;

public class FacebookHandling : MonoBehaviour {

    #region FacebookInitialization
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallBack, OnHideUnity);
        }
    }
    private void InitCallBack()
    {
        if (Application.isMobilePlatform)
        {
            if (FB.IsInitialized)
            {
                FB.ActivateApp();
            }
            else
            {
                Debug.Log("Failed to authenticate!");
            }
        }
    }
    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
    #endregion
    #region FacebookLogin
    private List<string> permissions = new List<string>(){"public_profile", "email", "user_friends"};
    public void LoginToFacebook()
    {
        FB.LogInWithReadPermissions(permissions, AuthCallback);
        
    }

    private void AuthCallback(ILoginResult result)
    {
		if (FB.IsLoggedIn) {
			var aToken = AccessToken.CurrentAccessToken;
			Debug.Log (aToken.UserId);
			foreach (string perm in aToken.Permissions) {
				Debug.Log (perm);
			}
			FB.API ("/me?fields=first_name,last_name", HttpMethod.GET, APICallback);
		}
        else
        {
            Debug.Log("User cancelled login");
        }
    }
    private void APICallback(IGraphResult result)
    {
		IDictionary data = result.ResultDictionary as IDictionary;
		if (data.Contains ("first_name")) {
			Debug.Log (data["first_name"]);
		}

    }
    #endregion


}
