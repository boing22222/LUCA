using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currUIPanel;
    public bool isEnd;
    public static UIManager GetInstance;
    private void Awake()
    {
        GetInstance = this;
        currUIPanel = GameObject.Find("MainMenu");
        isEnd = false;
    }
    public void EnterPanel(GameObject otherPanel)
    {
        UIBase newUI = otherPanel.GetComponent<UIBase>();
        if (newUI == null)
        {
            Debug.LogError(" has no UI script!");
        }
        if (newUI.state == UIState.Exit)
        {
            if (currUIPanel != null) currUIPanel.GetComponent<UIBase>().OnExit();
            currUIPanel = otherPanel;
            currUIPanel.GetComponent<UIBase>().OnEnter();
        }
        Time.timeScale = 0;
    }
    public void EnterGameScene()
    {
        Time.timeScale = 1;
        Timer.GetInstance.isCount = true;
        currUIPanel.GetComponent<UIBase>().OnExit();
        currUIPanel = null;
    }
    void Update()
    {
        if (currUIPanel == null&&Time.timeScale!=0)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                currUIPanel = GameObject.Find("PauseMenu");
                currUIPanel.GetComponent<UIBase>().OnEnter();
            }
        }
    }
}
