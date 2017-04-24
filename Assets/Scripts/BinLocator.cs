using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BinLocator : MonoBehaviour {

    [SerializeField]
    private GameObject left;

    [SerializeField]
    private GameObject right;

    [SerializeField]
    private AudioClip A13;

    [SerializeField]
    private AudioClip B5;

    [SerializeField]
    private AudioClip B11;

    private IDictionary<string, OverheadLocator> dict;

    public void Start() {
        dict = new Dictionary<string, OverheadLocator>();
        SetupRow(left, 'A');
        SetupRow(right, 'B');

        dict["A13"].StartRoutine();
    }

    public void SetupRow(GameObject row, char letter) {
        OverheadLocator[] locators = row.GetComponentsInChildren<OverheadLocator>();
        for (int i = 0; i < locators.Length; i++) {
            string num = "" + letter + i;
            locators[i].Number = num;

            AudioClip clip = null;
            if (num == "A13") {
                clip = A13;
            }
            if (num == "B5") {
                clip = B5;
            }
            if (num == "B11") {
                clip = B11;
            }

            locators[i].location = clip;

            dict.Add(num, locators[i]);
        }
    }
}
