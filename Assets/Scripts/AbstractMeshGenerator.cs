using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshCollider))]
[ExecuteInEditMode]
public abstract class AbstractMeshGenerator : MonoBehaviour
{
    protected List<Vector3> vertices;
    protected List<int> indices;

    protected List<Vector3> normals;
    protected List<Vector4> tangents;
    protected List<Vector2> uvs;
    protected List<Color32> colors;

    protected int numVertices;
    protected int numIndices;

    [SerializeField] protected Material material;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;
    private Mesh mesh;

    private void Start() 
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = material;

        meshCollider = GetComponent<MeshCollider>();

        InitMesh();
        SetMeshNums();
    }

    void Update()
    {
        CreateMesh();
    }

    private void InitMesh()
    {
        vertices = new List<Vector3>();
        indices = new List<int>();

        normals = new List<Vector3>();
        tangents = new List<Vector4>();
        uvs = new List<Vector2>();
        colors = new List<Color32>();
    }

    protected abstract void SetMeshNums();

    private bool ValidateMesh()
    {
        string errorStr = "";
        errorStr += vertices.Count == numVertices ? "" : "Should be " + numVertices + " vertices, but there are " + vertices.Count + ". ";
        errorStr += indices.Count == numIndices ? "" : "Should be " + numIndices + " indices, but there are " + indices.Count + ". ";

        errorStr += (normals.Count == numVertices || normals.Count == 0) ? "" : "Should be " + numVertices + " normals, but there are " + normals.Count + ". ";
        errorStr += (tangents.Count == numVertices || tangents.Count == 0) ? "" : "Should be " + numVertices + " tangents, but there are " + tangents.Count + ". ";
        errorStr += (uvs.Count == numVertices || uvs.Count == 0) ? "" : "Should be " + numVertices + " uvs, but there are " + uvs.Count + ". ";
        errorStr += (colors.Count == numVertices || colors.Count == 0) ? "" : "Should be " + numVertices + " colors, but there are " + colors.Count + ". ";

        bool isValid = string.IsNullOrEmpty(errorStr);
        if (!isValid)
        {
            Debug.LogError("Not drawing mesh. " + errorStr);
        }
        return isValid;
    }

    private void CreateMesh()
    {
        SetVertices();
        SetIndices();

        if (!ValidateMesh())
        {
            return;
        }

        mesh.SetVertices(vertices);
        mesh.SetTriangles(indices, 0);

        if (normals.Count == 0)
        {
            mesh.RecalculateNormals();
            normals.AddRange(mesh.normals);
        }
        mesh.SetNormals(normals);

        mesh.SetTangents(tangents);
        mesh.SetUVs(0, uvs);
        mesh.SetColors(colors);

        meshCollider.sharedMesh = mesh;
    }

    protected abstract void SetVertices();
    protected abstract void SetIndices();

    protected abstract void SetNormals();
    protected abstract void SetTangents();
    protected abstract void SetUVs();
    protected abstract void SetVertexColors();
}
