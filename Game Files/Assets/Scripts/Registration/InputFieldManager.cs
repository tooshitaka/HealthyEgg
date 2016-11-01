using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour {
	
	private enum FieldSet
	{
		MainFieldSet = 0,
		RegistrationFieldSetA = 1,
		RegistrationFieldSetB = 2,
		ForgotPasswordFieldSet = 3
	}


	public Text errorText;
	public GameObject  main_fc, registrationA_fc, registrationB_fc, forgotPassword_fc;

	private Dictionary<FieldSet, GameObject> fieldSets = new Dictionary<FieldSet, GameObject>();
	private FieldSet currentFieldSet;

	public delegate void InputValidatedEvendHandler(object source, EventArgs args);
	public event InputValidatedEvendHandler InputValidated;


	public void Start(){

		fieldSets.Add (FieldSet.MainFieldSet, main_fc);
		fieldSets.Add (FieldSet.RegistrationFieldSetA, registrationA_fc);
		fieldSets.Add (FieldSet.RegistrationFieldSetB, registrationB_fc);
		fieldSets.Add (FieldSet.ForgotPasswordFieldSet, forgotPassword_fc);

	
		currentFieldSet = FieldSet.MainFieldSet;
		fieldSets [FieldSet.MainFieldSet].SetActive (true);

		foreach (GameObject g in fieldSets.Values) {
			IList<InputField> inputFields = g.GetComponentsInChildren<InputField> ();
			foreach (InputField i in inputFields) {
				InputField iField = i;
				i.onEndEdit.AddListener (delegate {
					ValidateInput(iField);	
				});
			}
		}
	}

	//Navigates to the next fieldset by deactivating the current one and
	//activating the next.
	public void NavigateToFieldSet(int nextFieldSet){
		fieldSets [currentFieldSet].SetActive (false);
		fieldSets [(FieldSet)nextFieldSet].SetActive (true);
		currentFieldSet = (FieldSet)nextFieldSet;
	}

	public void NavigateToFieldSetWithCheck(int nextFieldSet){
		try{
			CheckFieldsInCurrentFieldSet();
			NavigateToFieldSet(nextFieldSet);
		}
		catch(BadFormInputException e){
			errorText.text = "The " + e.Message + "'s input is incorrect.";
		}
	}
		
	private void CheckFieldsInCurrentFieldSet()
    {

		switch (currentFieldSet) {

		case FieldSet.MainFieldSet:
			break;
		case FieldSet.RegistrationFieldSetA:
			break;
		case FieldSet.RegistrationFieldSetB:
			break;
		case FieldSet.ForgotPasswordFieldSet:
			break;

		}
    }

	//The endpoint for submitting a completed form.
	public void Submit(){
		try{
			CheckFieldsInCurrentFieldSet();
		}
		catch(BadFormInputException e){
			errorText.text = "The " + e.Message + "'s input is incorrect.";
		}
	}
		
	public void ValidateInput(InputField inputFieldToValidate){

		switch (inputFieldToValidate.tag) {
		case "password":


			break;

		case "username":


			break;

		default:
			Debug.Log(inputFieldToValidate.text);
			break;
		}
			
	}

	protected virtual void OnInputValidated(){
		if (InputValidated != null)
			InputValidated (this, EventArgs.Empty);
	}
}

public class BadFormInputException: System.Exception{
	public BadFormInputException(string message): base(message){}
}