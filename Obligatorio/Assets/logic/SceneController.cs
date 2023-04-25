using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject player;
    public Camera cameraGame;

    public GameObject[] blockPreFab;

    public float gamePointer;

    public float sceneGenerationPoint;

    public Text Score;
 
    public Text Level;
    public bool loseGame;
    private AudioSource audio;

    public AudioClip audioFall;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncrementVariable", 3f, 5f);
        var score = PlayerPrefs.GetInt("Play.Score", 1);
        this.UpdateMonedas(score);
        audio = GetComponent<AudioSource>();
        gamePointer = -10;
        loseGame = false;
        Score.text = "Score: " + score;
        var level = PlayerPrefs.GetInt("Play.Level", 2)-1;
        Level.text = "Level: " + level;
    }
    
    private void IncrementVariable()
    {
        scoring.totalScore += (int)player.GetComponent<Player>().velocityMovement;
        PlayerPrefs.SetInt("Play.Score", scoring.totalScore);
        PlayerPrefs.SetInt("Play.Score.Lose", scoring.totalScore);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            var transform1 = cameraGame.transform;
            var position = transform1.position;
            var position1 = player.transform.position;
            position = new Vector3(
                position.x,
                position1.y,
                position.z
            );
            transform1.position = position;
            Score.text = "Score: " + scoring.totalScore.ToString();
            var level = PlayerPrefs.GetInt("Play.Level", 2)-1;
            Level.text = "Level: " + level;
           
        }
        else
        {
            if (!loseGame)
            {
                SceneManager.LoadScene(0);
            }
            if (loseGame)
            {
                PlayerPrefs.SetInt("Play.Score", 1);
                PlayerPrefs.Save();
                scoring.totalScore = 1;
                SceneManager.LoadScene(1);
                audio.PlayOneShot(audioFall,1f);
            }
        }
        while (player != null && gamePointer<player.transform.position.y+sceneGenerationPoint)
        {
            int indexBlock = Random.Range(0, blockPreFab.Length - 2);
            var score = PlayerPrefs.GetInt("Play.Score", 1);
            var level = PlayerPrefs.GetInt("Play.Level", 2)-1;
            if (score> 5*level)
            {
                indexBlock = 8;
            }
            else if (gamePointer < 0)
            {
                indexBlock = 0;
            }
            GameObject objectBlock = Instantiate(blockPreFab[indexBlock]);
            objectBlock.transform.SetParent(this.transform);
            Block block = objectBlock.GetComponent<Block>();
            objectBlock.transform.position = new Vector2(
                0, gamePointer + block.Size);
            gamePointer += block.Size;
        }
    }
    
    public void UpdateMonedas(int score)
    {
        scoring.totalScore = score;
        Score.text = "Score: " + scoring.totalScore.ToString();
    }
}
