using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class StartPlayer : MonoBehaviour
{
    private Transform startingPosition; // Unity Editöründe baþlangýç pozisyonunu belirlemek için kullanýlacak transform.
    public Button toggleMovementButton; // Unity Editöründe butonu atamak için kullanýlacak.
    GameObject playerObject;
    public MoneyBlock moneyBlock;
    public bool isMovementEnabled = false; // Oyuncunun hareket edilebilirliðini kontrol etmek için kullanýlan bool deðiþkeni.

    void Start()
    {
        startingPosition = new GameObject("StartingPosition").transform;
        startingPosition.position = new Vector3(-50f, 1.071f, 0f);

        moneyBlock = FindObjectOfType<MoneyBlock>();
        moneyBlock.playerExists = false;
        playerObject = GameObject.FindGameObjectWithTag("Player");

        if (startingPosition != null)
        {
            // Eðer baþlangýç pozisyonu atanmýþsa, oyuncuyu o pozisyona taþý.
            playerObject.transform.position = startingPosition.position;
        }

        // Butonun görünürlüðünü ayarla
        toggleMovementButton.gameObject.SetActive(moneyBlock.playerExists);

        // Buton için onClick eventi ekleniyor.
        toggleMovementButton.onClick.AddListener(ToggleMovement);
    }

    private void Update()
    {
        bool durum = moneyBlock.playerExists;
        // Butonun görünürlüðünü ayarla
        toggleMovementButton.gameObject.SetActive(durum);

        // Buton için onClick eventi ekleniyor.
        toggleMovementButton.onClick.AddListener(ToggleMovement);
    }

    // Oyuncunun hareket edilebilirliðini deðiþtiren fonksiyon.
    void ToggleMovement()
    {
        isMovementEnabled = !isMovementEnabled; // Hareket durumunu tersine çevir.
    }

}
