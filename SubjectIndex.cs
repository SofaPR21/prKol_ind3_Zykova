using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prKol_ind3_Zykova_v6
{
    //управление указателями
    internal class SubjectIndex
    {
        private ArrayList indexEntry;

        public SubjectIndex()
        {
            indexEntry = new ArrayList();
        }

        //добавление новой или обновление имеющейся записи
        public void AddEntry(string slovo, int pageNumber)
        {
            //поиск записи с нужным словом
            var entry = indexEntry.OfType<IndexEntry>().FirstOrDefault(e => e.Slova.Equals(slovo, StringComparison.OrdinalIgnoreCase));
            if (entry == null) 
            {
                entry = new IndexEntry(slovo); //cоздаем запись
                indexEntry.Add(entry);
            }
            entry.AddPageNumber(pageNumber); 
        }

        //метод для ввода указателя с клавиатуры
        public void CreateIndexFromInput()
        {
            Console.WriteLine("Введите количество записей:");
            int numberOfEntries = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEntries; i++)
            {
                Console.WriteLine("Введите слово:");
                string word = Console.ReadLine();

                Console.WriteLine("Введите номера страниц (через запятую):");
                string[] pages = Console.ReadLine().Split(',');

                foreach (var page in pages)
                {
                    if (int.TryParse(page.Trim(), out int pageNumber))
                    {
                        AddEntry(word, pageNumber);
                    }
                }
            }
        }

        //вывод указателя из файла
        public void CreateIndexFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                //формат: слово;номер страницы,номер страницы,...
                var parts = line.Split(';');

                if (parts.Length < 2)
                {
                    continue;
                }

                string word = parts[0].Trim();
                var pages = parts[1].Split(',');

                foreach (var page in pages)
                {
                    if (int.TryParse(page.Trim(), out int pageNumber))
                    {
                        AddEntry(word, pageNumber);
                    }
                }
            }
        }

        //вывод номера страниц для заданного слова
        public void DisplayPageNumbersForWord(string word)
        {
            var entry = indexEntry.OfType<IndexEntry>().FirstOrDefault(e => e.Slova.Equals(word, StringComparison.OrdinalIgnoreCase));
            if (entry != null)
            {
                Console.WriteLine($"Номера страниц для слова \"{word}\": {string.Join(", ", entry.PageNumbers.ToArray())}");
            }
            else
            {
                Console.WriteLine($"Слово \"{word}\" не найдено в указателе.");
            }
        }

        //удаление записи
        public void RemoveEntry(string word)
        {
            var entry = indexEntry.OfType<IndexEntry>().FirstOrDefault(e => e.Slova.Equals(word, StringComparison.OrdinalIgnoreCase));
            if (entry != null)
            {
                indexEntry.Remove(entry);
                Console.WriteLine($"Запись для слова \"{word}\" была удалена.");
            }
            else
            {
                Console.WriteLine($"Слово \"{word}\" не найдено в указателе.");
            }
        }


        //отображение записей в указателе
        public void DisplayIndex()
        {
            foreach (IndexEntry entry in indexEntry)
            {
                Console.WriteLine(entry); 
            }
        }
    }
}
