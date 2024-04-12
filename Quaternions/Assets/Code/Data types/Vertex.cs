using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Vertex {
    public Vec3 position;

    public static implicit operator Vertex(Vector3 v) {
        return new Vertex() { position = v };
    }
}
