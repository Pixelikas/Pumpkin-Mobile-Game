using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButton(0)){

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(touchPos.x < 0){

                rb.AddForce(Vector2.left * moveSpeed);

            }else{

                rb.AddForce(Vector2.right * moveSpeed);

            }


        }else{

            rb.linearVelocity = Vector2.zero;

        }
       
    }

    void OnCollisionEnter2D(Collision2D collision){

        if(collision.gameObject.CompareTag("Skull"))
        {

            AudioManager.instance.PlaySoundEffects(AudioManager.instance.playerDeath);
            GameManager.gameStarted = false;
            GameManager.stars = 0;
            GameManager.score = 0;
            SceneManager.LoadScene("Game");

        }

    }
}
