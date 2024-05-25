using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trkac : Neprijatelj {

    public float stopUdaljenost;
    private float vrijemeNapada;
    public float brzinaNapada;

    void Update() {
        if (igrac != null) {
            if (Vector2.Distance(transform.position, igrac.position) > stopUdaljenost) {
                transform.position = Vector2.MoveTowards(transform.position, igrac.position, brzina * Time.deltaTime);
            } else {
                if (Time.time >= vrijemeNapada) {
                    StartCoroutine(Napad());
                    vrijemeNapada = Time.time + vrijemeIzmeduNapada;
                }
            }
        }
    }

    IEnumerator Napad() {
        igrac.GetComponent<Igrac>().PrimiStetu(steta);

        Vector2 izvornaPozicija = transform.position;
        Vector2 pozicijaIgraca = igrac.position;

        float postotak = 0;
        while (postotak <= 1) {
            postotak += brzinaNapada * Time.deltaTime;
            float formula = (-Mathf.Pow(postotak, 2) + postotak) * 4; //broj raste od 0 do 1 i onda pada od 1 do 0
            transform.position = Vector2.Lerp(izvornaPozicija, pozicijaIgraca, formula);
            yield return null;
        }
    }
}
