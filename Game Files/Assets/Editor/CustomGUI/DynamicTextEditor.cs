using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DynamicText))]
public class DynamicTextEditor : UnityEditor.UI.TextEditor {

    public static GameObject localizedInputFieldPrefab;

    public override void OnInspectorGUI() {

        DynamicText dte = (DynamicText)target;
        dte.stringKey = EditorGUILayout.TextField("StringKey", dte.stringKey);
        base.OnInspectorGUI();
    }

    [MenuItem("GameObject/UI/LocalizedInputField", false, 10)]
    public static void CreateLocalizedInputField(MenuCommand menuCommand)
    {
        GameObject go = Instantiate(Resources.Load("DynamicStringField") as GameObject, Vector3.zero, Quaternion.identity) as GameObject;
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);

        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }
}
