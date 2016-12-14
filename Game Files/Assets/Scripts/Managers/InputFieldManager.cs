using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    public GameObject registrationPanelStep1, registrationPanelStep2;
    public Image warningImage;
    
    void Start()
    {
    }

    public void SubmitRegistrationData()
    {
        Dictionary<string, string> fields = new Dictionary<string, string>();
        foreach (InputField inputField in registrationPanelStep1.GetComponentsInChildren<InputField>())
        {
            fields.Add(inputField.gameObject.tag, inputField.text);
        }
        foreach(InputField inputField in registrationPanelStep2.GetComponentsInChildren<InputField>())
        {
            fields.Add(inputField.gameObject.tag, inputField.text);
        }

        WWWFormGenerator.GenerateWWWForm(fields);
        WWWFormGenerator.POSTWWWForm(WWWActionType.RegisterUser, this);
    }
    private void CheckFieldAvailabilty(string key, string value)
    {
        KeyValuePair<string, string> field = new KeyValuePair<string, string>(key, value);
        WWWFormGenerator.GenerateWWWForm(field);
        StartCoroutine(WWWFormGenerator.POSTWWWForm(WWWActionType.CheckAvailability, this));
    }

    public void CheckUsernameAvailability(string value)
    {
        CheckFieldAvailabilty("username", value);
    }

    public void CheckEmailAvailability(string value)
    {
        CheckFieldAvailabilty("email", value);
    }
}

public class BadFormInputException: Exception{
	public BadFormInputException(string message): base(message){}
}