using System;
using UnityEngine;

namespace Scripts
{
    public class Stamina : MonoBehaviour
    {
        /// <summary>
        /// Reference to the player script to access Values scriptable object
        /// </summary>
        private Player _pScript;

        /// <summary>
        /// Max allowed stamina
        /// </summary>
        private float _maxStamina;

        /// <summary>
        /// Variable to store the stamina
        /// </summary>
        private float _stamina;

        /// <summary>
        /// Variable to be used in the usage of stamina while flying
        /// </summary>
        private float _timer;

        /// <summary>
        /// Current stamina property
        /// </summary>
        public float CurrStamina => _stamina;

        /// <summary>
        /// Event of the type Action(float) to be used when stamina value changes.
        /// Source of "information" for stamina value observers
        /// </summary>
        public event Action<float> OnStaminaChange;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            _pScript = GetComponent<Player>();
            _maxStamina = _pScript.Values.MaxStamina;
            _stamina = _maxStamina;
        }

        // Update is called once per frame
        private void Update()
        {
            StaminaCounter();
            UseStamina();
        }

        /// <summary>
        /// Method to control how much stamina the player has
        /// </summary>
        private void StaminaCounter()
        {
            if (_stamina <= 0f && _pScript.Flying)
            {
                _pScript?.Action();
            }
        }

        /// <summary>
        /// Uses stamina 
        /// </summary>
        /// <param name="player"> Accepts a player </param>
        private void UseStamina()
        {
            if (_pScript.Flying)
            {
                _timer -= 1f * Time.deltaTime;

                if (_timer <= 0)
                {
                    StaminaChange(-1);
                    _timer = 1f;
                }
            }
        }

        /// <summary>
        /// Method to add or decrease the stamina values
        /// </summary>
        /// <param name="amount">The amount of stamina to be changed </param>
        private void StaminaChange(float amount)
        {
            _stamina += amount;

            _stamina = _stamina > 100 ? _maxStamina : _stamina;

            float staminaPct = _stamina / _maxStamina;

            OnStaminaChange(staminaPct);
        }

        /// <summary>
        /// Public method responsible to call method(s) required to change 
        /// stamina values
        /// </summary>
        /// <param name="amount">The amount of stamina to be changed </param>
        public void OnChange(float amount)
        {
            StaminaChange(amount);
        }
    }
}
