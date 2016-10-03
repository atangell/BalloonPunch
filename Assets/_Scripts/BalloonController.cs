using UnityEngine;
using System.Collections;

public class BalloonController : MonoBehaviour
{

    private Transform _transform;
    private Vector2 _currentPosition;
    private float _playerInput;
    private float _speed;


    public GameController gameController;
    
    [Header("Sounds")]
    public AudioSource AirLeak;
    public AudioSource Pop;
    // Use this for initialization

    

    
    void Start()
    {
        this._speed = 5;
        this._transform = this.GetComponent<Transform>();
        //this.Sounds = this.GetComponents<AudioSource>();
        //this._pop = this.Sounds[2];
    }

    // Update is called once per frame
    void Update()
    {
        this._move();
    }

    private void _move()
    {
        this._currentPosition = this._transform.position;

        this._playerInput = Input.GetAxis("Horizontal");

        if (this._playerInput > 0)
        {
            this._currentPosition += new Vector2(this._speed, 0);
        }

        if (this._playerInput < 0)
        {
            this._currentPosition -= new Vector2(this._speed, 0);
        }

        this._transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x,-275f, 275f), -122f);
    }
        

 


private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AirFill"))
            {
        this.Pop.Play();
        this.gameController.Pointsvalue += 100;
       
        }

    if (other.gameObject.CompareTag("Arrow"))
    {
        this.AirLeak.Play();
        this.gameController.Lifevalue -= 1;
    }
    }
   
}
