
using System;
using Blobs.Models.AttackTypes;

namespace Blobs.Models.Blobs
{
    using Interfaces;

    public abstract class Blob : IBlob
    {
        private string name;
        private int health;
        private int damage;
        private string blobType;
        private string attackType;


        protected Blob(string name, int health, int damage, string blobType, string attackType)
        {
            this.Name = name;
            this.InitialHealth = health;
            this.Health = health;
            this.Damage = damage;
            this.blobType = blobType;
            this.attackType = attackType;
        }

        public string Name { get; }

        public int Health { get; set; }

        public int InitialHealth
        {
            get { return this.health; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("health should be positive.");
                }

                this.health = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("damage should be positive.");
                }

                this.damage = value;
            }
        }

        public bool InSpecialBahavior { get; set; }



        public IAttackType ProduceAttack(string attackType)
        {
            switch (attackType)
            {
                case "PutridFart":
                    return new PutridFart(this.Damage);
                case "Blobplode":
                    this.Health /= 2;
                    return new Blobplode(this.Damage);
                default:
                    throw new InvalidOperationException("The attackType is invalid");
            }
        }

        public void RespondToAttack(IAttackType attack)
        {
            attack.Hit(this);
        }

        public abstract void Update();

    }
}
