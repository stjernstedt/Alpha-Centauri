using UnityEngine;

[CreateAssetMenu(fileName = "ResearchItem", menuName = "Scriptable Objects/ResearchItem")]
public class ResearchItem : ScriptableObject
{
    public int id;
    public string techName;
    public int techCost;
}
