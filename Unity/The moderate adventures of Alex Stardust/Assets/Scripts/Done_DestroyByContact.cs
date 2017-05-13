using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private Done_GameController gameController;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy"|| other.tag == "Boss")
		{
			return;
		}

		if (explosion != null)
		{
            Instantiate(explosion, transform.position, explosion.transform.rotation);
		}

        if (this.tag == "Boss")
        {

                gameController.helthCounterBoss = gameController.helthCounterBoss - 1;
                if (gameController.helthCounterBoss == 0)
                {
                    gameController.bossHelth.text = "";
                    Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

                }
                else
                {
                    gameController.bossHelth.text = "";
                    for (int i = 1; i <= gameController.helthCounterBoss; i++)
                    {
                        gameController.bossHelth.text = gameController.bossHelth.text + "E";
                    }
                    return;
                }
        }

        if (other.tag == "Player")
		{
            gameController.helthCounter = gameController.helthCounter - 1;
            if (gameController.helthCounter == 0)
            {
                gameController.playerHelth.text = "";
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
            else
            {
                Destroy(gameObject);
                    gameController.playerHelth.text = "";
                    for (int i = 1; i <= gameController.helthCounter; i++)
                    {
                    gameController.playerHelth.text = gameController.playerHelth.text + "E";
                    }
                return;
            }
			
		}
		
		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}