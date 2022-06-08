using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshFilter))]
public class DynamicMeshGenerator : MonoBehaviour
{
    Mesh mesh;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 20;
    public int zSize = 20;
    [Range(0.01f,0.99f)]
    public float perlinSmoothValue = 0.3f;
    public float perlinHieght = 2f;

    public void GenerateMesh()
    {
        GameObject panel1 = new GameObject();
        panel1.transform.parent = this.transform;
        mesh = new Mesh();
        meshFilter = panel1.AddComponent(typeof(MeshFilter)) as MeshFilter;
        meshRenderer = panel1.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        panel1.GetComponent<MeshFilter>().mesh = mesh;
        meshRenderer.sharedMaterial = Resources.Load("floor") as Material;

        CreateShape();
        UpdateMesh();
        panel1.transform.Rotate(0, 0, 180f);

        GameObject panel2 = new GameObject();
        panel2.transform.parent = this.transform;
        mesh = new Mesh();
        meshFilter = panel2.AddComponent(typeof(MeshFilter)) as MeshFilter;
        meshRenderer = panel2.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        panel2.GetComponent<MeshFilter>().mesh = mesh;
        meshRenderer.sharedMaterial = Resources.Load("floor") as Material;

        CreateShape();
        UpdateMesh();
        panel2.transform.Rotate(0, 270f, 90f);
    }

    float Noise(float smoothValue, float perlinHieght, int x, int z)
    {
        return Mathf.PerlinNoise(x * smoothValue, z * smoothValue) * perlinHieght;
    }

    void CreateShape()
    {
        vertices = new Vector3
        [
            (xSize + 1) * (zSize + 1)
        ];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, Noise(perlinSmoothValue, perlinHieght, x, z), z);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];
        int vert = 0;
        int triads = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[triads + 0] = vert + 0;
                triangles[triads + 1] = vert + xSize + 1;
                triangles[triads + 2] = vert + 1;
                triangles[triads + 3] = vert + 1;
                triangles[triads + 4] = vert + xSize + 1;
                triangles[triads + 5] = vert + xSize + 2;

                vert++;
                triads += 6;
            }

            vert++;
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        for(int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(vertices[i], 0.1f);
        }
    }
}
