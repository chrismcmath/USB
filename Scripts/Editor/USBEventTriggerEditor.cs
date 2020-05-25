using Malee.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(USBSequenceTrigger))]
public class USBEventTriggerEditor : Editor
{
    private ReorderableList _Events;

    private void OnEnable()
    {
        _Events = new ReorderableList(serializedObject.FindProperty("Events"), true, true, true);
    }

    public override void OnInspectorGUI()
    {
        _Events.DoLayoutList();
        
        if (GUILayout.Button("Add Event"))
        {
            _Events.AddItem(new USBAnimationEvent());
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}