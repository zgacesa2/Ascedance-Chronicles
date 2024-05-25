using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokupiSrce : MonoBehaviour {

    Igrac skriptaIgraca;
    public int kolicina;
    public GameObject efektUzimanja;

    void Start() {
        skriptaIgraca = GameObject.FindGameObjectWithTag("Igrac").GetComponent<Igrac>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Igrac") {
            skriptaIgraca.DodajZivote(kolicina);
            Instantiate(efektUzimanja, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
