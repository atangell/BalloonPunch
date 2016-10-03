using UnityEngine;
using System.Collections;

public class BalloonController : MonoBehaviour
{

    private Transform _transform;
    // Use this for initialization
    void Start()
    {
        this._transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        this._move();
    }

    private void _move()
    {
        this._transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x - 320f, -230f, 300f), -122f);

    }

   
}
