using UnityEngine;
using System.Collections;

public class OverheadSound : MonoBehaviour {

    [SerializeField]
    AudioSource source;

    private Coroutine routine;

    private bool isPlaying;

    public bool IsPlaying {
        get {
            return source.isPlaying;
        }
    }

    public void Play(params AudioClip[] clips) {
        if (routine != null) {
            StopCoroutine(routine);
        }
        isPlaying = true;
        StartCoroutine(PlaySounds(clips));
    }

    public void Stop() {
        StopCoroutine(routine);
        isPlaying = false;
    }

    private IEnumerator PlaySounds(AudioClip[] clips) {
        foreach (AudioClip clip in clips) {
            source.PlayOneShot(clip);
            while (source.isPlaying) {
                yield return null;
            }
        }
    }
}
