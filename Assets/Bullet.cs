using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// mermi hareketleri
public class Bullet : MonoBehaviour
{
    public float hiz = 5f; // Mermi hýzý
    public float maksimumMesafe = 4f; // Mermi maksimum hareket mesafesi

    private float mevcutMesafe = 0f; // Mermi tarafýndan kat edilen mesafe

    void Update()
    {
        // Mermiyi ileri doðru hareket ettirme
        transform.Translate(Vector3.right * hiz * Time.deltaTime);

        // Mermi mesafesi maksimum mesafeyi aþtýysa mermiyi sil
        mevcutMesafe += hiz * Time.deltaTime;
        if (mevcutMesafe >= maksimumMesafe)
        {
            MermiyiSil();
        }
    }

    void MermiyiSil()
    {
        // Mermiyi yok etme
        Destroy(gameObject);
    }
}
