using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
   abstract class CharacterFighter : Character, IFighter
    {
        public CharacterFighter(string name, Point position, int owner) : base(name, position, owner)
        {
        }

        public int AttackPoints
        {
            get;
        }

        public int DefensePoints
        {
            get;
          
        }

        public abstract int GetTargetIndex(List<WorldObject> availableTargets);
       
    }
}
