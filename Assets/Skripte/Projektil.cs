using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektil : MonoBehaviour {

    public float brzina;
    public float vrijemeTrajanja;
    public GameObject eksplozija;
    public int steta;

    public GameObject zvukProjektila;

    void Start() {
        Invoke("UnistavanjeProjektila", vrijemeTrajanja);
        Instantiate(zvukProjektila, transform.position, transform.rotation);
    }

    void Update() {
        transform.Translate(Vector2.up * brzina * Time.deltaTime);
    }

    private void UnistavanjeProjektila() {
        Instantiate(eksplozija, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Neprijatelj") {
            collision.GetComponent<Neprijatelj>().PrimiStetu(steta);
            UnistavanjeProjektila();
        }
        if (collision.tag == "GlavniNeprijatelj") {
            collision.GetComponent<GlavniNeprijatelj>().PrimiStetu(steta);
            UnistavanjeProjektila();
        }
    }
}
