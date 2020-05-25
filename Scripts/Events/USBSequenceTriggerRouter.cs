using UnityEngine;

public class USBSequenceTriggerRouter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.LogFormat("hit");
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);

            if (hit.collider == null || hit.collider.transform == transform)
            {
            Debug.LogFormat("return");
                return;
            }
            USBSequenceTrigger usbSequenceTrigger = hit.collider.gameObject.GetComponent<USBSequenceTrigger>();

            if (usbSequenceTrigger)
            {
                usbSequenceTrigger.TriggerEvent();
            }
        }
    }
}
