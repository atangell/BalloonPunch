using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private int _lifevalue;
    private int _pointsvalue;
    private AudioSource _endGameSound;


    public int arrows = 3;
    public GameObject Arrow;

    [Header("UI Objects")]
    public Text Lifelabel;
    public Text Pointslabel;
    public Text GameOverLabel;
    public Text FinalPointsLabel;
    public Button RestartButton;

    [Header("Game Objects")]
    public GameObject Balloon;
    public GameObject AirFill;
    //public ArrowController script;
    // Use this for initialization

    public int Lifevalue
    {
        get
        {
            return this._lifevalue;
        }
        set
        {
            this._lifevalue = value;
            if (this._lifevalue <= 0)
            {
                this._endGame();

            }
            else
            {
                this.Lifelabel.text = "Life: " + this._lifevalue;
            }
        }
    }

    public int Pointsvalue
    {
        get
        {
            return this._pointsvalue;
        }
        set
        {
            this._pointsvalue = value;
            this.Pointslabel.text = "Points: " + this._pointsvalue;
        }
    }


    void Start() {
        this.Lifevalue = 2;
        this.Pointsvalue = 0;
        

        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalPointsLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);

        this._endGameSound = this.GetComponent<AudioSource>();

        for (int arrowsCount = 0; arrowsCount < this.arrows; arrowsCount++)
        {
            Instantiate(this.Arrow);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
        private void _endGame()
    {
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalPointsLabel.text = "Final Points: " + this.Pointsvalue;
        this.FinalPointsLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.Pointslabel.gameObject.SetActive(false);
        this.Lifelabel.gameObject.SetActive(false);
        this.Balloon.SetActive(false);
        this.AirFill.SetActive(false);
        this._endGameSound.Play();
    }


    public void RestartButton_Click()
    {
        SceneManager.LoadScene("Game");
    }
}
