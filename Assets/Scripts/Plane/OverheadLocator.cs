using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverheadLocator : MonoBehaviour {

    [SerializeField]
    private OverheadSound sound;

    [SerializeField]
    private float soundInterval;

    [SerializeField]
    private TextMesh number;

    [SerializeField]
    private AudioClip ping;

    public AudioClip location;

    private Coroutine routine;
    private bool isRunning;

    public string Number {
        set {
            number.text = value;
        }
    }

    public void StartRoutine() {
        sound.Play(ping, location);
    }

    public void StopRoutine() {
        if (routine != null) {
            StopCoroutine(routine);
        }
    }
}
