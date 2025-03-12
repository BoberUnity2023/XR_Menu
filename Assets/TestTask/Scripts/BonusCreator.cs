using System.Collections;
using UnityEngine;

public class BonusCreator : WindowCreatorBase
{    
    private int _id;
    private const float _interval = 5;

    private void Start()
    {
        StartCoroutine(Waitinterval(_interval));
    }

    private IEnumerator Waitinterval(float time)
    {
        yield return new WaitForSeconds(time);
        
        
        if (_id < _bonusWindowPrefabs.Length)
        {
            AddWindow(_id);            
            _id++;
            StartCoroutine(Waitinterval(_interval));
        }        
    }    
}
