using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable] 
public struct Vec4 {

    public static readonly Vec4 zero = new Vec4(x: 0);

    public float x, y, z, w;

    public readonly Vec4 normalized { get { var mag = magnitude;  return new Vec4(x/mag, y/mag, z/mag, w/mag); } }
    public readonly float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z + w * w); } }


    public Vec4(float x = 0, float y = 0, float z = 0, float w = 0) {
        this.x = x; this.y = y; this.z = z; this.w = w;
    }

    public static float Dot(Vec4 a, Vec4 b) {
        return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
    }

    public static Vec4 operator +(Vec4 vec1, Vec4 vec2) {
        return new Vec4(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z, vec1.w + vec2.w);
    }

    public static Vec4 operator *(float scalar, Vec4 vector) {
        vector.x *= scalar; vector.y *= scalar; vector.z *= scalar; vector.w *= scalar;
        return vector;
    }

    public static Vec4 operator *(Vec4 vector, float scalar) {
        vector.x *= scalar; vector.y *= scalar; vector.z *= scalar; vector.w *= scalar;
        return vector;
    }

    public static implicit operator Vec3 (Vec4 vec4) {
        return new Vec3(vec4.x, vec4.y, vec4.z);
    }

    public static implicit operator Vec4 (Vec3 vec3) {
        return new Vec4(vec3.x, vec3.y, vec3.z, 0);
    }

    public static implicit operator Vec4 (Vector4 vector4) {
        return new Vec4(vector4.x, vector4.y, vector4.z, vector4.w);
    }
}
