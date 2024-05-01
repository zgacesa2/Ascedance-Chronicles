using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trag : MonoBehaviour {

    public GameObject trag;
    public Transform pozicija;
    private float vrijemeTraga;
    public float vrijemeIzmeduTragova;

    void Update() {
        if (vrijemeTraga <= 0) {
            Instantiate(trag, pozicija.transform.position, Quaternion.identity);
            vrijemeTraga = vrijemeIzmeduTragova;
        } else {
            vrijemeTraga -= Time.deltaTime;
        }
    }
}
