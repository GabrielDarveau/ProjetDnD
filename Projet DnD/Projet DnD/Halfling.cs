﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_DnD
{
    internal class Halfling : Race
    {
        //Attributs
        int[] bonus = new int[6] { 0, 2, 0, 0, 0, 0 };
        //Méthodes
        public override int[] GetBonus()
        {
            return bonus;
        }
    }
}
