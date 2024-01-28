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
    // Start is called before the first frame update

    public Transform CheckSeats()
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

}
