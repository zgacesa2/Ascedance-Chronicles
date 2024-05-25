using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetakSismisa : MonoBehaviour {

    private Igrac igracSkripta;
    private Vector2 ciljanaPozicija;

    public float brzina;
    public int steta;

    public GameObject efektUnistenja;

    void Start() {
        igracSkripta = GameObject.FindGameObjectWithTag("Igrac").GetComponent<Igrac>();
        ciljanaPozicija = igracSkripta.transform.position;
    }

    void Update() {
        if (Vector2.Distance(transform.position, ciljanaPozicija) > 0.1f) {
            transform.position = Vector2.MoveTowards(transform.position, ciljanaPozicija, brzina * Time.deltaTime);
        } else {
            Instantiate(efektUnistenja, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Igrac") {
            igracSkripta.PrimiStetu(steta);
            Instantiate(efektUnistenja, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
