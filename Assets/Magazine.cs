using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    // Sayacý baþlangýç deðeri olarak 0 olarak ayarladýk
    public int sayac = 0;
    public Transform tape_point;
    public Text counter_text;
    private Vector3 ofset = new Vector3(0, 1, 0);

    public bool player_collider = false;
    public bool tape_collider = false;
    //public bool tape_point_collider = false;

    private void Update()
    {

        // Dünya koordinatlarýndan ekran koordinatlarýna dönüþtürme
        Vector3 ekranKonumu = Camera.main.WorldToScreenPoint(transform.position + ofset);

        // Metin öðesinin konumunu ekran koordinatlarýna göre ayarlama
        counter_text.transform.position = ekranKonumu;

        // Metin öðesini güncelle
        counter_text.text = sayac.ToString();


        if (sayac == 6)
        {
            Debug.Log("sarjör dolu");
            // dolunca direkt hedefe gitsin !!!!
        }


        if (player_collider == true && tape_collider == false)
        {
            // Sola dogru hareket edecek
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }

        else if (tape_collider == true && tape_point != null)
        {
            // Hedefe doðru yönel
            Vector3 hedefYon = tape_point.position - transform.position;
            hedefYon.Normalize();

            // Hareket et
            transform.position += hedefYon * 3 * Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // Eðer mermi ile etkileþime girerse mermiyi siler sayacý arttýrýr
        if (other.CompareTag("Bullet") && sayac <= 6)
        {
            // Mermiyi yok et
            Destroy(other.gameObject);

            // Sayacý arttýr
            sayac++;

            Debug.Log("Mermi yok edildi, sayac: " + sayac);
        }

        // Banda gitmesi için
        else if (other.CompareTag("Player") && !other.CompareTag("Tape"))
        {
            Debug.Log("SÝLAH");

            player_collider = true;

        }

        // Banttan varýþ noktasýna gitmesi için
        else if (other.CompareTag("Tape"))
        {
            Debug.Log("BANT");

            player_collider = false;
            tape_collider = true;
        }

        else if (other.CompareTag("TapePoint"))
        {
            Destroy(gameObject);
        }
    }

}
