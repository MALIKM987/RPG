using UnityEngine;

namespace RPG.Data
{
    [System.Serializable]
    public class CharacterStats
    {
        public int maxHP = 100;
        public int currentHP = 100;

        public int maxMana = 30;
        public int currentMana = 30;

        public int strength = 5;
        public int dexterity = 5;
        public int intelligence = 5;
        public int endurance = 5;
        public int speed = 5;

        public void TakeDamage(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            currentHP = Mathf.Max(currentHP - amount, 0);
        }

        public void Heal(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            currentHP = Mathf.Min(currentHP + amount, maxHP);
        }

        public bool SpendMana(int amount)
        {
            if (amount <= 0)
            {
                return true;
            }

            if (currentMana < amount)
            {
                return false;
            }

            currentMana -= amount;
            return true;
        }

        public void RestoreMana(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            currentMana = Mathf.Min(currentMana + amount, maxMana);
        }
    }
}
