using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValoviNeprijatelja : MonoBehaviour {

    [System.Serializable]
    public class Val {
        public Neprijatelj[] neprijatelji;
        public int brojac;
        public float vrijemeIzmeduStvaranja;
    }

    public Val[] valovi;
    public Transform[] tockeStvaranja;
    public float vrijemeIzmeduValova;

    private Val trenutniVal;
    private int indeksTrenutnogVala;
    private Transform igrac;
    private bool zavrsenoStvaranje;

    public GameObject glavniNeprijatelj;
    public Transform tockaStvaranjaGlavni;

    public GameObject zivotiGlavni;

    void Start() {
        igrac = GameObject.FindGameObjectWithTag("Igrac").transform;
        StartCoroutine(ZapocniSljedeciVal(indeksTrenutnogVala));
    }

    IEnumerator ZapocniSljedeciVal(int indeks) {
        yield return new WaitForSeconds(vrijemeIzmeduValova);
        StartCoroutine(StvaranjeVala(indeks));
    }

    IEnumerator StvaranjeVala(int indeks) {
        trenutniVal = valovi[indeks];
        for (int i = 0; i < trenutniVal.brojac; i++) {
            if (igrac == null) {
                yield break;
            }

            Neprijatelj nasumicniNeprijatelj = trenutniVal.neprijatelji[Random.Range(0, trenutniVal.neprijatelji.Length)];
            Transform nasumicnoMjesto = tockeStvaranja[Random.Range(0, tockeStvaranja.Length)];
            Instantiate(nasumicniNeprijatelj, nasumicnoMjesto.position, nasumicnoMjesto.rotation);

            if (i == trenutniVal.brojac - 1) {
                zavrsenoStvaranje = true;
            } else {
                zavrsenoStvaranje = false;
            }

            yield return new WaitForSeconds(trenutniVal.vrijemeIzmeduStvaranja);
        }
    }

    void Update() {
        if (zavrsenoStvaranje == true && GameObject.FindGameObjectsWithTag("Neprijatelj").Length == 0) {
            zavrsenoStvaranje = false;
            if (indeksTrenutnogVala + 1 < valovi.Length) {
                indeksTrenutnogVala++;
                StartCoroutine(ZapocniSljedeciVal(indeksTrenutnogVala));
            } else {
                //Debug.Log("KRAJ VALOVA");
                zivotiGlavni.SetActive(true);
                Instantiate(glavniNeprijatelj, tockaStvaranjaGlavni.position, tockaStvaranjaGlavni.rotation);
            }
        }
    }
}
