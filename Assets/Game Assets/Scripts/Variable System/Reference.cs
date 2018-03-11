namespace ScriptableObjectUtility.Variables
{
    using System;
    using UnityEngine;

    [Serializable]
    public class Reference<T, TVar> where TVar : Variable<T>
    {
        [SerializeField]
        private T constantValue;

        [SerializeField]
        private bool useConstant = true;

        [SerializeField]
        private TVar variable;

        public Reference()
        {
        }

        public Reference(T value)
        {
            this.useConstant = true;
            this.constantValue = value;
        }

        public T Value
        {
            get { return this.useConstant ? this.constantValue : this.variable; }
        }

        public static implicit operator T(Reference<T, TVar> reference)
        {
            return reference.Value;
        }
    }
}