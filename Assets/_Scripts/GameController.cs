using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
	public GameObject Failed;
    public Vector3    spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
	public GameObject LevelNum; 
    public Text scoreText;
	public Text cooltime;
    private int score;
	public int CoolTimes = 100;
    private Vector3 spawnPosition = Vector3.zero;
    private Quaternion spawnRotation;

  //  public Text gameOverText;
    private bool gameOver;

    
    private bool restart;

    void Start ()
    {
        // Initialize score and update text.
        score = 0;
        UpdateScore ();

      //  gameOverText.text = "";
        gameOver = false;

       
        restart = false;

        StartCoroutine (SpawnWaves ());
		StartCoroutine(waitForOneSecond());
    }
	public IEnumerator waitForOneSecond()
	{
		while (CoolTimes > 0)
		{

				CoolTimes--;
				cooltime.text = CoolTimes.ToString ();

				yield return new WaitForSeconds (1);   
			} 
		GameOver ();

	}
    void Update ()
	{
		if (restart) {
			Failed.SetActive (true);
		

		}
	}

    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);

        while (true)
        {
            if(gameOver)
            {
				
                restart = true;
                break;
            }

            for (int i = 0; i < hazardCount; ++i) {
                spawnPosition.x = Random.Range (-spawnValues.x, spawnValues.x);
                spawnPosition.z = spawnValues.z;
                spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }

           // yield return new WaitForSeconds (waveWait);
        }
    }

    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore ();
    }

    void UpdateScore ()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
		LevelNum.SetActive (false);
		cooltime.transform.parent.gameObject.SetActive (false);
    //    gameOverText.text = "游戏结束";
    }
}
