using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DropdownFieldFiller : MonoBehaviour {
    Dropdown dropdownField;

	void Start () {
        dropdownField = gameObject.GetComponent<Dropdown>();
        FillDropdownField();
        dropdownField.value = (int)StringManager.CurrentLanguage;
        dropdownField.onValueChanged.AddListener(delegate { onValueChanged(dropdownField);   });
       
	}
	
    void FillDropdownField()
    {
        List<string> dropdownOptions = new List<string>();
        foreach(Language language in StringManager.Languages.Keys)
        {
            dropdownOptions.Add(language.ToString());
        }
        dropdownField.AddOptions(dropdownOptions);
    }
    void onValueChanged(Dropdown target)
    {
        StringManager.SetLanguage((Language)target.value);
        StringManager.LanguageUpdated();
    }
}