using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BarChart : MonoBehaviour {

    public Bar barPrefab;
    List<Bar> bars = new List<Bar>();
    float chartHegiht;
    int max1DayCalorie = 3000;
    
    // Get the date 
    // TODO: Get the real date from database
    string[] dateLabels = { "2/1", "2/2", "2/3", "2/4", "2/5", "2/6", "2/7" };

	// Use this for initialization
	void Start () {
        // Get chart height
        //chartHegiht = Screen.height + GetComponent<RectTransform>().sizeDelta.y;
        chartHegiht = Screen.height ;

        // Get 7 days kcals
        // TODO: Get real kcals from database
        int[] weekKcals= { 1600, 2000, 1500, 1800, 1900, 1700, 1500 };

        // Draw Graph
        DisplayGraph(weekKcals);	
	}
   
    // Function to draw a bar int the graph 
    void DisplayGraph(int[] vals)
    {
        for (int i = 0; i < vals.Length; i++)
        {
            // Draw the bar based on one day kcal
            Bar newBar = Instantiate(barPrefab) as Bar;
            newBar.transform.SetParent(transform);
            newBar.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            RectTransform rt = newBar.bar.GetComponent<RectTransform>();

            // Normalize Kcals to 0 to 1 values
            float normalizedValue = (float)vals[i] / (float)max1DayCalorie;
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, chartHegiht * normalizedValue);
            
            // Draw date and value on the graph
            newBar.label.text = dateLabels[i];
            newBar.value.text = vals[i].ToString();

        }
    }	
}
