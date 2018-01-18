using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager sInstance = null;

    private Victory mVictory;
    private Timer mTimer;

    private IDictionary<int, string> dict = new Dictionary<int, string>();

    [SerializeField]
    private InputField mInputText;
    [SerializeField]
    private Text mRiddleText;
    [SerializeField]
    private Button mSubmitButton;

    private int riddleNumber;

    void Awake()
    {
        /*
        if (sInstance == null)
            sInstance = this;
        else if (sInstance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        */
    }

	// Initialize the dictionary of riddles and answers
	void Start ()
    {
        mInputText = GameObject.Find("InputField").GetComponent<InputField>();
        mRiddleText = GameObject.Find("Riddle Text").GetComponent<Text>();
        mSubmitButton = GameObject.Find("Submit Button").GetComponent<Button>();

        dict.Add(1, "ONE");
        dict.Add(2, "TWO");
        dict.Add(3, "THREE");
        dict.Add(4, "FOUR");
        dict.Add(5, "FIVE");
        RandomRiddle();
        mVictory = GameObject.Find("Victory").GetComponent<Victory>();
	}
	
	// Invoke button click event
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return))
        {
            mSubmitButton.onClick.Invoke();
        }
	}

    // Picks a random riddle within the dictionary to display
    public void RandomRiddle()
    {
        riddleNumber = Random.Range(1, 5);
        mRiddleText.text = dict[riddleNumber];
    }

    // If the submitted answer is correct, reset the riddle
    // Reference Victory and turn bool PlayerHasWon to true
    public void OnSubmitPressed()
    {
        if(mInputText.text.ToUpper() == dict[riddleNumber])
        {
            mInputText.text = "";
            riddleNumber = Random.Range(1, 5);
            mRiddleText.text = dict[riddleNumber];
            mVictory.PlayerHasWon(true);
            mTimer = GameObject.Find("Background Panel").GetComponent<Timer>();
            mTimer.ActivateCountdown(false);
        }
        else if(mInputText.text.ToUpper() != dict[riddleNumber])
        {
            mInputText.text = "";
        }
    }

}
