using prKol_ind3_Zykova_v6;

//предметный указатель
SubjectIndex index = new SubjectIndex();

Console.WriteLine("1 - ввести с клавиатуры, 2 - вывести из файла");
int num = Convert.ToInt32(Console.ReadLine());

if (num == 1)
{
    Console.WriteLine("Введите слово указатель: ");
    string slovo = Console.ReadLine();
    index.DisplayPageNumbersForWord(slovo);

}
else if (num == 2)
{

}
else
{
    Console.WriteLine("неккоректный ввод. введите 1 или 2.");
}
