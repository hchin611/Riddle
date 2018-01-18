using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private GameManager mGameManager;

	// Use this for initialization
	void Start () {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnReplayButtonPressed()
    {
        SceneManager.LoadScene("Basic");
        mGameManager.RandomRiddle();
    }
}
