using System.Collections.Generic;
using UnityEngine;
namespace Knivt.Tools
{
    public class UISystem : PersistentSington<UISystem>
    {
        /// <summary>
        /// 记录打开过的可以压入栈中的UI,用于按顺序退出
        /// </summary>
        public Stack<UIState> uIStack;

        protected override void Awake()
        {
            base.Awake();
            uIStack = new Stack<UIState>();
        }
        /// <summary>
        /// 通过UIType来查询UI实体,key为string类型的(GetType().Name)
        /// </summary>
        /// <typeparam name="UIType"></typeparam>
        public void OpenTargetUIState<UIType>()
        {
            UIState uIState = UIManager.Instance.GetTargetUIState<UIType>();
            OpenTargetUIState(uIState);
        }
        public void OpenTargetUIState(UIState uIState)
        {
            if (uIState == null)
            {
#if UNITY_EDITOR
                Debug.LogError("错误,没有找到对应的UI");
#endif
                return;
            }
            if (uIState.CanPushUIStack)//可被压入栈中
            {
                if (uIStack.Count > 0)
                {
                    uIStack.Peek().CloseInteraction();//关闭
                }
                if (uIState.WindowGroup != null)
                    uIState.WindowGroup.SwitchUI(uIState.State);
                else
                    uIState.Open();
                uIStack.Push(uIState);
            }
            else if (uIState.WindowGroup != null)
            {
                uIState.WindowGroup.SwitchUI(uIState.State);
            }
            else
            {
                uIState.Open();
            }
        }
        public void CloseTargetUIState<UIType>()
        {
            UIState uIState = UIManager.Instance.GetTargetUIState<UIType>();
            CloseTargetUIState(uIState);
        }
        public void CloseStackTopUI()
        {
            if (uIStack.Count > 0)
            {
                CloseTargetUIState(uIStack.Peek());
            }
            else
            {
                if (UIManager.Instance.MainWindow != null)
                {
                    OpenTargetUIState(UIManager.Instance.MainWindow);
                }
            }
        }
        public void CloseTargetUIState(UIState uIState)
        {
            if (uIState == null)
            {
#if UNITY_EDITOR
                Debug.LogError("错误,没有找到对应的UI");
#endif
                return;
            }
            if (uIState.CanPushUIStack)//此时证明已经被压入栈中了
            {
                if (uIStack.Count > 0 && uIStack.Peek() == uIState)
                {
                    uIStack.Pop().Close();
                    if (uIStack.Count > 0) { uIStack.Peek().Open(); }
                }
#if UNITY_EDITOR
                else
                {
                    Debug.LogError("错误,uIStack顺序出错...");
                }
#endif
            }
            else
            {
                uIState.Close();
            }
        }
    }

}
