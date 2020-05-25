using Malee.Editor;
using UnityEditor;

[CustomEditor(typeof(Passage))]
public class PassageEditor : Editor
{
    private ReorderableList _Fragments;

    private void OnEnable()
    {
        _Fragments = new ReorderableList(serializedObject.FindProperty("Fragments"), true, true, true);
    }

    public override void OnInspectorGUI()
    {
        _Fragments.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
