using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    Mesh mesh;
    // Maximum size up to 255 for 16-bit index buffers, but we can use 32-bit index buffers in Unity to go beyond that limit if needed.
    public int width;
    public int height;
    public float perlinHighlandsThreshold = 0.2f;
    public float perlinMountainsThreshold = 0.6f;
    public float perlinScale = 0.3f;
    public float perlinMagnitude = 2f;
    public float perlinOffsetX = 0f;
    public float perlinOffsetZ = 0f;

    Vector3[] vertices;
    int[] triangles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateMesh();
        UpdateMesh();

    }

    private void CreateMesh()
    {
        vertices = new Vector3[(width + 1) * (height + 1)];
        triangles = new int[width * height * 6];

        for (int i = 0, z = 0; z <= height; z++)
        {
            for (int x = 0; x <= width; x++)
            {
                float perlinX = (float)x / (float)width * perlinScale + perlinOffsetX;
                float perlinZ = (float)z / (float)height * perlinScale + perlinOffsetZ;
                float perlinY = (float)Mathf.PerlinNoise(perlinX, perlinZ) * perlinMagnitude;

                float y = 0;

                if (perlinY < perlinHighlandsThreshold) y = 0;
                if (perlinY > perlinHighlandsThreshold && perlinY < perlinMountainsThreshold) y = 2f;
                if (perlinY > perlinMountainsThreshold) y = 4f;

                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + width + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + width + 1;
                triangles[tris + 5] = vert + width + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    //private void OnDrawGizmos()
    //{
    //    if (vertices == null) return;

    //    for (int i = 0; i < vertices.Length; i++)
    //    {
    //        Gizmos.DrawSphere(vertices[i], 0.1f);
    //    }
    //}

}
