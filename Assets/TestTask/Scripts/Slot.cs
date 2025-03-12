using UnityEngine;

namespace XR_Menu
{
    public class Slot
    {
        private Transform _slotTransform;

        public Transform Transform => _slotTransform;

        public Window ActiveWindow { get; set; }

        public WindowTag Tag => ActiveWindow.Tag;

        public Slot(Transform slotTransform)
        {
            _slotTransform = slotTransform;
        }

        public bool IsFree
        {
            get
            {
                if (ActiveWindow == null)
                    return true;

                if (ActiveWindow.IsHidden)
                    return true;

                return false;
            }
        }
    }
}

