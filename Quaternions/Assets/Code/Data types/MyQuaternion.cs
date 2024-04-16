using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MyQuaternion {

    public readonly static MyQuaternion identity = new MyQuaternion(0, 0, 0, 1);

    public Vec4 rotation;

    public MyQuaternion(float x, float y, float z, float w) {
        rotation.x = x; rotation.y = y; rotation.z = z; rotation.w = w;
    }

    public MyQuaternion(Vec4 rotation) {
        this.rotation = rotation;
    }


    public static MyQuaternion RotateAroundAxis(Vec3 axis, float radians) {
        if (axis == Vec3.zero) { return identity; }
        MyQuaternion result = new MyQuaternion();
        radians /= 2;
        axis = Mathf.Sin(radians) * axis.normalized;
        result.rotation = new Vec4(axis.x, axis.y, axis.z, Mathf.Cos(radians));
        return result;
    }

    public static MyQuaternion RotateTowards(MyQuaternion from, MyQuaternion to, float maxRadians) {
        float angle = RadianAngle(from, to);
        if (angle == 0) {
            return to;
        }
        return Slerp(from, to, Math.Clamp(maxRadians / angle, 0, 1)); 
    }

    public static MyQuaternion Slerp(MyQuaternion from, MyQuaternion to, float lerp) {
        MyQuaternion result = new MyQuaternion((1 - lerp) * from.rotation.normalized + lerp * to.rotation.normalized);
        result.rotation = result.rotation.normalized;
        return result;
    }

    public static float RadianAngle(MyQuaternion a, MyQuaternion b) {
        return Mathf.Acos(Mathf.Min(Mathf.Abs(Vec4.Dot(a.rotation, b.rotation)), 1)) * 2f;
    }

    public Vec3 RotateVector(Vec3 vector) {
        float[,] columns = new float[3, 3] {
            { 1 - 2 * (rotation.y * rotation.y + rotation.z * rotation.z), 2 * (rotation.x * rotation.y - rotation.z * rotation.w), 2 * (rotation.x * rotation.z + rotation.y * rotation.w) },
            { 2 * (rotation.x * rotation.y + rotation.z * rotation.w), 1 - 2 * (rotation.x * rotation.x + rotation.z * rotation.z), 2 * (rotation.y * rotation.z - rotation.x * rotation.w) },
            { 2 * (rotation.x * rotation.z - rotation.y * rotation.w), 2 * (rotation.y * rotation.z + rotation.x * rotation.w), 1 - 2 * (rotation.x * rotation.x + rotation.y * rotation.y) }
        };
        Vec3 result;
        result.x = vector.x * columns[0,0] + vector.y * columns[1,0] + vector.z * columns[2,0];
        result.y = vector.x * columns[0,1] + vector.y * columns[1,1] + vector.z * columns[2,1];
        result.z = vector.x * columns[0,2] + vector.y * columns[1,2] + vector.z * columns[2,2];
        return result;
    }

    public static implicit operator Quaternion (MyQuaternion quaternion) {
        return new Quaternion(quaternion.rotation.x, quaternion.rotation.y, quaternion.rotation.z, quaternion.rotation.w);
    }
}
