using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnistiMe : MonoBehaviour {

    public float trajanje;
    void Start() {
        Destroy(gameObject, trajanje);
    }
}
