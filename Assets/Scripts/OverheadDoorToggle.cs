using UnityEngine;
using System.Collections;

public class OverheadDoorToggle : MonoBehaviour {
    [SerializeField]
    private MeshRenderer mesh;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private MeshRenderer item;

    [SerializeField]
    private OverheadLocator locator;

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

    // Update is called once per frame
    void Update() {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Mouse0)
            && Physics.Raycast(ray, out hit, maxDistance: 50)
            && hit.transform.gameObject == mesh.gameObject) {
            mesh.enabled = !mesh.enabled;
        }
    }
}
