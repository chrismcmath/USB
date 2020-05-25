using UnityEngine;

public class USBAnimationEvent : USBEvent
{
    public GameObject Target;
    public AnimationClip AnimationClip;

    private Animation _Animation;

    private void Awake()
    {
        if (Target)
        {
            _Animation = Target.GetComponentInChildren<Animation>();
        }
    }

    public override void TriggerEvent()
    {
        _Animation.clip = AnimationClip;
        _Animation.Play();
    }
}