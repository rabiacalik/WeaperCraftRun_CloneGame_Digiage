using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DamagingBlock : MonoBehaviour
{
    public GameObject kamera;
    public float itmeMesafesi = 1f; // Duvarýn itme gücü
    Year Year;

    void Start()
    {
        // ProduceBullet deðiþkenine uygun bir deðer atayýn
        Year = FindObjectOfType<Year>();
        
    }

    void PlayerÝtekle(GameObject other)
    {
        Transform playerTransform = other.gameObject.transform;
        Vector3 itmeYönü = (playerTransform.position - transform.position).normalized;
        itmeYönü.y = 0f; // y eksenini sýfýrla
        Vector3 hedefPozisyon = playerTransform.position + itmeYönü * itmeMesafesi;
        playerTransform.position = hedefPozisyon;
    }
    /*
    void KameraÝtekle(GameObject other)
    {

        Transform playerTransform = other.gameObject.transform;
        Vector3 itmeYönü = (playerTransform.position - transform.position).normalized;
        itmeYönü.y = 0f; // y eksenini sýfýrla
        itmeYönü.z = 0f; // z eksenini sýfýrla
        Vector3 hedefPozisyon = playerTransform.position + itmeYönü * itmeMesafesi;
        playerTransform.position = hedefPozisyon;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerÝtekle(other.gameObject);
            //KameraÝtekle(kamera);
            Year.year--;
        }
    }
}

