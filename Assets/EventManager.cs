using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnClicked;
    public Texture image;


    private void OnGUI()
    {
        GUIStyle customButton = new GUIStyle(GUI.skin.button)
        {
            fontSize = 50
        };


        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            GUI.DrawTexture(new Rect(Vector2.zero, new Vector2(Screen.width, Screen.height)), image);

        }
        else
        {
            if (GUI.Button(new Rect(50, 40, 200, 80), "WEB", customButton))
            {
                if (OnClicked != null)
                    OnClicked();
            }
        }

    }

}


