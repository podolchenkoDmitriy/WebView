using UnityEngine;

public class WebViewInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    private WebViewObject webViewObject;
    public string UA_RU_URL;
    public string Other_URL;
    public static string URL;
    private void Start()
    {
        if (PlayerPrefs.HasKey("URL"))
        {
            URL = PlayerPrefs.GetString("URL");
        }
        else
        {
            var countryCode = Application.systemLanguage.ToCountryCode();
            if (countryCode == "UA" || countryCode == "RU")
            {
                URL = UA_RU_URL;

            }
            else
            {
                URL = Other_URL;
            }
        }
        

    }
    private void Initialize()
    {
        if (webViewObject != null)
        {
            webViewObject.SetVisibility(true);
        }
        else
        {
            webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();

            webViewObject.Init(ld: (msg) =>
            {
                Debug.Log(string.Format("CallOnLoaded[{0}]", msg));
                URL = msg;
            });

        webViewObject.SetCenterPositionWithScale(Vector2.zero + Vector2.up * Screen.height * 0.1f, new Vector2(Screen.width, Screen.height * 0.8f));

            webViewObject.SetVisibility(true);

            webViewObject.AddCustomHeader("QWE", "!");

            webViewObject.LoadURL(URL);

            UIInstance.instance.StartTutorial();
        }

        Time.timeScale = 0;

    }

    private void OnEnable()
    {
        EventManager.OnClicked += Initialize;
    }

    private void OnDisable()
    {
        EventManager.OnClicked -= Initialize;

    }

    private void OnApplicationQuit()
    {

        PlayerPrefs.SetString("URL", URL);

    }


}
