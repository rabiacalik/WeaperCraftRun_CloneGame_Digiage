using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Year : MonoBehaviour
{
    public Text text;
    public int year = 1800;

    private Vector3 ofset;

    private void Start()
    {
        ofset = new Vector3(-1.1f, 0f, 0f);
    }

    private void Update()
    {
        // Text in ekrandaki konumunu ayarla
        Vector3 ekranKonumu = Camera.main.WorldToScreenPoint(transform.position + ofset);

        // ayarlanan konuma ata 
        text.transform.position = ekranKonumu;

        // Metin öðesini güncelle
        text.text = year.ToString();
    }

}
