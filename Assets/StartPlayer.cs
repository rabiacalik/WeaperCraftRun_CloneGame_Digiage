using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class StartPlayer : MonoBehaviour
{
    private Transform startingPosition; // Unity Edit�r�nde ba�lang�� pozisyonunu belirlemek i�in kullan�lacak transform.
    public Button toggleMovementButton; // Unity Edit�r�nde butonu atamak i�in kullan�lacak.
    GameObject playerObject;
    public MoneyBlock moneyBlock;
    public bool isMovementEnabled = false; // Oyuncunun hareket edilebilirli�ini kontrol etmek i�in kullan�lan bool de�i�keni.

    void Start()
    {
        startingPosition = new GameObject("StartingPosition").transform;
        startingPosition.position = new Vector3(-50f, 1.071f, 0f);

        moneyBlock = FindObjectOfType<MoneyBlock>();
        moneyBlock.playerExists = false;
        playerObject = GameObject.FindGameObjectWithTag("Player");

        if (startingPosition != null)
        {
            // E�er ba�lang�� pozisyonu atanm��sa, oyuncuyu o pozisyona ta��.
            playerObject.transform.position = startingPosition.position;
        }

        // Butonun g�r�n�rl���n� ayarla
        toggleMovementButton.gameObject.SetActive(moneyBlock.playerExists);

        // Buton i�in onClick eventi ekleniyor.
        toggleMovementButton.onClick.AddListener(ToggleMovement);
    }

    private void Update()
    {
        bool durum = moneyBlock.playerExists;
        // Butonun g�r�n�rl���n� ayarla
        toggleMovementButton.gameObject.SetActive(durum);

        // Buton i�in onClick eventi ekleniyor.
        toggleMovementButton.onClick.AddListener(ToggleMovement);
    }

    // Oyuncunun hareket edilebilirli�ini de�i�tiren fonksiyon.
    void ToggleMovement()
    {
        isMovementEnabled = !isMovementEnabled; // Hareket durumunu tersine �evir.
    }

}
