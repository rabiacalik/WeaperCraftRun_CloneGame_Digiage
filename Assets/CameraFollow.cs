using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float hiz = 1.0f;

    private void Update()
    {
        transform.Translate(Vector3.right * hiz * Time.deltaTime);
    }

}
