using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public enum Language
{
    English = 0,
    Nederlands = 1,
    日本語 = 2
}

public class StringManager{

    private static Dictionary<string, string> strings;

    private static Dictionary<Language, string> languages = new Dictionary<Language, string>() {
        {Language.English, "en" },
        {Language.Nederlands, "nl" },
        {Language.日本語, "jp" }
    };

    private static Language currentLanguage;
    
    public static Dictionary<string, string> Strings
    {
        get { return new Dictionary<string, string>(strings); }
        private set { }
    }

    public static Dictionary<Language, string> Languages
    {
        get
        {
            return new Dictionary<Language, string>(languages);
        }

        set
        {
            languages = value;
        }
    }

    public static Language CurrentLanguage
    {
        get
        {
            return currentLanguage;
        }

        private set
        {
            currentLanguage = value;
        }
    }

    public static void SetLanguage(Language language) {
        CurrentLanguage = language;
        XmlDocument xmlDocument = new XmlDocument();
        TextAsset xmlContents = (TextAsset) Resources.Load("Values" + "-" + languages[language] + "/strings", typeof(TextAsset));
        xmlDocument.LoadXml(xmlContents.text);
		strings = new Dictionary<string, string>();
		XmlNodeList list = xmlDocument.GetElementsByTagName ("resources");
		IEnumerator xmlIEnumerator = list [0].GetEnumerator ();

		while (xmlIEnumerator.MoveNext()) {
			XmlElement element = xmlIEnumerator.Current as XmlElement;
			strings.Add (element.GetAttribute ("name"), element.InnerText);
        }
    }

    public static string getString(string name) {
        if (strings == null || !strings.ContainsKey(name)) {
            return "STRING NOT FOUND";
        }
		return strings[name];
    }

    public delegate void LanguageEventHandler();
    public static event LanguageEventHandler OnLanguageUpdated;

    public static void LanguageUpdated() {
        if (OnLanguageUpdated != null) {
            OnLanguageUpdated();
        }
    }

}
