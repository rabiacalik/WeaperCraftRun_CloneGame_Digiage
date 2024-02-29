using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int money;
    public Text moneyAmount;
    
    public float distanceThreshold = 10.0f; // Mesafe sýnýrý text


    private MoneyCounter moneyCounter;
    private Vector3 ofset = new Vector3(0f, 0.5f, 0f);

    private void Start()
    {
        

        // MoneyCounter deðiþkenine uygun bir deðer ata
        moneyCounter = FindObjectOfType<MoneyCounter>();
    }

    void Update()
    {


        // para miktarýný belirten text, bir týk yukarýsýna yazýldý
        Vector3 ekranKonumu = Camera.main.WorldToScreenPoint(transform.position + ofset);
        moneyAmount.transform.position = ekranKonumu;
        moneyAmount.text = money.ToString();

        // Oyuncuya olan uzaklýðý hesaplayýn
        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (distance <= distanceThreshold)
        {
            // Mesafe sýnýrý dahilindeyse metni gösterin
            moneyAmount.gameObject.SetActive(true);
        }
        else
        {
            // Mesafe sýnýrý dýþýndaysa metni gizleyin
            moneyAmount.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ana para uzerinde degisiklik
            moneyCounter.moneyCounter += money;
            Destroy(gameObject);
        }

    }
}
