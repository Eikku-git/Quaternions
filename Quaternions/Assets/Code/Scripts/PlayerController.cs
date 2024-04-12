using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            transform.position += 5 * Time.deltaTime * Vector3.forward;
        } 
    }
}
