using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility {

    public static Mesh CloneMesh(Mesh mesh) {
        Mesh meshClone = new Mesh();
        meshClone.vertices = mesh.vertices;
        meshClone.triangles = mesh.triangles;
        meshClone.uv = mesh.uv;
        meshClone.uv2 = mesh.uv2;
        meshClone.normals = mesh.normals;
        meshClone.tangents = mesh.tangents;
        return meshClone;
    }

}
