using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ResearchItem", menuName = "Scriptable Objects/ResearchItem")]
public class ResearchItem : ScriptableObject
{
    public string id;
    public string techName;
    public int techCost;
    public Texture2D techIcon;
    public string description;

    private void OnValidate()
    {
        id ??= Guid.NewGuid().ToString();
    }
}
