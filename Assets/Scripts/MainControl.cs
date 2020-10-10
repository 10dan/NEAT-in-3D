using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour {

    [Header("Initial Conditions")]
    [SerializeField] int numberFlys;
    [SerializeField] float arenaSize;
    [Header("Prefabs")]
    [SerializeField] GameObject flyPrefab;



    private void Start() {
        for (int i = 0; i < numberFlys; i++) {
            float x = UnityEngine.Random.Range(0, arenaSize);
            float y = UnityEngine.Random.Range(0, arenaSize);
            float z = UnityEngine.Random.Range(0, arenaSize);
            Vector3 pos = new Vector3(x,y,z);
            GameObject fly = Instantiate(flyPrefab, pos, Quaternion.identity);
        }
    }
}
