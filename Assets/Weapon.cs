using game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// silah kontrol
public class Weapon : MonoBehaviour
{
    private float hiz = 1f;
    private float sagSolHareketHizi = 1f;

     
    private void Update()
    {
            // Silahý sürekli ileriye doðru hareket ettirin.
            transform.Translate(Vector3.right * hiz * Time.deltaTime);

            // Saða sola hareket tuþlarýný kontrol edin.
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * sagSolHareketHizi * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.back * sagSolHareketHizi * Time.deltaTime);
            }
       
    }
}
