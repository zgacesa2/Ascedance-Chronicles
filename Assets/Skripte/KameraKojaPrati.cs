using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKojaPrati : MonoBehaviour {

    public Transform igracPozicija;
    public float brzina;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start() {
        transform.position = igracPozicija.position;
    }

    void Update() {
        if (igracPozicija != null) {
            float ograniceniX = Mathf.Clamp(igracPozicija.position.x, minX, maxX);
            float ograniceniY = Mathf.Clamp(igracPozicija.position.y, minY, maxY);

            transform.position = Vector2.Lerp(transform.position, new Vector2(ograniceniX, ograniceniY), brzina * Time.deltaTime);
        }
    }
}
