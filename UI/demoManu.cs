using UnityEngine;
using UnityEngine.SceneManagement;


public class demoManu : MonoBehaviour
{
    
    [Header ("Main Manu")]
    [SerializeField] private GameObject ManuScreen;
    [SerializeField] private AudioClip ManuSound;


    [Header ("Pause")]
    [SerializeField] private GameObject pauseScreen;
    
    private void Awake()
    {
        pauseScreen.SetActive(false);
        ManuScreen.SetActive(true);
        SoundManager.instance.PlaySound(ManuSound);
    }
    
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        //if (Input.GetMouseButtonDown(0)) - if you want with a mouseclick
        {
            // if pause screen already active unpause and so on..
            if(pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }
    
    
    #region Game Over

    public void Levels()
    {
        SceneManager.LoadScene(2);
    }


    public void Shop()
    {
        SceneManager.LoadScene(1);
    }


    
    public void PauseInGame()
    {
        PauseGame(true);
    }


    public void Quit()
    {
        Application.Quit(); // quits the game( works only on build)
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // exits playmode ( will only be executed in the editor)
        #endif
    }
    #endregion 



    #region Pause

    public void PauseGame(bool status)
    {
        // if status == true, pause the game. if status == false, unpause the game.
        pauseScreen.SetActive(status);

        
        // when pause status is true, change timescale to 0 (time stops). when its false change it back to 1 (time goes by normally).
        if(status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.20f); // by how much the volume goes up every time *3
    }
    
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.20f); // by how much the volume goes up every time *3
    }
    
    #endregion

}
