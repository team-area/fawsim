using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BinLocator : MonoBehaviour {
    [SerializeField]
    private Transform playerPos;

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

    private OverheadLocator emptyBin;

    public void Start() {
        dict = new Dictionary<string, OverheadLocator>();
        SetupRow(left, 'A');
        SetupRow(right, 'B');

        ScenarioData sd = ScenarioData.Instance;
        Init(sd);
    }

    public void Init(ScenarioData sd) {
        string s = sd.BinToNotHaveItem.ToString();
        emptyBin = dict[s];

        emptyBin.gameObject.GetComponent<OverheadDoorToggle>().HasItem = false;

        if (sd.IsWearableEnabled) {
            emptyBin.StartRoutine();
        }
        float amount = 0;
        switch (sd.PlayerStartPos) {
            case StartPosition.FRONT:
                amount = 1950;
                break;
            case StartPosition.MIDDLE:
                amount = 1000;
                break;
            case StartPosition.BACK:
                amount = 20;
                break;
        }

        if (!sd.IsFacingFront) {
            GameObject.Find("Person").GetComponent<Transform>().rotation = new Quaternion(0, -90, 0, 0);
        }
        GameObject.Find("Person").GetComponent<Transform>().position = new Vector3(amount, 64, 100);
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

    private void Update() {
        if (emptyBin != null && ScenarioData.Instance.IsWearableEnabled && Input.GetKeyDown(KeyCode.Mouse1)) {
            emptyBin.StartRoutine();
        }
    }
}
