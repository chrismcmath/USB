using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class USBSequenceTrigger : MonoBehaviour
{
    public List<USBEvent> Events = new List<USBEvent>();

    private void Awake()
    {
        if (FindObjectOfType<USBSequenceTriggerRouter>() == null)
        {
            GameObject go = new GameObject("EventRouter");
            go.AddComponent<USBSequenceTriggerRouter>();
        }
    }

    public void TriggerEvent()
    {
        foreach (USBEvent e in Events)
        {
            e.TriggerEvent();
        }
    }
}
