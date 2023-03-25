using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Knivt.Tools
{
    public interface IUIState<T>
    {
        public T State { get; }
        public bool CanPushUIStack { get; }
        public IUIGroup<T> WindowGroup { get; set; }
        /// <summary>
        /// 启用当前的UI
        /// </summary>
        void Open();
        /// <summary>
        /// 关闭UI,Alpha,交互,射线检测都关闭
        /// </summary>
        void Close();
        /// <summary>
        /// 仅仅关闭交互,Alpha还显示
        /// </summary>
        void CloseInteraction();
    }
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UIState : MonoBehaviour, IUIState<string>
    {
        [SerializeField, Tooltip("是否可以压入UIStack")]
        protected bool _canPushUIStack = false;
        [Tooltip("是否阻止父Group的查找")]
        public bool blockGroupFind;
        public bool CanPushUIStack => _canPushUIStack;
        protected CanvasGroup CanvasGroup
        {
            get
            {
                if (_canvasGroup == null)
                {
                    _canvasGroup = GetComponent<CanvasGroup>();
                }
                return _canvasGroup;
            }
        }
        private CanvasGroup _canvasGroup;
        public string State
        {
            get
            {
                if (_state == string.Empty)
                {
                    _state = GetType().Name;
                }
                return _state;
            }
        }
        private string _state = string.Empty;
        public IUIGroup<string> WindowGroup { get; set; }
        public virtual void Close()
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }
        public virtual void Open()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
        }
        public abstract void CloseInteraction();
    }

}
