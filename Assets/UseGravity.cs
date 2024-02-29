using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGravity : MonoBehaviour
{
    private Rigidbody rigit;
    public GameObject box;

    void Start()
    {
        rigit = GetComponent<Rigidbody>();

        rigit.useGravity = false;
    }

    void Update()
    {

        if (box)
            rigit.useGravity = false;
        else
            rigit.useGravity = true;
    }
}
