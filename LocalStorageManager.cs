using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class LocalStorageManager : MonoBehaviour
{
    public static LocalStorageManager Instance { get; private set; }

    #if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern void SaveToLocalStorage(string key, string value);

    [DllImport("__Internal")]
    private static extern IntPtr LoadFromLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern void SaveIntToLocalStorage(string key, int value);

    [DllImport("__Internal")]
    private static extern int LoadIntFromLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern void SaveFloatToLocalStorage(string key, float value);

    [DllImport("__Internal")]
    private static extern float LoadFloatFromLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern bool HasKeyInLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern void RemoveFromLocalStorage(string key);

    [DllImport("__Internal")]
    private static extern void ClearLocalStorage();
    #endif

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private bool IsWebGL() => Application.platform == RuntimePlatform.WebGLPlayer;

    public void SaveString(string key, string value)
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            SaveToLocalStorage(key, value);
            #endif
        }
        else
        {
            PlayerPrefs.SetString(key, value);
        }
    }

    public string LoadString(string key)
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            IntPtr valuePtr = LoadFromLocalStorage(key);
            string value = Marshal.PtrToStringUTF8(valuePtr);
            return value;
            #endif
        }
        else
        {
            return PlayerPrefs.GetString(key);
        }
        return null; 
    }

    public void SaveInt(string key, int value)
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            SaveIntToLocalStorage(key, value);
            #endif
        }
        else
        {
            PlayerPrefs.SetInt(key, value);
        }
    }

    public int LoadInt(string key)
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            return LoadIntFromLocalStorage(key);
            #endif
        }
        else
        {
            return PlayerPrefs.GetInt(key);
        }
        return 0; 
    }

    public void SaveFloat(string key, float value)
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            SaveFloatToLocalStorage(key, value);
            #endif
        }
        else
        {
            PlayerPrefs.SetFloat(key, value);
        }
    }

    public float LoadFloat(string key)
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            return LoadFloatFromLocalStorage(key);
            #endif
        }
        else
        {
            return PlayerPrefs.GetFloat(key);
        }
        return 0.0f; 
    }

    public bool HasKey(string key)
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            return HasKeyInLocalStorage(key);
            #endif
        }
        else
        {
            return PlayerPrefs.HasKey(key);
        }
        return false;
    }

    public void Delete(string key)
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            RemoveFromLocalStorage(key);
            #endif
        }
        else
        {
            PlayerPrefs.DeleteKey(key);
        }
    }

    public void DeleteAll()
    {
        if (IsWebGL())
        {
            #if UNITY_WEBGL
            ClearLocalStorage();
            #endif
        }
        else
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
