using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public int bosSpawnPoints;
	
	public GUIText scoreText;
    public GUIText playerHelth;
    public GUIText bossHelth;
    public GameObject bossPrefab;
    public GameObject gameOverLabel;
    public GameObject pauseLabel;
	
	private bool gameOver;
    public int helthCounter;
    public int helthCounterBoss;
    private int score;
	
	void Start ()
	{
		gameOver = false;
        playerHelth.text = "EEEEEEEEEE";
        helthCounter = 10;
        helthCounterBoss = 30;
        score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{

        if (gameOver)
        {
            gameOverLabel.SetActive(true);
            pauseLabel.SetActive(false);

        }

    }
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);				

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver||score> bosSpawnPoints)
			{

                if (score > bosSpawnPoints) {
                    Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
                    Quaternion spawnRotation = Quaternion.identity;
                    bossHelth.text = "EEEEEEEEEEEEEEEEEEEEEEEEEEEEEE";
                    Instantiate(bossPrefab, spawnPosition, spawnRotation);
                }
				break;

			}
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
	
	public void GameOver ()
	{

		gameOver = true;
	}
}