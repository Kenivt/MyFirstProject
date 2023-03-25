using UnityEngine;
using Knivt.Tools;
using UnityEngine.UI;
public class MainMenu : UIState
{
    public Button OpenMenuButton;
    public Button ExitGame;
    private void Awake()
    {
        OpenMenuButton = transform.FindOffspring("Start").GetComponent<Button>();
        ExitGame = transform.FindOffspring("Exit").GetComponent<Button>();
        UIManager.Instance.MainWindow = this;
    }

    private void OnEnable()
    {
        OpenMenuButton.onClick.AddListener(() =>
        {
            UISystem.Instance.OpenTargetUIState<OtherPanel>();
        });
        ExitGame.onClick.AddListener(() =>
        {
            UnityEditor.EditorApplication.isPlaying = false;
        });
    }
    private void OnDisable()
    {
        OpenMenuButton.onClick.RemoveAllListeners();
        ExitGame.onClick.RemoveAllListeners();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UISystem.Instance.CloseStackTopUI();
        }
    }

    public override void CloseInteraction()
    {
        Close();
    }
}
