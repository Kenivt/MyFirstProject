using Knivt.Tools;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Knivt.Tools
{
    public class UIManager : Sington<UIManager>
    {
        private Dictionary<string, UIState> _uIStateDic;
        public UIState MainWindow { get; set; }
        private void Start()
        {
            _uIStateDic = FindObjectsOfType<UIState>().ToDictionary((value) =>
            {
                value.Close();
                return value.State;
            });
        }
        /// <summary>
        /// 根据类型的名称来查找对应的UI(GetType().Name)
        /// </summary>
        /// <typeparam name="UIType"></typeparam>
        public UIState GetTargetUIState<UIType>()
        {
            string type = typeof(UIType).Name;
            if (_uIStateDic.ContainsKey(type))
            {
                return _uIStateDic[type];
            }
#if UNITY_EDITOR
            Debug.LogError($"在UI字典中没有找到名为{type}的UI");
#endif
            return null;
        }
    }
}
