using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoblePositions: MonoBehaviour
{
    [Serializable]
    public struct SeatPosition
    {
        public Transform position;
        public bool taken;
    }
    public List<SeatPosition> _tablePositions;
    public List<SeatPosition> _waitPositions;
    // Start is called before the first frame update

    public Transform GetSeat()
    {
        for (int i= 0; i < _tablePositions.Count; i++)
        {
            if(_tablePositions[i].taken == false)
            {
                var temp = _tablePositions[i];
                temp.taken = true;
                _tablePositions[i] = temp;
                return _tablePositions[i].position;
            }
        }
        return null;
    }

    public Transform GetWaitPos()
    {
        for (int i = 0; i < _waitPositions.Count; i++)
        {
            if (_waitPositions[i].taken == false)
            {
                var temp = _waitPositions[i];
                temp.taken = true;
                _waitPositions[i] = temp;
                return _waitPositions[i].position;
            }
        }
        return null;
    }

    public void FreeSeat(string type, Vector3 position)
    {
        if(type=="wait")
        {
            for (int i = 0; i < _waitPositions.Count; i++)
            {
                if(_waitPositions[i].position.position == position)
                {
                    var temp = _waitPositions[i];
                    temp.taken = false;
                    _waitPositions[i] = temp;
                }
            }
        }
        else
        {
            for (int i = 0; i < _tablePositions.Count; i++)
            {
                if (_tablePositions[i].position.position == position)
                {
                    var temp = _tablePositions[i];
                    temp.taken = false;
                    _tablePositions[i] = temp;
                }
            }
        }
    }
}
