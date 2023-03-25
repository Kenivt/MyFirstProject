using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knivt.Tools
{
    public class Sington<T> : MonoBehaviour where T : Sington<T>
    {
        private static object _lock = new object();
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            GameObject obj = new GameObject(typeof(T).Name + "Sington");
                            _instance = obj.AddComponent<T>();
                        }
                    }
                }
                return _instance;
            }
        }
        private static T _instance;
    }
}
