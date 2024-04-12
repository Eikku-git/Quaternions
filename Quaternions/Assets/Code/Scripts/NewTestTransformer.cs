using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTestTransformer : MonoBehaviour {

    MyRenderer myRenderer;
    private float scale;
    private float rot;

    private void Start() {
        myRenderer = GetComponent<MyRenderer>();
    }

    MyQuaternion chaseRot = MyQuaternion.identity;

    void Update() {
        //myRenderer.myTransform.rotation = MyQuaternion.RotateAroundAxis(new Vec3(1, 1, 0), rot += Mathf.PI / 2 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)) {
            chaseRot = MyQuaternion.RotateAroundAxis(new Vec3(0, 1, 1), rot += Mathf.PI / 2);
        }
        myRenderer.myTransform.rotation = MyQuaternion.RotateTowards(myRenderer.myTransform.rotation, chaseRot, Mathf.PI * Time.deltaTime);
        //myRenderer.myTransform.scale = (Mathf.Sin(scale += Mathf.PI / 3 * 2 * Time.deltaTime) + 2) * new Vec3((Mathf.Cos(scale) + 1) / 2, (Mathf.Cos(scale) + 1) / 2, 1);
    }
}
