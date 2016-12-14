
using System.Collections;
using UnityEngine;

public class UserRegistrator : MonoBehaviour{

    public bool RegisterUser(string facebookUserID, string firstName, string middleName, string insertion, string lastName)
    {
        WWWForm form = new WWWForm();
        form.AddField("uID", facebookUserID);
        form.AddField("fName", firstName);
        form.AddField("mName", middleName);
        form.AddField("ins", insertion);
        form.AddField("lName", lastName);

       // StartCoroutine(DoWWW(form));
        return true;
    }

    /*
    private IEnumerator DoWWW(WWWForm form)
    {
       // WWW www = new WWW(CREATEUSERURL, form);
        yield return www;
    }
    */
}
