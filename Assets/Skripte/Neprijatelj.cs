using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neprijatelj : MonoBehaviour {
    
    public int zivoti;
    public float brzina;

    [HideInInspector]
    public Transform igrac;

    public float vrijemeIzmeduNapada;
    public int steta;
    public GameObject efektSmrt;

    public int vjerojatnostIspustiObjekt;
    public GameObject[] pokupiObjekti;

    public int vjerojatnostSrce;
    public GameObject pokupiSrce;

    public virtual void Start() {
        igrac = GameObject.FindGameObjectWithTag("Igrac").transform;
    }

    public void PrimiStetu(int steta) {
        zivoti -= steta;
        if (zivoti <= 0) {
            int nasumicniBroj = Random.Range(0, 101);
            if (nasumicniBroj < vjerojatnostIspustiObjekt) {
                GameObject nasumicniObjekt = pokupiObjekti[Random.Range(0, pokupiObjekti.Length)];
                Instantiate(nasumicniObjekt, transform.position, transform.rotation);
            }
            int nasumicnoSrce = Random.Range(0, 101);
            if (nasumicnoSrce < vjerojatnostSrce) {
                Instantiate(pokupiSrce, transform.position, transform.rotation);
            }
            Instantiate(efektSmrt, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
