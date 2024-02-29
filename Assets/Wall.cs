using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace game
{
    public class Wall : MonoBehaviour
    {
        // mermi gelince uzerindeki sayýnýn artmasý lazým
        // silah ile etkileþime girdiðinde mermi çýkýþ hýzý artmalý

        public int counter = 0;
        public Text counter_text;

        public float distanceThreshold = 10.0f; // Mesafe sýnýrý text

        ProduceBullet ProduceBullet;

        void Start()
        {
            // ProduceBullet deðiþkenine uygun bir deðer atayýn
            ProduceBullet = FindObjectOfType<ProduceBullet>();
        }


        private void Update()
        {
            // Text in ekrandaki konumunu ayarla
            Vector3 ekranKonumu = Camera.main.WorldToScreenPoint(transform.position);

            // ayarlanan konuma ata 
            counter_text.transform.position = ekranKonumu;

            // Metin öðesini güncelle
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
                ProduceBullet.atesHizi += (counter / 10);
            }
        }
    }

}
