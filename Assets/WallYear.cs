using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallYear : MonoBehaviour
{
    // mermi gelince uzerindeki say�n�n artmas� laz�m
    // silah ile etkile�ime girdi�inde mermi ��k�� h�z� artmal�

    public int counter = 0;
    public Text counter_text;

    public float distanceThreshold = 10.0f; // Mesafe s�n�r� text
    Year year;

    void Start()
    {
        year = FindObjectOfType<Year>();
    }


    private void Update()
    {
        Vector3 ekranKonumu = Camera.main.WorldToScreenPoint(transform.position);
        counter_text.transform.position = ekranKonumu;
        counter_text.text = counter.ToString();


        // Oyuncuya olan uzakl��� hesaplay�n
        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distance <= distanceThreshold)
        {
            // Mesafe s�n�r� dahilindeyse metni g�sterin
            counter_text.gameObject.SetActive(true);
        }
        else
        {
            // Mesafe s�n�r� d���ndaysa metni gizleyin
            counter_text.gameObject.SetActive(false);
        }

        if (counter == 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            counter++;
        }

        if (other.CompareTag("Player"))
        {
            year.year += (counter);
        }
    }
}

