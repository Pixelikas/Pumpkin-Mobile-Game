using UnityEngine;

public class Star : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if(transform.position.y < -6f){

            Destroy(gameObject);

        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Player"))
        {

            AudioManager.instance.PlaySoundEffects(AudioManager.instance.collectStar);
            Destroy(gameObject);
            GameManager.stars++;

        }

    }
}
