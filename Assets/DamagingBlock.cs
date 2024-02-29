using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class DamagingBlock : MonoBehaviour
{
    public GameObject kamera;
    public float itmeMesafesi = 1f; // Duvar�n itme g�c�
    Year Year;

    void Start()
    {
        // ProduceBullet de�i�kenine uygun bir de�er atay�n
        Year = FindObjectOfType<Year>();
        
    }

    void Player�tekle(GameObject other)
    {
        Transform playerTransform = other.gameObject.transform;
        Vector3 itmeY�n� = (playerTransform.position - transform.position).normalized;
        itmeY�n�.y = 0f; // y eksenini s�f�rla
        Vector3 hedefPozisyon = playerTransform.position + itmeY�n� * itmeMesafesi;
        playerTransform.position = hedefPozisyon;
    }
    /*
    void Kamera�tekle(GameObject other)
    {

        Transform playerTransform = other.gameObject.transform;
        Vector3 itmeY�n� = (playerTransform.position - transform.position).normalized;
        itmeY�n�.y = 0f; // y eksenini s�f�rla
        itmeY�n�.z = 0f; // z eksenini s�f�rla
        Vector3 hedefPozisyon = playerTransform.position + itmeY�n� * itmeMesafesi;
        playerTransform.position = hedefPozisyon;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player�tekle(other.gameObject);
            //Kamera�tekle(kamera);
            Year.year--;
        }
    }
}

