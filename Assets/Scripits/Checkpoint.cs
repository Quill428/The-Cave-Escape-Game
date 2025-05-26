using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    GameController gameController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        //gameController = GameObject.FindGameObjectsWithTag("Player").GetComponent<GameController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //gameController.UpdateCheckpoint(transform.position);
        }
    }
}
