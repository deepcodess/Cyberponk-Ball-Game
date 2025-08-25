using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    public Starter starter;
    
    private int Scoreleft = 0;
    private int Scoreright = 0;

    private bool started = false;

    public Text ScoreTextLeft;
    public Text ScoreTextRight;

    private BallController ballController;


    private Vector3 startingPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (this.started)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            //START GAME HERE
            this.starter.StartCountdown();
        }
    }

    public void StartGame()
    {
        this.ballController.Go();
    }


    public void ScoreGoalLeft()
    {
        Debug.Log("ScoreGoalLeft");
        this.Scoreright += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight()
    {
        Debug.Log("ScoreGoalRight");
        this.Scoreleft += 1;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
        this.ScoreTextLeft.text = this.Scoreleft.ToString();
        this.ScoreTextRight.text = this.Scoreright.ToString();
    }


    private void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }
}
