using UnityEngine;
using System;
using JetBrains.Annotations;
using TMPro;

public class PowerUpGain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI ItemDescription;
    [SerializeField] GameObject itemGained;


    public void close()
    {
        itemGained.SetActive(false);
        Time.timeScale = 1;

    }
    public void Message1()
    {
        Debug.Log("Message called");
        
        ItemName.text = "Extra Jump";
        ItemDescription.text = "Click 'W', Up Arrow or Space Bar again to jump up to 3 times";
        itemGained.SetActive(true);
        Time.timeScale = 0;

    }
    public void Message2()
    {
        Time.timeScale = 0;
        itemGained.SetActive(true);
        ItemName.text = "Extra Jump";
        ItemDescription.text = "Click 'W', Up Arrow or Space Bar again to jump up to 4 times";
    }
    public void Message3()
    {
        Time.timeScale = 0;
        itemGained.SetActive(true);
        ItemName.text = "Extra Jump";
        ItemDescription.text = "Click 'W', Up Arrow or Space Bar again to jump up to 5 times";
    }
    public void Message4()
    {
        Time.timeScale = 0;
        itemGained.SetActive(true);
        ItemName.text = "Extra Jump";
        ItemDescription.text = "Click 'W', Up Arrow or Space Bar again to jump up to 6 times";
    }
}
