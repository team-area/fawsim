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
        if (routine != null) {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(LoopSound(soundInterval, ping, location));
    }

    public void StopRoutine() {
        StopCoroutine(routine);
    }

    private IEnumerator LoopSound(float interval, params AudioClip[] clips) {
        isRunning = true;
        float timer = 0;
        while (true) {
            if (!sound.IsPlaying && (timer += Time.deltaTime) > soundInterval) {
                sound.Play(clips);
                timer = 0;
            }
            yield return null;
        }
    }
}
