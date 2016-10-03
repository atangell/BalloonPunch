using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private int _speed;
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
    // Use this for initialization
    void Start()
    {
        this._transform = this.GetComponent<Transform>();
        this._reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._move();
        this._checkbounds();

    }

    private void _move()
    {
        Vector2 newPosition = this._transform.position;
        newPosition.y -= this._speed;
        this._transform.position = newPosition;
    }

    private void _checkbounds()
    {
        if (this._transform.position.y <= -576f)
        {
            this._reset();
        }
    }

    private void _reset()
    {
        this._speed = 5;
        this._transform.position = new Vector2(0f, 675f);
    }
}
