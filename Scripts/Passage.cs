using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "NewPassage", menuName = "Passage")]
public class Passage : ScriptableObject
{
    public List<Fragment> Fragments;
}