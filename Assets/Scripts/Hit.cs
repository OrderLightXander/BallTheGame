using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hit : MonoBehaviour
{
	private bool clickedOn = false;
	private bool hasHitted = false;
	private int tries = 1;
	public float velocity;
	public Text scoreCounter;
	public Text numberOfTries;
	public Canvas canvas;
	public Button restartBTN;
	public Rigidbody2D rb = new Rigidbody2D();
	public GameObject TrajectoryDot;
	public GameObject Tile;
	public GameObject Hole;
	private Vector2 ForceToHit = new Vector2(1f, 1f);
	private Vector2 FinalForce = new Vector2(12f, 12f); 
	public static int highScore;

	void Start()
	{

		rb.simulated = true;
		GenerateLevel();
	}


	void Update()
	{
		if (tries != 0)
		{
			calculateTimeToHit();
			Draw();
			if (Input.GetMouseButtonDown(0) && !hasHitted)
			{
				clickedOn = true;
			}
			if (Input.GetMouseButtonUp(0) && !hasHitted)
			{
				Force();
			}
		}
	}
	void Force()
	{
		Vector2 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition)*1.2f;
		Vector2 ballToMouse = mouseWorldPoint - rb.position;
		int score = ScoreCounter.scoreValue + 1;
		rb.velocity = ForceToHit * 1.08f * (score) * 0.75f;
		clickedOn = false;
		hasHitted = true;
		ForceToHit = new Vector2(1f, 1f);
	}
	void Draw()
	{
		if (clickedOn && !hasHitted)
		{
			for (int i = 0; i < 18; i++)
			{
				GameObject trajectoryDot = Instantiate(TrajectoryDot);
				trajectoryDot.transform.position = CalculatePosition(0.1f * i);
				Destroy(trajectoryDot,0.02f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (hasHitted)
		{
			if(col.gameObject.tag == "Finish")
			{
				ScoreCounter.scoreValue++;
				ChangeToScene();
			}
			else
			{
				tries -= 1;
				hasHitted = false;
				canvas = canvas.GetComponent<Canvas>();
				canvas.enabled = true;
			}
		}
	}
	private Vector2 CalculatePosition(float elapsedTime)
	{
		Vector2 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 ballToMouse = mouseWorldPoint - rb.position;
		return Physics2D.gravity * elapsedTime * elapsedTime * 0.5f +
				   ForceToHit * elapsedTime * (ScoreCounter.scoreValue + 1) * 0.75f + rb.position;

	}
	void calculateTimeToHit()
	{
		if (clickedOn)
		{
			ForceToHit.x += Time.deltaTime * 3;
			ForceToHit.y += Time.deltaTime * 3;
			if(ForceToHit.x >= FinalForce.x)
			{
				Force();
			}
		}
	}
	void GenerateLevel()
	{
		int random = Mathf.RoundToInt(Random.Range(0, 7));
		
		for (int i = -8; i < 12; i++)
		{
			if(i == random) 
			{
				GameObject Level_Tile_Hole = Instantiate(Hole, new Vector3(i * 1.275f, -3, 0), Quaternion.identity);
			}
			else
			{
				GameObject Level_Tile = Instantiate(Tile, new Vector3(i * 1.275f, -3, 0), Quaternion.identity);
			}
		}
	}
	public void ChangeToScene()
	{
		SceneManager.LoadScene("Main");

	}
	public void Quit()
	{
		Application.Quit();
	}
}
