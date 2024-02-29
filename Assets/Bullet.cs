using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// mermi hareketleri
public class Bullet : MonoBehaviour
{
    public float hiz = 5f; // Mermi h�z�
    public float maksimumMesafe = 4f; // Mermi maksimum hareket mesafesi

    private float mevcutMesafe = 0f; // Mermi taraf�ndan kat edilen mesafe

    void Update()
    {
        // Mermiyi ileri do�ru hareket ettirme
        transform.Translate(Vector3.right * hiz * Time.deltaTime);

        // Mermi mesafesi maksimum mesafeyi a�t�ysa mermiyi sil
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
