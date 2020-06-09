using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    public class StaminaBarUI : MonoBehaviour
    {
        [SerializeField] private Image foregroundBar = default;
        [SerializeField] private Stamina _staminaScript = default;
        [SerializeField] private float updateSpeedSeconds = default;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            _staminaScript.OnStaminaChange += HandleStaminaChange;
        }

        /// <summary>
        /// Method to call a coroutine to handle the change in the stamina bar
        /// </summary>
        /// <param name="pct"></param>
        private void HandleStaminaChange(float pct)
        {
            StartCoroutine(ChangeToPct(pct));
        }

        private IEnumerator ChangeToPct(float pct)
        {
            float preChangePct = foregroundBar.fillAmount;
            float elapsed = 0f;

            while (elapsed < updateSpeedSeconds)
            {
                elapsed += Time.deltaTime;

                foregroundBar.fillAmount = Mathf.Lerp(
                            preChangePct, pct, elapsed / updateSpeedSeconds);
                
                yield return null;
            }

            foregroundBar.fillAmount = pct;
        }
    }
}
