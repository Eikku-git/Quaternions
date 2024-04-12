using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MyTransform {

    public static readonly Vec3 x_cartesian = new Vec3(1, 0, 0), y_cartesian = new Vec3(0, 1, 0), z_cartesian = new Vec3(0, 0, 1);
    private readonly Vec3[] basis = new Vec3[3] { x_cartesian, y_cartesian, z_cartesian };

    public Vec3 position { 
        get { 
            return unityTransform.position; 
        } 
        set {
            unityTransform.position = value;
        } 
    }

    public Vec3 localPosition { 
        get {
            return unityTransform.localPosition;
        } 
        set {
            unityTransform.localPosition = value;
        } 
    }

    private Transform unityTransform;

    public Vec3 scale { 
        get { return scaleInternal; } 
        set { 
            scaleInternal = value; 
            basis[0] *= scaleInternal.x; 
            basis[1] *= scaleInternal.y; 
            basis[2] *= scaleInternal.z; 
        } 
    }
    private Vec3 scaleInternal;
    public MyQuaternion rotation { 
        get { return rotationInternal; } 
        set { 
            rotationInternal = value; 
            basis[0] = rotationInternal.RotateVector(x_cartesian); 
            basis[1] = rotationInternal.RotateVector(z_cartesian); 
            basis[2] = rotationInternal.RotateVector(y_cartesian); 
        } 
    }
    private MyQuaternion rotationInternal;

    public MyTransform(Transform unityTransform) { 
        scale = new Vec3(1, 1, 1);
        rotation = MyQuaternion.identity;
        this.unityTransform = unityTransform;
    }

    public Vector3 TransformPosition(Vector3 vec3) {
        return new Vector3(basis[0].x * vec3.x + basis[1].x * vec3.y + basis[2].x * vec3.z, 
                            basis[0].y * vec3.x + basis[1].y * vec3.y + basis[2].y * vec3.z, 
                            basis[0].z * vec3.x + basis[1].z * vec3.y + basis[2].z * vec3.z); 
    }

    public Vector3 TransformVertex(Vertex vertex) {
        //var rot = rotation.RotateVector(vertex.position).ToVector3();
        return new Vector3(basis[0].x * vertex.position.x + basis[1].x * vertex.position.y + basis[2].x * vertex.position.z,
                            basis[0].y * vertex.position.x + basis[1].y * vertex.position.y + basis[2].y * vertex.position.z,
                            basis[0].z * vertex.position.x + basis[1].z * vertex.position.y + basis[2].z * vertex.position.z); 
    }
}
