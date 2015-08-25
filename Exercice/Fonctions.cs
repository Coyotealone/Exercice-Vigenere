using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice
{
    class Fonctions
    {
        public string Crypt(string clair, string clef)
        {
            string resultat = "";
            System.Text.StringBuilder sb_clair = new System.Text.StringBuilder(clair);
            System.Text.StringBuilder sb_clef = new System.Text.StringBuilder(clef);
            int taille = clair.Length;
            int taille_clef = clef.Length;
            //resultat = new char[taille];
            int j = 0;
            for (int i = 0; i < taille; i++ )
            {
                char temp_clair = Char.ToLower(sb_clair[i]);
                char temp_clef = Char.ToLower(sb_clef[j]);
                if (CharToInt(temp_clair) != -1)
                {
                    int temp = CharToInt(temp_clair) + CharToInt(temp_clef);
                    j++;

                    if (j == taille_clef)
                    {
                        j = 0;
                    }
                    if (temp > 25)
                    {
                        temp = temp - 26;
                    }
                    char temp_crypt = IntToChar(temp);
                    resultat += temp_crypt;
                }
            }
            return resultat;
        }

        public string Decrypt(string chiffre, string clef)
        {
            string resultat = "";
            System.Text.StringBuilder sb_chiffre = new System.Text.StringBuilder(chiffre);
            System.Text.StringBuilder sb_clef = new System.Text.StringBuilder(clef);
            int taille = chiffre.Length;
            int taille_clef = clef.Length;
            //resultat = new char[taille];
            int j = 0;
            for (int i = 0; i < taille; i++)
            {
                char temp_chiffre = Char.ToLower(sb_chiffre[i]);
                char temp_clef = Char.ToLower(sb_clef[j]);
                if (CharToInt(temp_chiffre) != -1)
                {
                    int temp = CharToInt(temp_chiffre) - CharToInt(temp_clef);
                    j++;

                    if (j == taille_clef)
                    {
                        j = 0;
                    }
                    if (temp > 25)
                    {
                        temp = temp - 26;
                    }
                    if(temp < 0)
                    {
                        temp = 26 + temp;
                    }
                    char temp_crypt = IntToChar(temp);
                    resultat += temp_crypt;
                }
            }
            return resultat;
        }

        public int CharToInt(Char key)
        {
            switch (key)
            {
                case 'a':
                    return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'e':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                case 'i':
                    return 8;
                case 'j':
                    return 9;
                case 'k':
                    return 10;
                case 'l':
                    return 11;
                case 'm':
                    return 12;
                case 'n':
                    return 13;
                case 'o':
                    return 14;
                case 'p':
                    return 15;
                case 'q':
                    return 16;
                case 'r':
                    return 17;
                case 's':
                    return 18;
                case 't':
                    return 19;
                case 'u':
                    return 20;
                case 'v':
                    return 21;
                case 'w':
                    return 22;
                case 'x':
                    return 23;
                case 'y':
                    return 24;
                case 'z':
                    return 25;
                default:
                    return -1;
            }
        }

        public char IntToChar(int key)
        {
            switch (key)
            {
                case 0:
                    return 'a';
                case 1:
                    return 'b';
                case 2:
                    return 'c';
                case 3:
                    return 'd';
                case 4:
                    return 'e';
                case 5:
                    return 'f';
                case 6:
                    return 'g';
                case 7:
                    return 'h';
                case 8:
                    return 'i';
                case 9:
                    return 'j';
                case 10:
                    return 'k';
                case 11:
                    return 'l';
                case 12:
                    return 'm';
                case 13:
                    return 'n';
                case 14:
                    return 'o';
                case 15:
                    return 'p';
                case 16:
                    return 'q';
                case 17:
                    return 'r';
                case 18:
                    return 's';
                case 19:
                    return 't';
                case 20:
                    return 'u';
                case 21:
                    return 'v';
                case 22:
                    return 'w';
                case 23:
                    return 'x';
                case 24:
                    return 'y';
                case 25:
                    return 'z';
                default:
                    return ' ';
            }
        }

        public async void CreateTable()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("exercice");
            await conn.CreateTableAsync<DB>();
        }

        public async void InsertDB(DB data)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("exercice");
            await conn.InsertAsync(data);
        }

        public async Task<DB> GetDB(int id)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("exercice");

            var query = conn.Table<DB>().Where(x => x.Id == id);
            var result = await query.ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<List<DB>> GetDBs()
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("exercice");

            var query = conn.Table<DB>();
            var result = await query.ToListAsync();

            return result;
        }

        public async void UpdateDB(DB data)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("exercice");
            await conn.UpdateAsync(data);
        }

        public async void DeleteDB(DB data)
        {
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection("exercice");
            await conn.DeleteAsync(data);
        }

        public string ListDataDB()
        {
            Task<List<DB>> test = GetDBs();
            Task<DB> test2 = GetDB(0);
            //foreach(string datas in test)
            //{

            //}
            return "Boum";
        }
    }
}
