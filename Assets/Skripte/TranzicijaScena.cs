using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranzicijaScena : MonoBehaviour {

    private Animator tranzicijaAnim;

    void Start() {
        tranzicijaAnim = GetComponent<Animator>();
    }

    public void UcitavanjeScene(string imeScene) {
        StartCoroutine(Tranzicija(imeScene));
    }

    IEnumerator Tranzicija(string imeScene) {
        tranzicijaAnim.SetTrigger("Kraj");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(imeScene);
    }

    public void IzlazIzIgre() {
        Application.Quit();
    }
}
