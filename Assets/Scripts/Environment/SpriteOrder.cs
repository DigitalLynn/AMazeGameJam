using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrder : MonoBehaviour {
    private SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start () {
        foreach (Transform child in transform) {
            float zPosition = child.transform.position.z;
            float order = zPosition * -100;

            _sprite = child.GetComponent<SpriteRenderer> ();
            if (_sprite) {
                _sprite.sortingOrder = (int) order;
            }

        }

    }
}