using System.Collections.Generic;
using UnityEngine;

namespace XR_Menu
{
    public class WindowCreatorNormal : WindowCreatorBase
    {
        [SerializeField] private WindowCreatorNormalData _data;
        [SerializeField] private Transform _slotFirstTransform;
        [SerializeField] private Transform _slotSecondTransform;        

        private Queue<Window> _queueWindowPrefabs = new Queue<Window>();
        private Slot _slotFirst;
        private Slot _slotSecond;

        public void Init()
        {
            _slotFirst = new Slot(_slotFirstTransform);
            _slotSecond = new Slot(_slotSecondTransform);
        }

        public void PressShowWindow(string id)//from Editor
        {
            Window[] windowPrefabs = GetWindowPrefabsById(id);
            string key = GetKeyFromId(id);
            Window windowPrefab = GetWindowPrefabByKey(key, windowPrefabs);
            ShowOrEnqueue(windowPrefab);
        }

        public override void PressClose()
        {
            if (_queueWindowPrefabs.Count > 0)
            {
                if (_slotFirst.IsFree || _slotSecond.IsFree)
                    ShowOrEnqueue(_queueWindowPrefabs.Dequeue());
            }
        }

        private void ShowOrEnqueue(Window windowPrefab)
        {
            bool success = TryShow(windowPrefab, _slotFirst);
            if (success)
            { 
                return; 
            }

            success = TryShow(windowPrefab, _slotSecond);
            if (success)
            {
                return;
            }

            TryEnquee(windowPrefab);
        }

        private bool TryShow(Window windowPrefab,  Slot slot)
        {
            if (slot.IsFree || windowPrefab.Tag == slot.Tag)
            {
                if (!slot.IsFree)
                {
                    slot.ActiveWindow.Hide();
                }
                ShowWindow(windowPrefab, slot);
                return true;
            }

            return false;
        }

        private bool TryEnquee(Window windowPrefab)
        {
            if (_queueWindowPrefabs.Contains(windowPrefab))
            { 
                return false; 
            }
            
            Debug.Log("Normal window " + windowPrefab.name + " was added to queue");
            _queueWindowPrefabs.Enqueue(windowPrefab);
            return true;            
        }

        private Window[] GetWindowPrefabsById(string id)
        {
            if (id.Substring(0, 1) == "s")
            {
                return _data.WindowPrefabsSettings;
            }

            if (id.Substring(0, 1) == "f")
            {
                return _data.WindowPrefabsFriends;
            }

            if (id.Substring(0, 1) == "i")
            {
                return _data.WindowPrefabsInvites;
            }

            Debug.LogWarning("Uncorrect ID: " + id);
            return null;
        }

        private Window GetWindowPrefabByKey(string key, Window[] windowPrefabs)
        {
            if (key == "0")
            {
                return windowPrefabs[0];
            }

            if (key == "1")
            {
                return windowPrefabs[1];
            }

            if (key == "2")
            {
                return windowPrefabs[2];
            }

            if (key == "3")
            {
                return windowPrefabs[3];
            }

            Debug.LogWarning("Uncorrect key: " + key);
            return null;
        }

        private string GetKeyFromId(string id)
        {
            return id.Substring(1, 1);//TODO: Add values more than 9
        }
    }
}

