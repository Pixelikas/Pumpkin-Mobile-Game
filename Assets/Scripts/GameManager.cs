using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public GameObject star;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRateSkull;
    public float spawnRateStar;
    public static bool gameStarted = false;

    public GameObject tapText;
    public GameObject titleText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI starsText;
    public static int score = 0;
    public static int stars = 0;

    public void Start(){

        AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0) && !gameStarted){

            StartSpawning();
            InvokeRepeating("SpawnStar", 2.25f, spawnRateStar);
            gameStarted = true;
            tapText.SetActive(false);
            titleText.SetActive(false);

        }

        starsText.text = stars.ToString();
        scoreText.text = score.ToString();
        
    }

    private void StartSpawning(){

        AudioManager.instance.PlayMusic(AudioManager.instance.gameMusic);
        InvokeRepeating("SpawnBlock", 0.5f, spawnRateSkull);
        InvokeRepeating("ScoreManage", 2f, spawnRateSkull);

    }
    private void SpawnBlock(){

        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);
        AudioManager.instance.PlaySoundEffects(AudioManager.instance.spawnSkull);

    }

     private void SpawnStar(){

        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(star, spawnPos, Quaternion.identity);

    }

    private void ScoreManage(){

        score++;
        AudioManager.instance.PlaySoundEffects(AudioManager.instance.scorePoint);

    }

}
