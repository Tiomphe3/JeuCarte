/*ing System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SinuousProductions; // Assurez-vous d'importer le bon namespace

namespace SinuousProductions.Tests // Namespace pour les tests
{
    public class CardTests
    {
        private  CardTest card ;

        [SetUp]
        public void Setup()
        {
            card= ScriptableObject.CreateInstance<CardTest>();
            card. // Initialiser la santé à 10
        }

        [Test]
        public void TakeDamage_ReduceHealth()
        {
            card.TakeDamage(3);
            Assert.AreEqual(7, card.GetHealth());
        }

        [Test]
        public void TakeDamage_WithBlock_DoesNotReduceHealth()
        {
            card.SetBlock(5);
            card.TakeDamage(3);
            Assert.AreEqual(10, card.GetHealth()); // La santé ne change pas car les dégâts sont bloqués
        }

        [Test]
        public void DealDamage_ReduceTargetHealth()
        {
            Card targetCard = ScriptableObject.CreateInstance<Card>();
            targetCard.SetHealth(10);
            
            card.DealDamage(targetCard, 5);
            Assert.AreEqual(5, targetCard.GetHealth());
        }

        [Test]
        public void Revive_SetHealthToFive()
        {
            card.SetHealth(0); // Simuler que la carte est morte
            card.Revive();
            Assert.AreEqual(5, card.GetHealth()); // Vérifier que la santé est réinitialisée à 5
        }

        [Test]
        public void Attack_DamageTargetCard()
        {
            Card targetCard = ScriptableObject.CreateInstance<Card>();
            targetCard.SetHealth(10);

            card.Attack(targetCard); // Attaque inflige 5 dégâts
            Assert.AreEqual(5, targetCard.GetHealth()); // Vérifier que la santé cible est réduite
        }
    }
}
*/