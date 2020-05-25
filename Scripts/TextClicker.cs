using System.Collections;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TextClicker : MonoBehaviour
{
    public TMP_Text Text;
    public Passage TargetPassage;

    private string _TMPString;
    private AudioSource _AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        RebuildString();
        StartCoroutine(AutoPlay());
    }

    IEnumerator AutoPlay()
    {
        for (int i = 0; i < TargetPassage.Fragments.Count; i++)
        {
            RebuildString(i);
            _AudioSource.PlayOneShot(TargetPassage.Fragments[i].Audio);
            yield return new WaitForSeconds(TargetPassage.Fragments[i].Audio.length);
        }
    }

    private void RebuildString(int boldIndex = -1)
    {
        _TMPString = string.Empty;

        for (int i = 0; i < TargetPassage.Fragments.Count; i++)
        {
            if (i == boldIndex)
            {
                _TMPString += string.Format("<color=yellow><b><link=\"{0}\">{1} </link></b></color>", i, TargetPassage.Fragments[i].Text.Trim());
            }
            else
            {
                _TMPString += string.Format("<link=\"{0}\">{1} </link>", i, TargetPassage.Fragments[i].Text.Trim());
            }
        }
        Text.text = _TMPString;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int linkIndex = TMP_TextUtilities.FindIntersectingLink(Text, Input.mousePosition, null);
            if (linkIndex > -1)
            {
                Debug.LogFormat("found: {0}", Text.textInfo.linkInfo[linkIndex].GetLinkText());
                _AudioSource.PlayOneShot(TargetPassage.Fragments[linkIndex].Audio);
                RebuildString(linkIndex);
            }
            else
            {
                Debug.LogFormat("nope");
            }
        }
    }
}
