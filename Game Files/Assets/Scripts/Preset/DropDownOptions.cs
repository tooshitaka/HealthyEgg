using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DropDownOptions : MonoBehaviour {

    public Dropdown dropdown;
    public Text calorie;

    List<string> names = new List<string>() { "Select your preset" };

    // Get preset names from database
    void GetPresetFromDatabase()
    {
        // TODO: Get the current user's preset from database
        names.Add("Breakfast");
        names.Add("さんまラーメン");
    }

    // Eventhandler when one preset selected
    public void Dropdown_indexChanged(int index)
    {
        // TODO: Fill the calorie of selected preset 
        List<string> calorieList = new List<string>() { "0", "500", "800" }; 
        calorie.text = calorieList[index];
    }

    // Use this for initialization
    void Start()
    {
        // Get preset names from database
        GetPresetFromDatabase();
        // Set preset names to dropdown options
        SetListOptions();
    }

    // Set preset names to the dropdown lists
    void SetListOptions()
    {
        dropdown.AddOptions(names);
    }
}
