using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlyBehavior : MonoBehaviour {
    private const float TAU = 2 * Mathf.PI;

    private void Update() {
        DrawRays();
        ManualInputs();
    }

    private void ManualInputs() {
        if (Input.GetKey(KeyCode.A)) {
            transform.Rotate(0, -0.5f, 0);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Rotate(0, 0.5f, 0);
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.Rotate(0.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Rotate(-0.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space)) {
            transform.Translate(transform.forward * 0.1f);
        }
    }

    void DrawRays() {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        float stepSize = TAU / 2;
        for (float x = -TAU; x < TAU; x += stepSize) {
            for (float y = -TAU; y < TAU; y += stepSize) {
                Vector3 newDir = forward + new Vector3(x, y, 0);
                Debug.DrawRay(transform.position, newDir, Color.red);
            }
        }
    }
}
