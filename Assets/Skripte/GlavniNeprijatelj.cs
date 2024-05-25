using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlavniNeprijatelj : MonoBehaviour {

    public int zivoti;
    public int faza2;
    public Neprijatelj[] neprijatelji;
    public float stvaranjePomak;

    private int zivotiStvaranja;
    public int stvoriSvakih;

    private Animator anim;

    public GameObject efektStvaranja;
    public GameObject efektUmiranja;
    public GameObject mrljaKrvi;

    private Slider slajderZivoti;
    private TranzicijaScena tranzicijaScena;

    void Start() {
        anim = GetComponent<Animator>();
        zivotiStvaranja = zivoti;
        slajderZivoti = GameObject.FindObjectOfType<Slider>();
        slajderZivoti.maxValue = zivoti;
        slajderZivoti.value = zivoti;
        tranzicijaScena = FindObjectOfType<TranzicijaScena>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Igrac") {
            collision.GetComponent<Igrac>().PrimiStetu(5);
        }
    }

    public void PrimiStetu(int steta) {
        zivoti -= steta;
        slajderZivoti.value = zivoti;
        if (zivoti <= 0) {
            Instantiate(mrljaKrvi, transform.position, transform.rotation);
            Instantiate(efektUmiranja, transform.position, transform.rotation);
            //Destroy(gameObject);
            gameObject.SetActive(false);
            slajderZivoti.gameObject.SetActive(false);
            //tranzicijaScena.UcitavanjeScene("Pobjeda");
            Invoke("KrajIgre", 1f);

        }

        if (zivoti <= faza2) {
            anim.SetTrigger("Faza2");
        }

        if (zivoti + stvoriSvakih < zivotiStvaranja) {
            zivotiStvaranja = zivoti;
            Neprijatelj nasumicniNeprijatelj = neprijatelji[Random.Range(0, neprijatelji.Length)];

            float pomakX = stvaranjePomak;
            float pomakY = stvaranjePomak;
            int randX = Random.Range(0, 101);
            int randY = Random.Range(0, 101);
            if (randX <= 50) pomakX = -stvaranjePomak;
            if (randY <= 50) pomakY = -stvaranjePomak;
            Instantiate(nasumicniNeprijatelj, transform.position + new Vector3(pomakX, pomakY, 0), transform.rotation);
            Instantiate(efektStvaranja, transform.position + new Vector3(pomakX, pomakY, 0), transform.rotation);
        }
    }

    public void aktivirajKoliziju() {
        BoxCollider2D sudarac = gameObject.GetComponent<BoxCollider2D>();
        sudarac.enabled = true;
    }

    public void KrajIgre() {
        tranzicijaScena.UcitavanjeScene("Pobjeda");
    }
}
