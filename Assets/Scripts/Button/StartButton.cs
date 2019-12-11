using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public Button  start;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
