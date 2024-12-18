using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace VinoUtility.Gameplay
{
    public class Health : MonoBehaviour
    {
        public float maxHealth = 10f;

        [Tooltip("Health ratio at which the critical health vignette starts appearing")]
        public float criticalHealthRatio = 0.3f;
        public UnityAction<float, GameObject> OnDamaged;
        public UnityAction<float> OnHealed;
        public UnityAction OnDie;
        public List<IHandleDamage> damageHandlers = new List<IHandleDamage>();
        
        public float currentHealth { get; set; }
        public bool invincible { get; set; }
        public bool CanHeal() => currentHealth < maxHealth;
        public float GetRatio() => currentHealth / maxHealth;
        public bool IsCritical() => (GetRatio() <= criticalHealthRatio);

        bool _isDead;

        void Start()
        {
            currentHealth = maxHealth;
            invincible = false;
            OnDie += () => Destroy(gameObject);
        }

        public void Heal(float healAmount)
        {
            float healthBefore = currentHealth;
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            // call OnHeal action
            float trueHealAmount = currentHealth - healthBefore;
            if (trueHealAmount > 0f)
            {
                OnHealed?.Invoke(trueHealAmount);
            }
        }

        public void TakeDamage(float damage, GameObject damageSource)
        {
            if (invincible)
                return;
            
            //calculate final damage
            foreach (var damageHandler in damageHandlers)
            {
                damage = damageHandler.CalculateDamage(damage);
            }
            
            float healthBefore = currentHealth;
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            // call OnDamage action
            float trueDamageAmount = healthBefore - currentHealth;
            if (trueDamageAmount > 0f)
            {
                OnDamaged?.Invoke(trueDamageAmount, damageSource);
            }

            HandleDeath();
        }

        public void Kill()
        {
            currentHealth = 0f;

            // call OnDamage action
            OnDamaged?.Invoke(maxHealth, null);

            HandleDeath();
        }

        void HandleDeath()
        {
            if (_isDead)
                return;

            // call OnDie action
            if (currentHealth <= 0f)
            {
                _isDead = true;
                OnDie?.Invoke();
                NetGameObjectManager.Instance.Delete(GetComponent<Mirror.NetworkIdentity>());
            }
        }

        //Test
        private void Update() {
            #if UNITY_EDITOR
            if(Input.GetKeyDown(KeyCode.F1))
            {
                Debug.Log("Take Damage");
                TakeDamage(5 ,null);
            }
            #endif
        }
        private void Awake() {
            OnDamaged += (damage, damageSource) => {
                //GetComponent<Animator>()?.SetTrigger("hit");
            };
        }
    }
}