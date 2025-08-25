using UnityEngine;

public class Starter : MonoBehaviour
{
    private GameController gameController;
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
        animator = GetComponent<Animator>();
    }


    public void StartCountdown()
    {
        animator.SetTrigger("StartCountdown");
    }

    public void StartGame()
    {
        gameController.StartGame();
    }
}
