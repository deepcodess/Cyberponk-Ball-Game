using UnityEngine;

public class EXITSceneManager : MonoBehaviour
{
    ///bool isPlaying = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //isPlaying = false;
            Exit();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
