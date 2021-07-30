using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public string playName;
    public string pauseName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<AudioManager>().Play(playName);
        FindObjectOfType<AudioManager>().Pause(pauseName);
    }
}
