using UnityEngine;
using System.Collections;

public class DynamicText : UnityEngine.UI.Text{

    public string stringKey;


	protected override void Start ()
	{
		text = StringManager.getString (stringKey);
        StringManager.OnLanguageUpdated += OnLanguageUpdated;
		base.Start ();
	}

    public void OnLanguageUpdated()
    {
        text = StringManager.getString(stringKey);
    }
}
