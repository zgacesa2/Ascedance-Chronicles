using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oruzje : MonoBehaviour {

    public GameObject projektil;
    public Transform mjestoIspucavanja;
    public float vrijemeIzmeduMetaka;
    private float vrijemeIspucavanja;
    public GameObject cesticeIspucavanja;

    void Update() {
        Vector2 smjer = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float kut = Mathf.Atan2(smjer.y, smjer.x) * Mathf.Rad2Deg;
        Quaternion rotacija = Quaternion.AngleAxis(kut - 90, Vector3.forward);
        transform.rotation = rotacija;

        if (Input.GetMouseButton(0)) {
            if (Time.time >= vrijemeIspucavanja) {
                vrijemeIspucavanja = Time.time + vrijemeIzmeduMetaka;
                Instantiate(projektil, mjestoIspucavanja.position, transform.rotation);
                Instantiate(cesticeIspucavanja, mjestoIspucavanja.position, transform.rotation);
            }
        }
    }
}
