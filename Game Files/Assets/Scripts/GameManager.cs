using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    void Awake() {
        StringManager.SetLanguage(Language.Nederlands);
        if (Application.isEditor)
        {
            Debug.LogWarning("You are using this application in the Unity Editor. Behavior may not be the same as when used on iOS, Android, or Web.");
        }

    }
}
