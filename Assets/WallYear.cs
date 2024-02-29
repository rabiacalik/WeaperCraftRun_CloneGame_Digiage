using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallYear : MonoBehaviour
{
    // mermi gelince uzerindeki sayýnýn artmasý lazým
    // silah ile etkileþime girdiðinde mermi çýkýþ hýzý artmalý

    public int counter = 0;
    public Text counter_text;

    public float distanceThreshold = 10.0f; // Mesafe sýnýrý text
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


        // Oyuncuya olan uzaklýðý hesaplayýn
        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distance <= distanceThreshold)
        {
            // Mesafe sýnýrý dahilindeyse metni gösterin
            counter_text.gameObject.SetActive(true);
        }
        else
        {
            // Mesafe sýnýrý dýþýndaysa metni gizleyin
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

