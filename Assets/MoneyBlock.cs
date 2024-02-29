using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBlock : MonoBehaviour
{
    public int counter;
    public Text _text;

    public bool playerExists = false;

    public float distanceThreshold = 10.0f; // Mesafe s�n�r� text

    private void Update()
    {

        // blogu yok etmek i�iin counter� , ekrana yazar
        Vector3 ekranKonumu = Camera.main.WorldToScreenPoint(transform.position);
        _text.transform.position = ekranKonumu;
        _text.text = counter.ToString();


        // Oyuncuya olan uzakl��� hesaplay�n
        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (distance <= distanceThreshold)
        {
            // Mesafe s�n�r� dahilindeyse metni g�sterin
            _text.gameObject.SetActive(true);
        }
        else
        {
            // Mesafe s�n�r� d���ndaysa metni gizleyin
            _text.gameObject.SetActive(false);
        }

        if (counter == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Player"))
        {
            playerExists = true;
        }

        if ( other.CompareTag("Bullet"))
        {
            if( counter > 0)
                counter--;
        }
    }
}
