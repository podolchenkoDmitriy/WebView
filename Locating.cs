using System.Collections.Generic;
using UnityEngine;

public class Locating : MonoBehaviour
{
    public string UA_RU_URL;
    public string Other_URL;
    public static string URL;

    private static readonly Dictionary<SystemLanguage, string> COUTRY_CODES = new Dictionary<SystemLanguage, string>()
        {
            { SystemLanguage.Afrikaans, "ZA" },
            { SystemLanguage.Arabic    , "SA" },
            { SystemLanguage.Basque    , "US" },
            { SystemLanguage.Belarusian    , "BY" },
            { SystemLanguage.Bulgarian    , "BJ" },
            { SystemLanguage.Catalan    , "ES" },
            { SystemLanguage.Chinese    , "CN" },
            { SystemLanguage.Czech    , "HK" },
            { SystemLanguage.Danish    , "DK" },
            { SystemLanguage.Dutch    , "BE" },
            { SystemLanguage.English    , "US" },
            { SystemLanguage.Estonian    , "EE" },
            { SystemLanguage.Faroese    , "FU" },
            { SystemLanguage.Finnish    , "FI" },
            { SystemLanguage.French    , "FR" },
            { SystemLanguage.German    , "DE" },
            { SystemLanguage.Greek    , "JR" },
            { SystemLanguage.Hebrew    , "IL" },
            { SystemLanguage.Icelandic    , "IS" },
            { SystemLanguage.Indonesian    , "ID" },
            { SystemLanguage.Italian    , "IT" },
            { SystemLanguage.Japanese    , "JP" },
            { SystemLanguage.Korean    , "KR" },
            { SystemLanguage.Latvian    , "LV" },
            { SystemLanguage.Lithuanian    , "LT" },
            { SystemLanguage.Norwegian    , "NO" },
            { SystemLanguage.Polish    , "PL" },
            { SystemLanguage.Portuguese    , "PT" },
            { SystemLanguage.Romanian    , "RO" },
            { SystemLanguage.Russian    , "RU" },
            { SystemLanguage.SerboCroatian    , "SP" },
            { SystemLanguage.Slovak    , "SK" },
            { SystemLanguage.Slovenian    , "SI" },
            { SystemLanguage.Spanish    , "ES" },
            { SystemLanguage.Swedish    , "SE" },
            { SystemLanguage.Thai    , "TH" },
            { SystemLanguage.Turkish    , "TR" },
            { SystemLanguage.Ukrainian    , "UA" },
            { SystemLanguage.Vietnamese    , "VN" },
            { SystemLanguage.ChineseSimplified    , "CN" },
            { SystemLanguage.ChineseTraditional    , "CN" },
            { SystemLanguage.Unknown    , "US" },
            { SystemLanguage.Hungarian    , "HU" },
        };

    /// <summary>
    /// Returns approximate country code of the language.
    /// </summary>
    /// <returns>Approximated country code.</returns>
    /// <param name="language">Language which should be converted to country code.</param>
    public static string ToCountryCode(this SystemLanguage language)
    {
        if (COUTRY_CODES.TryGetValue(language, out string result))
        {
            return result;
        }
        else
        {
            return COUTRY_CODES[SystemLanguage.Unknown];
        }
    }
    private void Awake()
    {

    }



    private void DetectCountry()
    {

        if (PlayerPrefs.HasKey("URL"))
        {
            URL = PlayerPrefs.GetString("URL");
        }
        else
        {
            if (System.Globalization.RegionInfo.CurrentRegion.Name == "UA")
            {
                URL = UA_RU_URL;
                print(1);
            }
            else if (System.Globalization.RegionInfo.CurrentRegion.Name == "RU")
            {
                URL = UA_RU_URL; print(2);

            }
            else
            {
                URL = Other_URL;
                print(3);

            }
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("URL", URL);

    }
}



