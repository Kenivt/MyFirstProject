using UnityEngine;
using UnityEngine.UI;
using Knivt.Tools;

public class OtherPanel : UIGroup
{
    public Button button_A;
    public Button button_B;
    public Button button_C;
    public Button button_D;
    public Button NoticeButton;
    private void Awake()
    {
        this.AddAllChildUIState();
        SetStartState(typeof(Panel_A).Name);
    }
    private void OnEnable()
    {
        button_A.onClick.AddListener(() =>
        {
            SwitchUI(typeof(Panel_A).Name);
        });
        button_B.onClick.AddListener(() =>
        {
            SwitchUI(typeof(Panel_B).Name);
        });
        button_C.onClick.AddListener(() =>
        {
            SwitchUI(typeof(Panel_C).Name);
        });
        button_D.onClick.AddListener(() =>
        {
            SwitchUI(typeof(Panel_D).Name);
        });
        NoticeButton.onClick.AddListener(() =>
        {
            UISystem.Instance.OpenTargetUIState<NoticePanel>();
        });
    }
    public override void CloseInteraction()
    {
        CanvasGroup.interactable = false;
    }
    public override void Open()
    {
        base.Open();
        SwitchUI(typeof(Panel_A).Name);
    }
}
