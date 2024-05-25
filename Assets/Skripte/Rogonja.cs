using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogonja : Neprijatelj {

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 ciljanaPozicija;
    private Animator anim;

    public float vrijemeIzmeduStvaranja;
    private float vrijemeStvaranja;

    public GameObject neprijateljStvaranje;

    public float brzinaNapada;
    public float stopUdaljenost;
    private float vrijemeNapada;

    public override void Start() {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        ciljanaPozicija = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (igrac != null) {
            if (Vector2.Distance(transform.position, ciljanaPozicija) > 0.5f) {
                transform.position = Vector2.MoveTowards(transform.position, ciljanaPozicija, brzina * Time.deltaTime);
                anim.SetBool("aktivacijaTrcanje", true);
            } else {
                anim.SetBool("aktivacijaTrcanje", false);

                if (Time.time >= vrijemeStvaranja) {
                    vrijemeStvaranja = Time.time + vrijemeIzmeduStvaranja;
                    anim.SetTrigger("stvaranjeNeprijatelja");
                }
            }

            if (Vector2.Distance(transform.position, igrac.position) < stopUdaljenost) {
                if (Time.time >= vrijemeNapada) {
                    StartCoroutine(Napad());
                    vrijemeNapada = Time.time + vrijemeIzmeduNapada;
                }
            }
        }
    }

    public void KreirajNeprijatelja() {
        if (igrac != null) {
            Instantiate(neprijateljStvaranje, transform.position, transform.rotation);
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
