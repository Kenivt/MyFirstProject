using UnityEngine;

namespace Knivt.Tools
{
    public static class TransformShortCut
    {
        /// <summary>
        /// 寻找对应名称的transform,
        /// 要子代没有重名的
        /// </summary>
        /// <param name="transform">根treansform</param>
        /// <param name="tfName">物体的名称</param>
        /// <returns></returns>
        public static Transform FindOffspring(this Transform transform, string tfName)
        {
            return FindOffSpringDFS(transform, tfName);
        }
        private static Transform FindOffSpringDFS(Transform transform, string tfName)
        {
            Transform child = transform.Find(tfName);
            if (child != null) return child;
            for (int i = 0; i < child.childCount; i++)
            {
                child = FindOffspring(child.GetChild(i), tfName);
                if (child != null) return child;
            }
            return null;
        }
    }
}

