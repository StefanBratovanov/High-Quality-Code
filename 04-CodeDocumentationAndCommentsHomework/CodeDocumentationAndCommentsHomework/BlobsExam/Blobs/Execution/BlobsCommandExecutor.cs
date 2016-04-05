

using Blobs.Models.Blobs;

namespace Blobs.Execution
{
    using System;
    using System.Text;
    using Blobs.Interfaces;
    using Blobs.Execution.Factories;
    using System.Linq;
    using Blobs.Models.Interfaces;

    public class BlobsCommandExecutor : ICommandExecutor
    {
        private IDatabase database;
        private IUserInterface userInterface;
        private IBlobFactory blobFactory;

        public BlobsCommandExecutor()
        {
            this.database = new BlobsDatabase();
            this.blobFactory = new BlobFactory();
        }

        public string ExecuteCommand(ICommand command)
        {
            string commandResult = null;
            switch (command.Name)
            {
                case "create":
                    commandResult = ExecuteCreateCommand(command);
                    this.UpdateBlobs();
                    break;
                case "attack":
                    commandResult = ExecuteAttackCommand(command);
                    this.UpdateBlobs();
                    break;
                case "status":
                    commandResult = ExecuteStatusCommand();
                    this.UpdateBlobs();
                    break;
                case "pass":
                    this.UpdateBlobs();
                    break;

                default:
                    throw new InvalidOperationException("The command name is invalid");
            }

            return commandResult;
        }

        private string ExecuteAttackCommand(ICommand command)
        {
            string attackerName = command.Parameters[0];
            string targetName = command.Parameters[1];

            var attacker = this.GetBlobByName(attackerName);
            var target = this.GetBlobByName(targetName);

            this.ProcessBlobsBattle(attacker, target);

            return null;
        }

        private void ProcessBlobsBattle(IBlob attacker, IBlob target)
        {
            this.ValidateAlive(attacker);
            this.ValidateAlive(target);

            var attackerBehavior = this.CheckBehavior(attacker);

            //var attack = attacker.ProduceAttack(attacker.attackType);
            //target.RespondToAttack(attack);

            if (target.Health <= 0)
            {
                target.Health = 0;
            }
        }

        private bool CheckBehavior(IBlob attacker)
        {
            if (attacker.Health <= attacker.InitialHealth / 2)
            {
                attacker.InSpecialBahavior = true;

                if (attacker is Aggressive)
                {
                    attacker.Damage *= 2;
                }

                if (attacker is Inflated)
                {
                    attacker.Health += 50;
                }

                return true;
            }
            return false;
        }

        private void ValidateAlive(IBlob blob)
        {
            if (blob.Health < 0)
            {
                throw new ArgumentOutOfRangeException("Dead blobs cannot attack / be attacked");
            }
        }

        private string ExecuteCreateCommand(ICommand command)
        {
            string name = command.Parameters[0];
            int health = int.Parse(command.Parameters[1]);
            int damage = int.Parse(command.Parameters[2]);
            string behavior = command.Parameters[3];
            string attackType = command.Parameters[4];


            IBlob blob = this.blobFactory.ProduceBlob(name, health, damage, behavior, attackType);
            this.database.Blobs.Add(blob);

            return null;
        }

        private string ExecuteStatusCommand()
        {
            StringBuilder output = new StringBuilder();
            foreach (var blob in this.database.Blobs)
            {
                if (blob.Health == 0)
                {
                    output.AppendFormat("Blob {0} KILLED", blob.Name).AppendLine();
                }
                else
                {
                    output.AppendFormat("Blob {0}: {1} HP, {2} Damage", blob.Name, blob.Health, blob.Damage).AppendLine();
                }
            }

            return output.ToString().Trim();
        }

        protected IBlob GetBlobByName(string name)
        {
            return this.database.Blobs.First(s => s.Name == name);
        }

        private void UpdateBlobs()
        {
            foreach (IBlob blob in this.database.Blobs)
            {
                blob.Update();
            }
        }
    }
}
