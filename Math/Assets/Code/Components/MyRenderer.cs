using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MyRenderer : MonoBehaviour {

    [SerializeField] private Mesh unityMesh;
    [SerializeField] private Shader unityShader;
    public MyTransform myTransform { get; private set; }
    private Vector3[] vertices;

    private void Awake() {
        unityMesh = Utility.CloneMesh(unityMesh);
        myTransform = new MyTransform(transform);
    }

    public void Update() {
        RenderParams renderParams = new() {
            material = new Material(unityShader),
            receiveShadows = false,
            shadowCastingMode = ShadowCastingMode.Off
        };
        Graphics.RenderMesh(renderParams, unityMesh, 0, Matrix4x4.TRS(transform.position, myTransform.rotation, Vector3.one));
    }
}
