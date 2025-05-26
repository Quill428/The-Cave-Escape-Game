using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public heartsUI healthUI;

    private SpriteRenderer spriteRenderer;

    public static event Action OnPlayerDeath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        ResetHealth();

        spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
        Trap trap = collision.GetComponent<Trap>();
        if (trap && trap.damage > 0)
        {
            TakeDamage(trap.damage);
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHealth(maxHealth);
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.updateHearts(currentHealth);

        StartCoroutine(FlashRed());

        if(currentHealth <= 0)
        {

            //game over
            OnPlayerDeath.Invoke();
            
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red; //changes the colour of the Sprite to red
        yield return new WaitForSeconds(0.2f);//shows how long it'll take till the code contines
        spriteRenderer.color = Color.white;//changes the sprite to white (its original colour)
    }


}
