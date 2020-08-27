using Spifield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly AppDbContext _appDbContext;

        public MonsterRepository(AppDbContext AppDbContext)
        {
            _appDbContext = AppDbContext;
        }
        public Monster GetMonster(int monsterID)
        {
            return _appDbContext.Monsters.FirstOrDefault(x => x.MonsterID == monsterID);
        }
    }
}
