using UnityEngine.SceneManagement;
using UnityEngine;

public class cCRT : MonoBehaviour
{
    public GameObject text;
    public bool show = false; 
    public void back()
    {
        SceneManager.LoadScene(0);
    }
    public void ssss()
    {
        show = !show;
    }
    private void Update()
    {
        if (show)
        {
            text.SetActive(true);
        }else if (!show)
        {
            text.SetActive(false);
        }
        
    }
}
