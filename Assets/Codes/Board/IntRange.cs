using System;


[Serializable]
public class IntRange
{
    public int m_Min;       // The minimum value in this range.
    public int m_Max;       // The maximum value in this range.

    //Constructor
    public IntRange(int min, int max){
        m_Min = min;
        m_Max = max;
    }



    public int Random{

        get {
        	return UnityEngine.Random.Range(m_Min, m_Max); 
        }
    }
}