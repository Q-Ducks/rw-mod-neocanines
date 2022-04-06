using RimWorld;
using Verse;
using Verse.Grammar;

namespace NeocanineSpecials {
    public class RulePersonVanilla : Rule
    {
        public PawnNameSlot nameSlot;
        public Gender gender;

        public override float BaseSelectionWeight => 1f;

        public override Rule DeepCopy()
        {
            var newInstance = (RulePersonVanilla) base.DeepCopy();
            newInstance.nameSlot = this.nameSlot;
            newInstance.gender = this.gender;
            return newInstance;
        }

        public override string Generate()
        {
            NameBank nameBank = PawnNameDatabaseShuffled.BankOf(PawnNameCategory.HumanStandard);
            Gender gander = this.gender;

            switch(this.nameSlot) {
                case PawnNameSlot.Last: {
                    return nameBank.GetName(PawnNameSlot.Last, Gender.None, false);
                }
                case PawnNameSlot.Nick: {
                    return nameBank.GetName(PawnNameSlot.Nick, gender, false);
                }
                default: {
                    if (gender == Gender.None) {
                        gender = ((double) Rand.Value < 0.5) ? Gender.Male : Gender.Female;
                    }
                    return nameBank.GetName(this.nameSlot, gender, false);
                }
            }
        }

        public override string ToString()
        {
            return this.keyword + "->(personname)";
        }
    }
}
