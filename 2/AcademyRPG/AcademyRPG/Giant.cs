﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Giant : Character, IFighter, IGatherer
    {
        private int attackPoints;
        private bool hasGathered;

        public Giant(string name, Point position) : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.attackPoints = 150;
            this.hasGathered = false;
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
                return 80;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {

            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type==ResourceType.Stone)
            {
                if (!hasGathered)
                {
                    this.attackPoints += 100;
                    this.hasGathered = true;
                }

                return true;
            }


            return false;
        }
    }
}
