using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Igrac : MonoBehaviour {

    public int brzina;
    public int zivoti;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 micanjeBrzina;

    public Transform mjestoOruzja;

    public Image[] srca;
    public Sprite punoSrce;
    public Sprite praznoSrce;

    public Animator potres;
    public Animator napadPanel;

    private TranzicijaScena tranzicijaScena;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tranzicijaScena = FindObjectOfType<TranzicijaScena>();
    }

    void Update() {
        Vector2 micanjeInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        micanjeBrzina = micanjeInput.normalized * brzina;

        if (micanjeInput != Vector2.zero) {
            anim.SetBool("aktivacijaTrcanje", true);
        } else {
            anim.SetBool("aktivacijaTrcanje", false);
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + micanjeBrzina * Time.fixedDeltaTime);
    }

    public void PrimiStetu(int steta) {
        zivoti -= steta;
        potres.SetTrigger("Protresi");
        napadPanel.SetTrigger("Napad");
        AzurirajSrcaUI(zivoti);
        if (zivoti <= 0) {
            Destroy(gameObject);
            tranzicijaScena.UcitavanjeScene("Gubitak");
        }
    }

    public void PromjenaOruzja(Oruzje vrstaOruzja) {
        Destroy(GameObject.FindGameObjectWithTag("Oruzje"));
        Instantiate(vrstaOruzja, mjestoOruzja.transform.position, mjestoOruzja.transform.rotation, transform);
    }

    public void AzurirajSrcaUI(int trenutnoZdravlje) {
        for (int i = 0; i < srca.Length; i++) {
            if (i < trenutnoZdravlje) {
                srca[i].sprite = punoSrce;
            } else {
                srca[i].sprite = praznoSrce;
            }
        }
    }

    public void DodajZivote(int kolicina) {
        if (zivoti + kolicina > 5) {
            zivoti = 5;
        } else {
            zivoti += kolicina;
        }
        AzurirajSrcaUI(zivoti);
    }
}
