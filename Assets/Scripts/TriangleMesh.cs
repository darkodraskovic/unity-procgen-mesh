using UnityEngine;

public class TriangleMesh : AbstractMeshGenerator
{
    [SerializeField] Vector3[] vs = new Vector3[3];
    [SerializeField] private bool reverseTriangle;

    protected override void SetMeshNums()
    {
        numVertices = 3;
        numIndices = 3;
    }

    protected override void SetVertices()
    {
        vertices.Clear();
        vertices.AddRange(vs);
    }

    protected override void SetIndices()
    {
        indices.Clear();
        if (reverseTriangle)
        {
            indices.Add(0);
            indices.Add(2);
            indices.Add(1);
            return;
        }
        indices.Add(0);
        indices.Add(1);
        indices.Add(2);
    }

    protected override void SetNormals(){}

    protected override void SetTangents(){}

    protected override void SetUVs(){}

    protected override void SetVertexColors(){}

}
