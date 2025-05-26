using UnityEngine;

public class GameWon : MonoBehaviour
{
    [SerializeField] GameObject WellDoneScreen;
    public Timer timer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;

            SoundEffectManager.Play("GameWon");
            WellDoneScreen.SetActive(true);
            
        }
    }
}
