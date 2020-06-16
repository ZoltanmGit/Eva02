using System;
using System.Threading.Tasks;

namespace MineSweeper.Persistence
{
    public interface IMineSweeperDataAccess
    {
        Task<MineField> LoadAsync(String path);
        Task SaveAsync(String path, MineField table);
    }
}
