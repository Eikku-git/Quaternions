using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MyRendererOld : MonoBehaviour {

    [SerializeField] private MyMesh mesh;
    [SerializeField] private Shader shader;
    public MyTransform myTransform {  get; private set; } 
    private Mesh unityMesh;

    private void Awake() {
        myTransform = new MyTransform(transform);
        Vector3[] vertices = new Vector3[mesh.faces.Length * 3];
        for (int i = 0; i < mesh.faces.Length; i++) {
            for (int j = 0; j < mesh.faces[i].vertices.Length; j++) {
                vertices[i] = myTransform.TransformVertex(mesh.faces[i].vertices[j]);
            }
        }
        unityMesh = new Mesh();
        unityMesh.vertices = vertices;
        unityMesh.normals = new Vector3[vertices.Length];
    }

    public void Update() {
        Vector3[] vertices = new Vector3[mesh.faces.Length * 3];
        int[] triangles = new int[vertices.Length];
        int k = 0;
        for (int i = 0; i < mesh.faces.Length; i++) {
            for (int j = 0; j < mesh.faces[i].vertices.Length; j++) {
                vertices[k] = myTransform.TransformVertex(mesh.faces[i].vertices[j]);
                triangles[k] = k;
                k++;
            }
        }
        unityMesh.vertices = vertices;
        unityMesh.triangles = triangles;

        RenderParams renderParams = new RenderParams();
        renderParams.material = new Material(shader);
        renderParams.receiveShadows = false;
        renderParams.shadowCastingMode = ShadowCastingMode.Off;
        Graphics.RenderMesh(renderParams, unityMesh, 0, Matrix4x4.TRS(transform.position, UnityEngine.Quaternion.identity, Vector3.one));
    }
}
