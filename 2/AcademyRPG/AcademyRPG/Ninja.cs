using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints;
       

        public Ninja(string name, Point position, int owner) : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.attackPoints = 0;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
        }
            
        public int DefensePoints
        {
            get
            {
                return int.MaxValue;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
           IEnumerable<WorldObject> differentOwner = availableTargets.Where(x => x.Owner != 0 && x.Owner != this.Owner);
            WorldObject mostHitPoints = differentOwner.OrderByDescending(x => x.HitPoints).FirstOrDefault();
            int result = availableTargets.IndexOf(mostHitPoints);

            return result;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type== ResourceType.Lumber)
            {
                this.attackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type==ResourceType.Stone)
            {
                this.attackPoints += resource.Quantity * 2;
                return true;
            }
            return false;
        }
    }
}
