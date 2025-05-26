using UnityEngine;

public class Collection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItem item = collision.GetComponent<IItem>();
        if (item != null)
        {
            {
                item.Collect();
            }
        }
    }
}
