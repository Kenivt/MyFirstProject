using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Knivt.Tools
{
    public interface IUIGroup<T>
    {
        void SwitchUI(T stateName);
        void AddState(T stateName, IUIState<T> uiState);
    }
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIGroup : UIState, IUIGroup<string>
    {
        public Dictionary<string, IUIState<string>> Dic
        {
            get
            {
                if (_dic == null)
                {
                    _dic = new Dictionary<string, IUIState<string>>();
                }
                return _dic;
            }
        }
        protected Dictionary<string, IUIState<string>> _dic = new Dictionary<string, IUIState<string>>();
        private IUIState<string> _curUIState;

        protected IUIState<string> startUIState;
        /// <summary>
        /// 设置默认窗口,要在Start中进行设置
        /// </summary>
        /// <param name="state"></param>
        public void SetStartState(string state)
        {
            if (Dic.ContainsKey(state))
            {
                startUIState = Dic[state];
                _curUIState = Dic[state];
                _curUIState.Open();
            }
#if UNITY_EDITOR
            else
            {
                Debug.LogError("错误,没有找到默认窗口");
            }
#endif
        }
        public void SwitchUI(string stateName)
        {
            if (Dic.ContainsKey(stateName))
            {
                _curUIState?.Close();
                _curUIState = _dic[stateName];
                _curUIState.Open();
            }
#if UNITY_EDITOR
            else
            {
                Debug.LogError("错误,没有发现对应的UI");
            }
#endif
        }
        public void AddState(string stateName, IUIState<string> uiState)
        {
            if (!Dic.ContainsKey(stateName))
            {
                _dic.Add(stateName, uiState);
            }
#if UNITY_EDITOR
            else
            {
                Debug.LogError($"错误,重复添加UI:{stateName}");
            }
#endif
        }
    }
}
