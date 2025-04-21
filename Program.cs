using prKol_ind3_Zykova_v6;

//предметный указатель
SubjectIndex index = new SubjectIndex();

Console.WriteLine("1 - ввести с клавиатуры, 2 - вывести из файла");
int num = Convert.ToInt32(Console.ReadLine());

if (num == 1)
{ 
    index.CreateIndexFromInput();

    //вывод указателя
    Console.WriteLine("\nСодержимое предметного указателя:");
    index.DisplayIndex();

    //вывод номеров страниц для заданного слова
    Console.WriteLine("\nВведите слово для поиска номеров страниц:");
    string searchWord = Console.ReadLine();
    index.DisplayPageNumbersForWord(searchWord);

    //удаление записи
    Console.WriteLine("\nВведите слово для удаления:");
    string removeWord = Console.ReadLine();
    index.RemoveEntry(removeWord);

    //обновленные данных
    Console.WriteLine("\nОбновленное содержимое предметного указателя:");
    index.DisplayIndex();
}
else if (num == 2)
{
    string file = "text.txt";
    index.CreateIndexFromFile(file);


    //вывод указателя
    Console.WriteLine("\nСодержимое предметного указателя:");
    index.DisplayIndex();

    //вывод номеров страниц для заданного слова
    Console.WriteLine("\nВведите слово для поиска номеров страниц:");
    string searchWord = Console.ReadLine();
    index.DisplayPageNumbersForWord(searchWord);

    //удаление записи
    Console.WriteLine("\nВведите слово для удаления:");
    string removeWord = Console.ReadLine();
    index.RemoveEntry(removeWord);

    //обновленные данных
    Console.WriteLine("\nОбновленное содержимое предметного указателя:");
    index.DisplayIndex();
}
else
{
    Console.WriteLine("неккоректный ввод. введите 1 или 2.");
}
