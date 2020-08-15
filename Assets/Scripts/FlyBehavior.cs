using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlyBehavior : MonoBehaviour {
    private const float pi = Mathf.PI;
    private void Update() {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        int numRays = 2;
        float stepSize = pi * 2 / numRays;
        for (float x = -2*pi; x < 2*pi; x += stepSize) {
            for (float y = -2*pi; y < 2*pi; y += stepSize) {
                Vector3 newDir = forward + new Vector3(x, y, 0);
                Debug.DrawRay(transform.position, newDir, Color.red);
            }
        }

    }
}
