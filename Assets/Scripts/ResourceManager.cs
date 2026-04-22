using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [field: SerializeField] public int ore { get; set; } = 0;
    [field: SerializeField] public int power { get; set; } = 0;
    [field: SerializeField] public int research { get; set; } = 0;

    void Start()
    {

    }

}
