using UnityEngine;
using UnityEngine.UI;
using Knivt.Tools;
public class NoticePanel : UIState
{
    public Button exitButton;
    public void OnEnable()
    {
        exitButton.onClick.AddListener(() =>
        {
            UISystem.Instance.CloseTargetUIState(this);
        });
    }
    public override void CloseInteraction()
    {
        CanvasGroup.interactable = false;
    }
}
