using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace RayOfHope
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject WinPanel;
        [SerializeField]
        private GameObject Player;
        public void OnPlayBehaviour(int SceneIndex)
        {
            SceneManager.LoadScene(SceneIndex);
            Debug.Log("SceneLoaded");
        }
        public void ShowWinPannel()
        {
            WinPanel.SetActive(true);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ShowWinPannel();
            Player.GetComponent<PlayerController>().enabled = false;
        }
        public void QuitGame()
        {
            Application.Quit(0);
        }
    }
}