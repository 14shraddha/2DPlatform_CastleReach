//GameController

/*  Developed by Shraddhaben Patel 300821026
    Last Modified by Shraddhaben Patel
    Last Modified Date: Feb 4,2016
    This file is used for the whole game control.
    Like it does not belong to one specific asset.
    It goes to all the asset and do the functionality.*/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //Private instance variables
    private int _scoreValue;
    private int _livesValue;

    [SerializeField]
    private AudioSource _gameOverSound;

    //Public Access methods
    
    public int ScoreValue
    {
        get
        {
            return _scoreValue;
        }
        set
        {
            this._scoreValue = value;
            this.ScoreLable.text = "Score:" + this._scoreValue;
            Debug.Log(this._scoreValue);
        }
    }

    public int LivesValue
    {
        get
        {
            return _livesValue;
        }
        set
        {
            this._livesValue = value;

            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this._livesValue = value;
                this.LivesLable.text = "Lives:" + this._livesValue;
            }

        }
    }

    // to get the instance from the other scripts
   
    //Public Instances
    public Text LivesLable;
    public Text ScoreLable;
    public Text GameOverLable;
    public Text HighScoreLable;
    public Button RestartButton;
    public HeroController hero;
    

    // Use this for initialization
    void Start () {
        this._intitialize();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //********PRIVATE METHODS***********
    private void _intitialize()
    {
        this._scoreValue = 0;
        this._livesValue = 5;
        this.GameOverLable.enabled = false;
        this.HighScoreLable.enabled = false;
        this.RestartButton.gameObject.SetActive(false);
  
    }

    private void _endGame()
    {
        this.HighScoreLable.text = "High Score: " + this._scoreValue;
        this.GameOverLable.enabled = true;
        this.HighScoreLable.enabled = true;
        this.RestartButton.gameObject.SetActive(true);

        this.LivesLable.enabled = false;
        this.ScoreLable.enabled = false;

        this.hero.gameObject.SetActive(false);
        

        this._gameOverSound.Play();
       
    }

    //Public methods

    public void RestartButtonClick()
    {
        
        Application.LoadLevel("Main");// to load the level of the game if resetbutton is pressed
    }
    

}
