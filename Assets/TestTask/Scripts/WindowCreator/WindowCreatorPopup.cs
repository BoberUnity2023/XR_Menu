using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XR_Menu
{
    public class WindowCreatorPopup : WindowCreatorBase
    {
        [SerializeField] private WindowCreatorPopupData _data;
        [SerializeField] private Transform _slotTransform;
        private Queue<Window> _queueWindowPrefabs = new Queue<Window>();
        private Slot _slot;
        private int _number;        

        public void Init()
        {
            _slot = new Slot(_slotTransform);
            StartCoroutine(Waitinterval(_data.Interval));
        }

        public override void PressClose()
        {
            _slot.ActiveWindow.Hide();

            if (_queueWindowPrefabs.Count > 0)
            {
                ShowWindow(_queueWindowPrefabs.Dequeue(), _slot);
            }
        }

        private IEnumerator Waitinterval(float time)
        {
            yield return new WaitForSeconds(time);

            if (_number < _data.WindowPrefabs.Length)
            {
                ShowOrEnqueue(_data.WindowPrefabs[_number]);
                _number++;
                StartCoroutine(Waitinterval(_data.Interval));
            }
        }

        private void ShowOrEnqueue(Window windowPrefab)
        {
            if (_slot.IsFree)
            {
                ShowWindow(windowPrefab, _slot);
            }
            else
            {
                _queueWindowPrefabs.Enqueue(windowPrefab);
                Debug.Log("Popup window " + windowPrefab.name + " was added to queue");
            }
        }
    }
}

