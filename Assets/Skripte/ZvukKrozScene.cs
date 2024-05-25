using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZvukKrozScene : MonoBehaviour {

    public float trajanje;

    void Start() {
        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, trajanje);
    }
}
