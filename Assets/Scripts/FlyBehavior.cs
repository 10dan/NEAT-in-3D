using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FlyBehavior : MonoBehaviour {

    [Header("Fly vision")]
    [SerializeField] [Range(1, 1000)] int eyes;
    [SerializeField] float viewDist;
    [SerializeField] float turnFraction = 0.618033f;

    public Vector3[] directions;
    private NeuralNet brain;


    private void Awake() {
        int[] layers = { eyes, 20, 5 };
        brain = new NeuralNet(layers);
    }

    private void Update() {
        DrawRays();
        //ManualInputs();
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

        directions = new Vector3[eyes];

        float goldenRatio = (1 + Mathf.Sqrt(5)) / 2;
        float angleIncrement = Mathf.PI * 2 * goldenRatio;

        for (int i = 0; i < eyes; i++) {
            float t = (float)i / eyes;
            float inclination = Mathf.Acos(1 - 2 * t);
            float azimuth = angleIncrement * i;

            float x = Mathf.Sin(inclination) * Mathf.Cos(azimuth);
            float y = Mathf.Sin(inclination) * Mathf.Sin(azimuth);
            float z = Mathf.Cos(inclination);
            directions[i] = new Vector3(x, y, z);
        }


        Vector3 newDir = transform.position + (transform.rotation * new Vector3(x, y, z)) * viewDist;
        Ray ray = new Ray(transform.position, newDir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, viewDist)) {
            Debug.DrawLine(ray.origin, hit.point, Color.green);
        } else {
            Debug.DrawRay(transform.position, newDir, Color.red);

        }
    }
}

float Map(float value, float from1, float to1, float from2, float to2) {
    return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
}
}
