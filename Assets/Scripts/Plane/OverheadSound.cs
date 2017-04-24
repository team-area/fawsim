using UnityEngine;
using System.Collections;

public class OverheadSound : MonoBehaviour {
    private static int timesPlayed;

    [SerializeField]
    AudioSource source;

    private Coroutine routine;

    private bool isPlaying;

    public static int TimesPlayed {
        get {
            return timesPlayed;
        }
    }

    public bool IsPlaying {
        get {
            return source.isPlaying;
        }
    }

    public void Play(params AudioClip[] clips) {
        if (!isPlaying) {
            timesPlayed++;
            StartCoroutine(PlaySounds(clips));
        }
    }

    public void Start() {
        timesPlayed = 0;
    }

    public void Stop() {
        StopCoroutine(routine);
    }

    private IEnumerator PlaySounds(AudioClip[] clips) {
        isPlaying = true;
        foreach (AudioClip clip in clips) {
            source.PlayOneShot(clip);
            while (source.isPlaying) {
                yield return null;
            }
        }
        isPlaying = false;
    }
}