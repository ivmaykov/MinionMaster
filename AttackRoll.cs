using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinionMaster
{
    internal readonly struct AttackRoll
    {
        internal AttackRoll(int firstRoll, int secondRoll)
        {
            this.FirstRoll = firstRoll;
            this.SecondRoll = secondRoll;
        }

        internal int FirstRoll { get; }
        internal int SecondRoll { get; }

        private int getEffectiveBaseRoll(Advantage advantage)
        {
            switch (advantage)
            {
                case Advantage.None:
                    return FirstRoll;
                case Advantage.Advantage:
                    return Math.Max(FirstRoll, SecondRoll);
                case Advantage.Disadvantage:
                    return Math.Min(FirstRoll, SecondRoll);
                default:
                    throw new Exception("Invalid advantage enum value");
            }
        }

        internal AttackResult getAttackResult(Advantage advantage, int attackModifier, int targetAC)
        {
            return getAttackResult(getEffectiveBaseRoll(advantage), attackModifier, targetAC);
        }

        internal AttackResult getAttackResult(int attackRoll, int attackModifier, int targetAC)
        {
            if (attackRoll == 20)
            {
                return AttackResult.Crit;
            }
            else if (attackRoll == 1)
            {
                return AttackResult.CritFail;
            }
            else if (attackRoll + attackModifier >= targetAC)
            {
                return AttackResult.Hit;
            }
            else
            {
                return AttackResult.Miss;
            }
        }

        internal String describe(Advantage advantage, int attackModifier, int targetAC)
        {
            AttackResult attackResult = getAttackResult(advantage, attackModifier, targetAC);
            int baseRoll = getEffectiveBaseRoll(advantage);
            int totalRoll = baseRoll + attackModifier;
            String desc = (baseRoll + attackModifier).ToString();
            if (attackModifier != 0 || Advantage.None != advantage)
            {
                desc += " (";
                // Advantage/Disadvantage goes first
                if (Advantage.None == advantage)
                {
                    desc += baseRoll;
                }
                else if (Advantage.Advantage == advantage)
                {
                    desc += "max(" + FirstRoll + ", " + SecondRoll + ")";
                }
                else if (Advantage.Disadvantage == advantage)
                {
                    desc += "min(" + FirstRoll + ", " + SecondRoll + ")";
                }

                if (attackModifier > 0)
                {
                    desc += "+" + attackModifier;
                }
                else if (attackModifier < 0)
                {
                    desc += attackModifier;
                }
                desc += ")";
            }
            desc += " vs AC " + targetAC + " is a ";
            if (AttackResult.Miss == attackResult)
            {
                desc += "miss :(";
            }
            else if (AttackResult.Hit == attackResult)
            {
                desc += "hit";
            }
            else if (AttackResult.CritFail == attackResult)
            {
                desc += "crit fail :(";
            }
            else
            {
                desc += "crit";
            }
            return desc;
        }
    }
}
