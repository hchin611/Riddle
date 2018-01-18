using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    private Text m_secondsText;
    [SerializeField]
    private Text m_minutesText;

    [SerializeField]
    private int m_minutesTime;
    [SerializeField]
    private int m_secondsTime;

    private bool m_Countdown;
    private int mTimePassed;
    private int mTimeLimit;

    private GameManager mGameManager;
    private Victory mVictory;

	// Sets up references and starts the countdown
	void Start ()
    {
        mGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mVictory = GameObject.Find("Victory").GetComponent<Victory>();
        TimeLimit();
        m_Countdown = true;
        StartCoroutine(TimeCountdown());
	}
	
	// Updates the timer display
	void Update () {
        m_minutesText.text = m_minutesTime.ToString("00");
        m_secondsText.text = m_secondsTime.ToString("00");

        if ((m_minutesTime == 0) && (m_secondsTime == 0))
        {
            m_Countdown = false;
            StopCoroutine(TimeCountdown());
        }
        
	}

    // Sets up the time limit
    void TimeLimit()
    {
        for(int i = 0; i < m_minutesTime; i++)
        {
            mTimeLimit = i * 60;
        }

        if (m_minutesTime >= 1)
            mTimeLimit += 60;

        mTimeLimit += m_secondsTime;
    }

    // 
    public void ActivateCountdown(bool aVictory)
    {
        m_Countdown = aVictory;
    }

    // Updates the timer
    IEnumerator TimeCountdown()
    {
        while(m_Countdown)
        {
            if(mTimePassed == mTimeLimit)
            {
                mVictory.PlayerHasLost(true);
                yield return null;
            }
            else if(m_secondsTime == 0)
            {
                yield return new WaitForSeconds(1);
                m_secondsTime = 59;
                m_minutesTime--;
                mTimePassed++;
            }
            else
            {
               yield return new WaitForSeconds(1);
               m_secondsTime--;
                mTimePassed++;
            }
        }
    }
}
