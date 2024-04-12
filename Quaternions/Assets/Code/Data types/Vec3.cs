using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Vec3  {

    public float x, y, z;

    public static readonly Vec3 Zero = new Vec3(); 

    public readonly Vec3 normalized { get { var mag = magnitude;  return new Vec3(x/mag, y/mag, z/mag); } }
    public readonly float magnitude { get { return Mathf.Sqrt(x * x + y * y + z * z); } }

    public Vec3(float x, float y, float z) {
        this.x = x; this.y = y; this.z = z;
    }

    public static Vec3 operator *(Vec3 vector, float scalar) {
        vector.x *= scalar; vector.y *= scalar; vector.z *= scalar;
        return vector;
    }

    public static Vec3 operator *(float scalar, Vec3 vector) {
        vector.x *= scalar; vector.y *= scalar; vector.z *= scalar;
        return vector;
    }

    public static Vec3 operator +(Vec3 vector1, Vec3 vector2) {
        Vec3 result = vector1;
        result.x += vector2.x; result.y += vector2.y; result.z += vector2.z;
        return result;
    }

    public static bool operator ==(Vec3 vector1, Vec3 vector2) {
        return vector1.x == vector2.x && vector1.y == vector2.y && vector1.z == vector2.z;
    }

    public static bool operator !=(Vec3 vector1, Vec3 vector2) {
        return vector1.x != vector2.x || vector1.y != vector2.y || vector1.z != vector2.z;
    }

    public override int GetHashCode() {
        return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
    }

    public override bool Equals(object obj) {
        return base.Equals(obj);
    }

    public static implicit operator Vec3 (Vector3 vector3) {
        return new Vec3(vector3.x, vector3.y, vector3.z);
    }

    public static implicit operator Vector3 (Vec3 vec3) {
        return new Vector3(vec3.x, vec3.y, vec3.z);
    }
}
