using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

    [SerializeField]
    private GameObject mVictoryObject;
    [SerializeField]
    private GameObject mFailedObject;

    [SerializeField]
    private GameObject mGameOverPanel;

    private bool mPlayerHasWon;
    private bool mPlayerHasLost;

    private Timer mTimer;

	// Use this for initialization
	void Start () {
        mTimer = GameObject.Find("Background Panel").GetComponent<Timer>();
	}
	
	// Moves the victory and failure text down
	void Update ()
    {

        if (mPlayerHasWon||mPlayerHasLost)
        {
            mVictoryObject.GetComponent<Transform>().position = new Vector3(Mathf.Lerp(mVictoryObject.transform.position.x, 0, Time.deltaTime), Mathf.Lerp(mVictoryObject.transform.position.y, 0, 2 * Time.deltaTime), -1);
            mFailedObject.GetComponent<Transform>().position = new Vector3(Mathf.Lerp(mFailedObject.transform.position.x, 0, Time.deltaTime), Mathf.Lerp(mFailedObject.transform.position.y, 0, 2 * Time.deltaTime), -1);
        }
    }

    // Starts up victory text
    public void PlayerHasWon(bool aVictory)
    {
        mPlayerHasWon = aVictory;
        OnVictory();
    }

    // Starts up failure text
    public void PlayerHasLost(bool aLost)
    {
        mPlayerHasLost = aLost;
        OnFailed();
    }

    void OnVictory()
    {
        mVictoryObject.SetActive(true);
        mFailedObject.SetActive(false);
        StartCoroutine(GameOver());
    }

    void OnFailed()
    {
        mFailedObject.SetActive(true);
        mVictoryObject.SetActive(false);
        StartCoroutine(GameOver());
    }

    // Resets victory and failure conditions
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        mPlayerHasLost = false;
        mPlayerHasWon = false;
        mGameOverPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
