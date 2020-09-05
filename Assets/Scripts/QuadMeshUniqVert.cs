using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadMeshUniqVert : AbstractMeshGenerator
{
    [SerializeField] private Vector3[] vs = new Vector3[4];

    protected override void SetMeshNums()
    {
        numVertices = 6;
        numIndices = 6;
    }

    protected override void SetVertices()
    {
        vertices.Clear();
        vertices.Add(vs[0]);
        vertices.Add(vs[1]);
        vertices.Add(vs[2]);
        vertices.Add(vs[0]);
        vertices.Add(vs[2]);
        vertices.Add(vs[3]);
    }

    protected override void SetIndices()
    {
        indices.Clear();
        indices.Add(0);
        indices.Add(1);
        indices.Add(2);
        indices.Add(3);
        indices.Add(4);
        indices.Add(5);
    }

    protected override void SetNormals() { }
    protected override void SetTangents() { }
    protected override void SetUVs() { }
    protected override void SetVertexColors() { }
}
