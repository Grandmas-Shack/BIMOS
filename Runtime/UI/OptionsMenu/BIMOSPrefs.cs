namespace KadenZombie8.BIMOS.Settings
{
    public static class BIMOSPrefs
    {
        private static readonly string _prefix = "BIMOS_";

        // Bool
        public static bool GetBool(string key, bool defaultValue = false)
            => UnityEngine.PlayerPrefs.GetInt(_prefix + key, defaultValue ? 1 : 0) != 0;

        public static void SetBool(string key, bool value)
            => UnityEngine.PlayerPrefs.SetInt(_prefix + key, value ? 1 : 0);

        // Int
        public static int GetInt(string key, int defaultValue = 0)
            => UnityEngine.PlayerPrefs.GetInt(_prefix + key, defaultValue);

        public static void SetInt(string key, int value)
            => UnityEngine.PlayerPrefs.SetInt(_prefix + key, value);

        // Float
        public static float GetFloat(string key, float defaultValue = 0f)
            => UnityEngine.PlayerPrefs.GetFloat(_prefix + key, defaultValue);

        public static void SetFloat(string key, float value)
            => UnityEngine.PlayerPrefs.SetFloat(_prefix + key, value);

        // String
        public static string GetString(string key, string defaultValue = "")
            => UnityEngine.PlayerPrefs.GetString(_prefix + key, defaultValue);

        public static void SetString(string key, string value)
            => UnityEngine.PlayerPrefs.SetString(_prefix + key, value);
    }
}
