using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Mat4x4 {

    public Vec4[] mat;

    public Mat4x4(Vec4 column0, Vec4 column1, Vec4 column2, Vec4 column3) {
        mat = new Vec4[] {column0, column1, column2, column3};
    }
}
