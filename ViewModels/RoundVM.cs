using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.ViewModels
{
    public class ParticipantsMoves
    {
        public int moveID { get; set; }
        public double CharacterHP { get; set; }
        public double CharacterDamage {get;set;}
        public double MonsterHP { get; set; }
        public double MonsterDamage { get; set; }

    }
    public class RoundVM
    {
        public List<ParticipantsMoves> particispantsMoves { get; set; }
        public double CharacterHitChance { get; set; }
        public double MonsterHitChance { get; set; }
        public bool IsPlayerWon { get; set; }
        public RoundVM()
        {
            particispantsMoves = new List<ParticipantsMoves>();
        }
    }
}
