using Spifield.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spifield.Models.Repositories
{
    public interface IMonsterRepository
    {
        Monster GetMonster(int monsterID);
    }
}
