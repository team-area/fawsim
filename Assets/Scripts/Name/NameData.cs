using UnityEngine;
using System.Collections;

public class NameData : MonoBehaviour {
    public string Username;

    public void Start() {
        DontDestroyOnLoad(gameObject);
    }
}