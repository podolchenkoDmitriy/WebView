using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIInstance : MonoBehaviour
{
    public static UIInstance instance;

    [Header("UIPanels")]
    [Space]
    public Transform winPanel;
    public Transform losePanel;
    public Text countText;

    public GameObject _animPanel;
    RectTransform trans;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }
        trans = _animPanel.GetComponent<RectTransform>();
        
    }

    private void OnGUI()
    {
        trans.sizeDelta = new Vector2(trans.sizeDelta.x, Screen.height * 0.3f);

    }
    public void Win()
    {
        winPanel.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public void Lose()
    {
        losePanel.gameObject.SetActive(true);
        Time.timeScale = 0;

    }
    public void CountBounces(int i)
    {
        countText.text = i.ToString();
    }

    IEnumerator Tutorial()
    {
        _animPanel.SetActive(true);
        yield return new WaitForSecondsRealtime(12f);
        _animPanel.SetActive(false);
    }
    public void StartTutorial()
    {
        StartCoroutine(Tutorial());
    }
}
