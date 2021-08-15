using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;    
#endif

[System.Serializable]
public class SerializableDictionary<TK, TV>: ISerializationCallbackReceiver
{
    public Dictionary<TK, TV> _Dictionary 
        = new Dictionary<TK, TV>();
    public List<TK> _Keys = new List<TK>();
    public List<TV> _Values = new List<TV>();

    public int Count {
        get {
            return _Dictionary.Count;
        }
    }

    public void OnBeforeSerialize()
    {
        #if UNITY_EDITOR
            if(!EditorApplication.isPlaying
            && !EditorApplication.isUpdating
            && !EditorApplication.isCompiling) return;
        #endif

        _Keys.Clear();
        _Values.Clear();

        foreach (var kvp in _Dictionary)
        {
            _Keys.Add(kvp.Key);
            _Values.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        _Dictionary = new Dictionary<TK, TV>();

        for (int i = 0; i != Mathf.Min(_Keys.Count, _Values.Count); i++)
            _Dictionary.Add(_Keys[i], _Values[i]);
    }

    public SerializableDictionary()
    {
        _Dictionary = new Dictionary<TK, TV>();
    }

    void OnGUI()
    {
        foreach (var kvp in _Dictionary)
            GUILayout.Label("Key: " + kvp.Key + " value: " + kvp.Value);
    }

    // public void Add(TK key, TV value)
    // {
    //     _Dictionary.Add(key, value);
    // }

    // public bool ContainsKey(TK key) {
    //     return _Dictionary.ContainsKey(key);
    // }

    // public bool ContainsValue(TV value) {
    //     return _Dictionary.ContainsValue(value);
    // }

    // public TK GetKey(int index) {
    //     return _Keys[index];
    // }

    // public TV GetValue(int index) {
    //     return _Values[index];
    // }
}
