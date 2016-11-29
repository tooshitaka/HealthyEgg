using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;

public class DateField : MonoBehaviour
{

    private static DateTime selectedDate = DateTime.Now;
    private AndroidJavaObject activity;
    private DateCallback dateCallback;
    public InputField birthDay, birthMonth, birthYear;
    public delegate void TextUpdater();
    public static event TextUpdater OnDateChanged;

    public void Start()
    {
        OnDateChanged += ChangeText;
    }

    class DateCallback : AndroidJavaProxy
    {
        public DateCallback() : base("android.app.DatePickerDialog$OnDateSetListener"){}
  
        void onDateSet(AndroidJavaObject view, int year, int monthOfYear, int dayOfMonth)
        {
            selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            OnDateChanged();
        }
    }

    public void OnClick()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                new AndroidJavaObject(
                    "android.app.DatePickerDialog",
                    activity,
                    new DateCallback(),
                    selectedDate.Year,
                    selectedDate.Month - 1,
                    selectedDate.Day
                    ).Call("show");
            }));
        }else
        {
            Debug.LogWarning("You need to run the game on Android to use this feature.");
        }
    }
    void ChangeText()
    {
        birthDay.text = selectedDate.Day.ToString();
        birthMonth.text = selectedDate.Month.ToString();
        birthYear.text = selectedDate.Year.ToString();
    }
}
