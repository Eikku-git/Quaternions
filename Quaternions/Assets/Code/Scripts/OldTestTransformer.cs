using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldTestTransformer : MonoBehaviour {

    MyRendererOld myRenderer;
    private float scale;
    private float rot;

    private void Awake() {
        myRenderer = GetComponent<MyRendererOld>();
    }

    void Update() {
        myRenderer.myTransform.rotation = MyQuaternion.RotateAroundAxis(new Vec3(1, 1, 0), rot += Mathf.PI / 2 * Time.deltaTime);
        myRenderer.myTransform.scale = (Mathf.Sin(scale += Mathf.PI / 3 * 2 * Time.deltaTime) + 2) * new Vec3((Mathf.Cos(scale) + 1) / 2, (Mathf.Cos(scale) + 1) / 2, 1);
    }
}
