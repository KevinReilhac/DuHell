using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataObject : ScriptableObject { };

/// <summary>
/// Access to all data files
/// </summary>
public class DataManager : Manager<DataManager>
{
    private Dictionary<System.Type, dataObject> _objects = null;
    private object[] _objectsBuffer = null;

    public static T Get<T>()
    {
        System.Type Ttype = typeof(T);

        if (instance._objects != null && instance._objects.ContainsKey(typeof(T)))
            return (T)(object)instance._objects[Ttype];

        if (instance._objectsBuffer == null)
            instance._objectsBuffer = Resources.LoadAll("",typeof(dataObject));

        if (instance._objectsBuffer != null && instance._objectsBuffer.Length > 0)
        {
            foreach (object obj in instance._objectsBuffer)
            {
                if (obj.GetType() == typeof(T))
                {
                    if (instance._objects == null)
                        instance._objects = new Dictionary<System.Type, dataObject>();

                    instance._objects.Add(Ttype, (dataObject)obj);

                    return (T)(object)obj;
                }
            }
        }
        
        Debug.LogError("Data file " + Ttype.Name + " was not found");
        return default(T);
    }
}
