using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartsUI : MonoBehaviour
{
    public Image heartprefab;
    public Sprite fullHealthSprite;
    public Sprite emptyHeartSprite;

    private List<Image> Hearts = new List<Image>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMaxHealth(int maxHealth) //health count
    {
        foreach (Image heart in Hearts)
        {
            Destroy(heart.gameObject);
        }

        Hearts.Clear();

        for (int i = 0; i < maxHealth; i++)
        {
            Image newHeart = Instantiate(heartprefab, transform);
            newHeart.sprite = fullHealthSprite;
            newHeart.color = Color.white;
            Hearts.Add(newHeart);

        }
    }

    public void updateHearts(int currentHealth)
    {
        for (int i = 0; i < Hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                Hearts[i].sprite = fullHealthSprite;
                Hearts[i].color = Color.white;
            }
            else
            {
                Hearts[i].sprite = emptyHeartSprite;
                Hearts[i].color = Color.grey;
            }

        }
    }

}
