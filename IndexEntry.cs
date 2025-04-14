using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prKol_ind3_Zykova_v6
{
    //запись в указатель
    internal class IndexEntry
    {
        public string Slova { get; set; }
        public ArrayList PageNumbers { get; set; }

        public IndexEntry(string slova)
        {
            Slova = slova;
            PageNumbers = new ArrayList();
        }

        //добавление номера страниц в список
        public void AddPageNumber(int pageNumber)
        {
            //пока страниц < 10 и страница не добавлена - добавляем номер
            if (PageNumbers.Count < 10 && !PageNumbers.Contains(pageNumber))
            {
                PageNumbers.Add(pageNumber);
            }
        }

        //вывод записи
        public override string ToString()
        {
            return $"{Slova}: Страницы {string.Join(", ", PageNumbers.ToArray())}";
        }
    }
}
