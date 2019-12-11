using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    public Button retry;
    // Start is called before the first frame update
    void Start()
    {
        retry.onClick.AddListener(ResetGame);
    }

    void ResetGame()
    {
        GameObject.Find("Cubes").GetComponent<CubeManager>().ResetObject();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
