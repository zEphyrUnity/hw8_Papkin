using UnityEngine;


namespace Utils
{
    public struct TransformData
    {
        public Vector3 position;
        public Vector3 localPosition;
        public Vector3 localScale;
        public Quaternion rotation;
        public Quaternion localRotation;
        public Transform parent;
    }

    public static class TransformClone
    {
        public static TransformData Clone(this Transform transform)
        {
            TransformData td = new TransformData();

            td.position = transform.position;
            td.localPosition = transform.localPosition;
            td.localScale = transform.localScale;
            td.rotation = transform.rotation;
            td.localRotation = transform.localRotation;
            td.parent = transform.parent;

            return td;
        }
    }
}

