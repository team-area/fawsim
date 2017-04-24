using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameSystem : MonoBehaviour {
    [SerializeField]
    private InputField input;
    [SerializeField]
    private NameData nameData;
    [SerializeField]
    private Button button;

    public void ChangeScene() {
        SceneManager.LoadScene("Menu");
    }

    private void Update() {
        nameData.Username = input.text;
        button.enabled = nameData.Username.Length > 3;
    }
}
