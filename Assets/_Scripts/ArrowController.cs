using UnityEngine;
using System.Collections;


public class ArrowController : MonoBehaviour
{

    private int _speed;
    private int _drift;
    private Transform _transform;

    public int Speed
    {
        get
        {
            return this._speed;
        }
        set
        {
            this._speed = value;
        }
    }

    public int Drift
    {
        get
        {
            return this._drift;
        }
        set
        {
            this._drift = value;
        }
    }

    //private AudioSource[] Sounds;
    //private AudioSource _pop;
    //private AudioSource _bow;
    void Start()
    {
        this._transform = this.GetComponent<Transform>();
        this._reset();
        //this.Sounds = this.GetComponents<AudioSource>();
        //this._bow = this.Sounds[1];
        //this._pop = this.Sounds[1];
    }


    void Update()
    {
        this._move();
        this._checkBounds();
    }

    private void _move()
    {
        Vector2 newPosition = this._transform.position;

        newPosition.y -= this.Speed;
        newPosition.x += this.Drift;

        this._transform.position = newPosition;
    }


    private void _checkBounds()
    {
        if (this._transform.position.y <= -300f)
        {
            this._reset();
        }
    }


    private void _reset()
    {
        this.Speed = Random.Range(4, 8);
        this.Drift = Random.Range(-2, 2);
        this._transform.position = new Vector2(Random.Range(-222f, 222f), 300f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
    }
        
        /* if (other.gameObject.CompareTag("Balloon"))
        {

            this._pop.Play();

        }
    }*/
}
