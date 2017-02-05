using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DropDownOptions : MonoBehaviour {

    public Dropdown dropdown;
    public Text selectedName;

    List<string> names = new List<string>() { "Fred", "Banny", "Wilma", "Betty" };

    public void Dropdown_indexChanged(int index)
    {
        selectedName.text = names[index];
    }

    // Use this for initialization
    void Start()
    {
        SetListOptions();
    }

    // Set preset names to the dropdown lists
    void SetListOptions()
    {
        dropdown.AddOptions(names);
    }
}
