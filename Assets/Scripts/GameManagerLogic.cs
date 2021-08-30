using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageItemText;
    public Text playerItemText;

    void Awake()
    {
        stageItemText.text = "/ " + totalItemCount;
    }

    public void GetItem(int count)
    {
        playerItemText.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }

    
}