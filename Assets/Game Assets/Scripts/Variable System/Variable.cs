// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
//
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

namespace ScriptableObjectUtility.Variables
{
    using UnityEngine;

    public class Variable<T> : ScriptableObject
    {
        [SerializeField]
        private T value;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public static implicit operator T(Variable<T> variable)
        {
            return variable.value;
        }
    }
}