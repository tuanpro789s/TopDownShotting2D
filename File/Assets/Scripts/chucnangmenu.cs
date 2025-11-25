using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chucnangmenu : MonoBehaviour
{
   public void Choimoi()
    {
        SceneManager.LoadScene(1);
        
    }
    public void Thoat()
    {
        SceneManager.LoadScene(0);
        
    }
    public void thoatgame()
    {
        Application.Quit();
        
    }
}
