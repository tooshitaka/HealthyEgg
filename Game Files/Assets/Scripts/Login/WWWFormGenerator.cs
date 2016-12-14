using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class WWWFormGenerator
{
    public static WWWForm form;

    public static void GenerateWWWForm(Dictionary<string, string> fields)
    {
        form = new WWWForm();

        foreach (KeyValuePair<string, string> field in fields)
        {
            form.AddField(field.Key, field.Value);
        }
    
    }
    public static void GenerateWWWForm(KeyValuePair<string, string> field)
    {
        form = new WWWForm();
        form.AddField("key", field.Key);
        form.AddField("value", field.Value);
    }

    public static IEnumerator POSTWWWForm(WWWActionType action, InputFieldManager inputField)
    {
        WWW www = new WWW(action.Value, form);
        yield return www;
        if(www.text == "username already exists")
        {
            inputField.warningImage.gameObject.SetActive(true);
            Debug.Log("Hi!");
        }
        else
        {
            inputField.warningImage.gameObject.SetActive(false);
        }
    }
}
public class WWWActionType
{
    private WWWActionType(string value) { Value = value; }
    public string Value { get; set; }

    public static WWWActionType RegisterUser { get { return new WWWActionType("https://oege.ie.hva.nl/~keulenm001/InsertUserData.php"); } }
    public static WWWActionType CheckAvailability { get { return new WWWActionType("https://oege.ie.hva.nl/~keulenm001/CheckAvailability.php"); } }
}
