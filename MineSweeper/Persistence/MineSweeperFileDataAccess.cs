using System;
using System.IO;
using System.Threading.Tasks;

namespace MineSweeper.Persistence
{
    public class MineSweeperFileDataAccess : IMineSweeperDataAccess
    {
        public async Task<MineField> LoadAsync(String path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path)) // fájl megnyitása
                {
                    String line = await reader.ReadLineAsync();
                    String[] numbers = line.Split(' '); // beolvasunk egy sort, és a szóköz mentén széttöredezzük
                    Int32 FieldSize = Int32.Parse(numbers[0]); // beolvassuk a tábla méretét
                    Int32 MineNumber = Int32.Parse(numbers[1]); // beolvassuk a házak méretét
                    Boolean PlayerTurn = Boolean.Parse(numbers[2]);
                    Int32 RevealedNumber = Int32.Parse(numbers[3]);

                    MineField field = new MineField(FieldSize, MineNumber); // létrehozzuk a táblát
                    field.SetPlayer1Turn(PlayerTurn);
                    field.SetRevealedFields(RevealedNumber);

                    for (Int32 i = 0; i < FieldSize; i++)
                    {
                        line = await reader.ReadLineAsync();
                        numbers = line.Split(' ');

                        for (Int32 j = 0; j < FieldSize; j++)
                        {
                           field.SetFieldValue(i, j, Int32.Parse(numbers[j]), false);
                        }
                    }

                    for (Int32 i = 0; i < FieldSize; i++)
                    {
                        line = await reader.ReadLineAsync();
                        String[] locks = line.Split(' ');

                        for (Int32 j = 0; j < FieldSize; j++)
                        {
                            if (Boolean.Parse(locks[j]) == true)
                            {
                               field.SetReveal(i, j,true);
                            }
                        }
                    }

                    return field;
                }
            }
            catch
            {
                throw new MineSweeperDataException();
            }
        }
        public async Task SaveAsync(String path, MineField table)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path)) // fájl megnyitása
                {
                    writer.Write(table.GetFieldSize); // kiírjuk a méreteket
                    await writer.WriteAsync(" " + table.GetMineNumber);
                    await writer.WriteAsync(" " + table.GetPlayerTurn);
                    await writer.WriteLineAsync(" " + table.GetRevealedFields);
                    for (Int32 i = 0; i < table.GetFieldSize; i++)
                    {
                        for (Int32 j = 0; j < table.GetFieldSize; j++)
                        {
                            await writer.WriteAsync(table.GetFieldValue(i, j) + " "); // kiírjuk az értékeket
                        }
                        await writer.WriteLineAsync();
                    }
                    for (Int32 i = 0; i < table.GetFieldSize; i++)
                    {
                        for (Int32 j = 0; j < table.GetFieldSize; j++)
                        {
                            await writer.WriteAsync(table.GetFieldReveal(i,j) + " "); // kiírjuk az értékeket
                        }
                        await writer.WriteLineAsync();
                    }
                }
            }
            catch
            {
                throw new MineSweeperDataException();
            }
        }
    }
}
