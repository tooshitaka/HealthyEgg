using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DynamicText))]
public class DynamicTextEditor : UnityEditor.UI.TextEditor {

    public override void OnInspectorGUI() {

        DynamicText dte = (DynamicText)target;
        dte.stringKey = EditorGUILayout.TextField("StringKey", dte.stringKey);
        base.OnInspectorGUI();
    }
}
