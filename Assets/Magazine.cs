using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{
    // Sayac� ba�lang�� de�eri olarak 0 olarak ayarlad�k
    public int sayac = 0;
    public Transform tape_point;
    public Text counter_text;
    private Vector3 ofset = new Vector3(0, 1, 0);

    public bool player_collider = false;
    public bool tape_collider = false;
    //public bool tape_point_collider = false;

    private void Update()
    {

        // D�nya koordinatlar�ndan ekran koordinatlar�na d�n��t�rme
        Vector3 ekranKonumu = Camera.main.WorldToScreenPoint(transform.position + ofset);

        // Metin ��esinin konumunu ekran koordinatlar�na g�re ayarlama
        counter_text.transform.position = ekranKonumu;

        // Metin ��esini g�ncelle
        counter_text.text = sayac.ToString();


        if (sayac == 6)
        {
            Debug.Log("sarj�r dolu");
            // dolunca direkt hedefe gitsin !!!!
        }


        if (player_collider == true && tape_collider == false)
        {
            // Sola dogru hareket edecek
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }

        else if (tape_collider == true && tape_point != null)
        {
            // Hedefe do�ru y�nel
            Vector3 hedefYon = tape_point.position - transform.position;
            hedefYon.Normalize();

            // Hareket et
            transform.position += hedefYon * 3 * Time.deltaTime;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        // E�er mermi ile etkile�ime girerse mermiyi siler sayac� artt�r�r
        if (other.CompareTag("Bullet") && sayac <= 6)
        {
            // Mermiyi yok et
            Destroy(other.gameObject);

            // Sayac� artt�r
            sayac++;

            Debug.Log("Mermi yok edildi, sayac: " + sayac);
        }

        // Banda gitmesi i�in
        else if (other.CompareTag("Player") && !other.CompareTag("Tape"))
        {
            Debug.Log("S�LAH");

            player_collider = true;

        }

        // Banttan var�� noktas�na gitmesi i�in
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
