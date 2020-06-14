﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class DevButtons : MonoBehaviour
    {
        private PlayerController _pController;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            _pController = new PlayerController();

            _pController.FlightActions.RestartScene.performed += _ => ResetScene();
            _pController.FlightActions.QuitGame.performed += _ => ExitGame();
        }

        /// <summary>
        /// Method to reset the scene in case of bug
        /// </summary>
        private void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        /// <summary>
        /// Method to exit the game
        /// </summary>
        private void ExitGame()
        {
            Application.Quit();
        }

        /// <summary>
        /// This function is called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            _pController.FlightActions.Enable();
        }

        /// <summary>
        /// This function is called when the object becomes disabled and inactive
        /// </summary>
        private void OnDisable()
        {
            _pController.FlightActions.Disable();
        }
    }
}