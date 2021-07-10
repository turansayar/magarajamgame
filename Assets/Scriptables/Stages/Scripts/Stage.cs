using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stage", menuName = "Scriptable Objects/Stage", order = 2)]
public class Stage : ScriptableObject
{
    [TextArea(10, 20)]
    public string stageDescription;
}
