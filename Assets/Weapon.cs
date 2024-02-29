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
            // Silah� s�rekli ileriye do�ru hareket ettirin.
            transform.Translate(Vector3.right * hiz * Time.deltaTime);

            // Sa�a sola hareket tu�lar�n� kontrol edin.
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
