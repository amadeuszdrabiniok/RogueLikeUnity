using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{
    private float coin = 0;
    public TextMeshProUGUI textCoins;
    public int numberOfCoins;
    private int watchdog = 100;

    void Update()
    {

        numberOfCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        if (numberOfCoins == 0 && watchdog <= 0)
        {
            SceneManager.LoadScene("Zeldazul");
            
        }
        watchdog--;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            Destroy(other.gameObject);
            coin++;
            textCoins.text = coin.ToString();
        }
    }
}
