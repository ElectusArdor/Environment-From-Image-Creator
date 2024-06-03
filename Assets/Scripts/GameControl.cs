using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI path;
    [SerializeField] private TMP_InputField inputField;

    public void LoadMapFile()
    {
        Starter starter = Starter.GetInstance();
        starter.LoadMapFromFile(path.text);
    }

    public void SetFilePath()
    {
        path.text = inputField.text;
    }
}
