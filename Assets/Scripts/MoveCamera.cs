using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    private Vector3 endPos = new Vector3 (0, 33.5f, -12);
    public bool moveNow;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update () {
        if(moveNow == true){
            transform.position = Vector3.Lerp (transform.position, endPos, 0.1f * Time.deltaTime);
        }
    }
}