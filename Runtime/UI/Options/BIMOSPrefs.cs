namespace KadenZombie8.BIMOS.Settings
{
    public static class BIMOSPrefs
    {
        public static bool GetBool(string key, bool defaultValue = false)
            => UnityEngine.PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) != 0;

        public static void SetBool(string key, bool value)
            => UnityEngine.PlayerPrefs.SetInt(key, value ? 1 : 0);

        public static int GetInt(string key, int defaultValue = 0)
            => UnityEngine.PlayerPrefs.GetInt(key, defaultValue);

        public static void SetInt(string key, int value)
            => UnityEngine.PlayerPrefs.SetInt(key, value);

        public static float GetFloat(string key, float defaultValue = 0f)
            => UnityEngine.PlayerPrefs.GetFloat(key, defaultValue);

        public static void SetFloat(string key, float value)
            => UnityEngine.PlayerPrefs.SetFloat(key, value);

        public static string GetString(string key, string defaultValue = "")
            => UnityEngine.PlayerPrefs.GetString(key, defaultValue);

        public static void SetString(string key, string value)
            => UnityEngine.PlayerPrefs.SetString(key, value);
    }
}
