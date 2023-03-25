using UnityEngine;
using System.Collections.Generic;
namespace Knivt.Tools
{
    public static class UIShortCut
    {
        public static UIGroup FindOwnUIGroup(this UIState uIState)
        {
            return FindGroup(uIState, uIState.transform.parent);
        }
        private static UIGroup FindGroup(UIState uIState, Transform transform)
        {
            if (transform == null)
            {
                return null;
            }
            UIGroup uIGroup = null;
            if (transform.TryGetComponent(out UIGroup group))
            {
                return group;
            }
            uIGroup = FindGroup(uIState, transform.parent);
            return uIGroup;
        }
        /// <summary>
        /// 仅仅寻找一层的UIState
        /// </summary>
        /// <returns></returns>
        public static void AddAllChildUIState(this UIGroup uIGroup)
        {
            Queue<Transform> transQueue = new Queue<Transform>();
            transQueue.Enqueue(uIGroup.transform);
            while (transQueue.Count > 0)
            {
                int queueCount = transQueue.Count;
                for (int i = 0; i < queueCount; i++)
                {
                    Transform transform = transQueue.Dequeue();
                    for (int j = 0; j < transform.childCount; j++)
                    {
                        Transform child = transform.GetChild(j);
                        if (child.TryGetComponent<UIState>(out UIState uIState))
                        {
                            if (!uIState.blockGroupFind)
                            {
                                uIGroup.AddState(uIState.State, uIState);
                                uIState.WindowGroup = uIGroup;
                                uIState.Close();
                            }
                        }
                        else
                        {
                            transQueue.Enqueue(child);
                        }
                    }
                }
            }
        }
    }
}

