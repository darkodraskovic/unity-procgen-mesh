using UnityEngine;

public class QuadMesh : AbstractMeshGenerator
{
    [SerializeField] private Vector3[] vs = new Vector3[4];

    protected override void SetMeshNums()
    {
        numVertices = 4;
        numIndices = 6;
    }

    protected override void SetVertices()
    {
        vertices.Clear();
        vertices.AddRange(vs);
    }

    protected override void SetIndices()
    {
        indices.Clear();
        indices.Add(0);
        indices.Add(1);
        indices.Add(2);
        indices.Add(0);
        indices.Add(2);
        indices.Add(3);
    }

    protected override void SetNormals(){}
    protected override void SetTangents(){}
    protected override void SetUVs(){}
    protected override void SetVertexColors(){}
}
