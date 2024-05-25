using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokupi : MonoBehaviour {
    public Oruzje vrstaOruzja;
    public int vrijemePostojanja;
    public GameObject efektUzimanja;

    void Start() {
        Destroy(gameObject, vrijemePostojanja);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Igrac") {
            collision.GetComponent<Igrac>().PromjenaOruzja(vrstaOruzja);
            Instantiate(efektUzimanja, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
