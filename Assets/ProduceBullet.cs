using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    // silahtan mermi ate�lemek
    public class ProduceBullet : MonoBehaviour
    {
        public GameObject mermiPrefab; // Olu�turulacak mermi prefab�
        public float atesHizi = 1f; // Mermi at�� h�z� (saniyede ka� mermi at�laca��)
        private float sonrakiAtesZamani; // Bir sonraki mermi at�� zaman�

        void Start()
        {
            // �lk ate� zaman�n� ba�lang��tan bir saniye sonra olarak ayarla
            sonrakiAtesZamani = Time.time + 1f;
        }

        void Update()
        {
            // E�er �u anki zaman, bir sonraki ate� zaman�ndan b�y�k veya e�itse ate� et
            if (Time.time >= sonrakiAtesZamani)
            {
                AtesEt(); // Mermi at���n� ger�ekle�tir
                sonrakiAtesZamani = Time.time + 1f / atesHizi; // Bir sonraki mermi at�� zaman�n� g�ncelle
            }
        }

        void AtesEt()
        {
            // Mermi prefab�ndan yeni bir mermi olu�tur ve bu nesnenin child'� olarak ayarla
            GameObject yeniMermi = Instantiate(mermiPrefab, transform.position, transform.rotation, transform);
        }
    }

}
