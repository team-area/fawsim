using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverheadDoorToggle : MonoBehaviour {

    [SerializeField]
    private MeshRenderer mesh;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private MeshRenderer item;

    [SerializeField]
    private OverheadLocator locator;

    private Coroutine routine;
    private static int timesOperated;

    public static int TimesOperated {
        get {
            return timesOperated;
        }
    }

    public bool IsOpen {
        get {
            return !mesh.enabled;
        }
    }

    public bool HasItem {
        get {
            return item.enabled;
        }

        set {
            if (value) {
                locator.StartRoutine();
            } else {
                locator.StopRoutine();
            }
            item.enabled = value;
        }
    }

    private void Start() {
        timesOperated = 0;
    }

    // Update is called once per frame
    private void Update() {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Mouse0)
            && Physics.Raycast(ray, out hit, maxDistance: 50)
            && hit.transform.gameObject == mesh.gameObject) {
            mesh.enabled = !mesh.enabled;
            timesOperated++;
            if (!HasItem) {
                GameObject.Find("HudText").GetComponent<Text>().text = "You found the empty bin!\nExiting scenario...";
                LeaveScene();
            }
        }
    }

    private void LeaveScene() {
        if (routine == null) {
            routine = StartCoroutine(LeaveSceneRoutine());
        }
    }

    private IEnumerator LeaveSceneRoutine() {
        PlayerStats.Instance.ScenarioStats.Add(
            new ScenarioStats(
                ScenarioData.Instance.ScenarioName,
                TimesOperated,
                OverheadSound.TimesPlayed,
                Time.timeSinceLevelLoad,
                ScenarioData.Instance.IsWearableEnabled
                )
            );
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
