using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float _speed = 4; // this is the speed you start with
    private Vector3 _movement = new Vector3 (1, 0, 0);
    private Rigidbody2D _rb;
    private bool _go = false;

    // jump
    [SerializeField] private float _jumpForce = 3f;
    private Vector3 _jump = new Vector3 (0, 2.0f, 0);
    [SerializeField] private bool _isGrounded;
    private bool _jumped;

    [SerializeField] private int _numberOfJumpsAllowed = 2;
    private int _jumpCounter;

    // Start is called before the first frame update
    void Start () {
        _rb = GetComponent<Rigidbody2D> ();
    }

    private void Update () {

        if (Input.GetKeyDown (KeyCode.Space) && _jumpCounter > 0) {
            _jumped = true;
            Jump ();
        }
        if (Input.GetKeyUp (KeyCode.Space)) {
            _jumped = false;
            StartCoroutine (StopTheJump ());
        }


        if (Input.GetKey (KeyCode.D) | Input.GetKey ("right")) {
            _go = true;
            _movement = new Vector3 (1, 0, 0);

        } else if (Input.GetKey (KeyCode.A) | Input.GetKey ("left")) {
            _go = true;
            _movement = new Vector3 (-1, 0, 0);

        } else {
            _go = false;
        }

    }

    // Update is called once per frame
    void FixedUpdate () {

        if (_go == true) {
            transform.Translate (_movement * Time.deltaTime * _speed);
        }

    }

    void Jump () {

        _rb.velocity = Vector3.zero;
        _rb.AddForce (_jump * _jumpForce, ForceMode2D.Impulse);
        _jumpCounter--;
        _jumped = true;

        _isGrounded = false;

    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            _isGrounded = true;
            _jumpCounter = _numberOfJumpsAllowed;
        }
    }

    IEnumerator StopTheJump () {
        yield return new WaitForSeconds (0.1f);
        if (_rb.velocity.y > 0 && _jumped == false) {
            _rb.velocity = Vector3.zero; // stop the jump when the button is canceled
        }
    }
}