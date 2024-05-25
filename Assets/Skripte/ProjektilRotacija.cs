using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilRotacija : MonoBehaviour {

    public int brzina;
    private Vector3 trenutniKut;
    private Quaternion trenutnaRotacija;

    void Update() {
        trenutniKut += new Vector3(0, 0, 1) * Time.deltaTime * brzina;
        trenutnaRotacija.eulerAngles = trenutniKut;
        transform.rotation = trenutnaRotacija;
    }
}
