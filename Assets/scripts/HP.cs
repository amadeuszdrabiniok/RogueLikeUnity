using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{
    public int hp;
    public int numofhearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "enemy")
        {
            hp--;
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "MedKit")
        {
            hp++;
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        int p;

        if(hp>numofhearts)
        {
            hp = numofhearts;
        }

        if (hp == 0)
        {
            SceneManager.LoadScene("Zeldazul");
        }

        for(int i=0; i <hearts.Length; i++)
        {
            if(i<hp)
            {
               
                    hearts[i].sprite = fullHeart;
                 
               
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
