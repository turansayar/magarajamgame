using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Subtitle", menuName = "Scriptable Objects/Subtitle", order = 0)]
public class SubtitleArea : ScriptableObject
{
    [TextArea(20, 100)]
    public string subtitleText;

    public bool withHiero;
    public float subtitleTime;
}
