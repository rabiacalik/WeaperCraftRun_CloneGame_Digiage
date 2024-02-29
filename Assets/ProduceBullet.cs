using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game
{
    // silahtan mermi ateþlemek
    public class ProduceBullet : MonoBehaviour
    {
        public GameObject mermiPrefab; // Oluþturulacak mermi prefabý
        public float atesHizi = 1f; // Mermi atýþ hýzý (saniyede kaç mermi atýlacaðý)
        private float sonrakiAtesZamani; // Bir sonraki mermi atýþ zamaný

        void Start()
        {
            // Ýlk ateþ zamanýný baþlangýçtan bir saniye sonra olarak ayarla
            sonrakiAtesZamani = Time.time + 1f;
        }

        void Update()
        {
            // Eðer þu anki zaman, bir sonraki ateþ zamanýndan büyük veya eþitse ateþ et
            if (Time.time >= sonrakiAtesZamani)
            {
                AtesEt(); // Mermi atýþýný gerçekleþtir
                sonrakiAtesZamani = Time.time + 1f / atesHizi; // Bir sonraki mermi atýþ zamanýný güncelle
            }
        }

        void AtesEt()
        {
            // Mermi prefabýndan yeni bir mermi oluþtur ve bu nesnenin child'ý olarak ayarla
            GameObject yeniMermi = Instantiate(mermiPrefab, transform.position, transform.rotation, transform);
        }
    }

}
