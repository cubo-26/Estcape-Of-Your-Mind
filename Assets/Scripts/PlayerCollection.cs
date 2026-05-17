using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Coin")){
            Destroy(collision.gameObject);
            GameManager.Instance.AddScore(1);
            Debug.Log("hit coin!");
        }


    }
}
