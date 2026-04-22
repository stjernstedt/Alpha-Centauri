using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ResearchItem", menuName = "Scriptable Objects/ResearchItem")]
public class ResearchItem : ScriptableObject
{
    public string id;
    public string techName;
    public int techCost;

    private void OnValidate()
    {
        if (id == null)
        {
            id = Guid.NewGuid().ToString();
        }
    }
}
