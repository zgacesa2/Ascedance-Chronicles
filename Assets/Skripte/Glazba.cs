using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glazba : MonoBehaviour {

    private static Glazba instanca;

    private void Awake() {
        if (instanca == null) {
            instanca = this;
            DontDestroyOnLoad(instanca);
        } else {
            Destroy(gameObject);
        }
    }
}
