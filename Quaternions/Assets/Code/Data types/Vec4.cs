using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public struct Vec4 {

    public static readonly Vec4 zero = new Vec4(x: 0);

    public float x, y, z, w;

    public static Vec4 operator *(Vec4 vector, float scalar) {
        vector.x *= scalar; vector.y *= scalar; vector.z *= scalar; vector.w *= scalar;
        return vector;
    }

    public Vec4(float x = 0, float y = 0, float z = 0, float w = 0) {
        this.x = x; this.y = y; this.z = z; this.w = w;
    }
}
