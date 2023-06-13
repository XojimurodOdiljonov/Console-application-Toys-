using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using Toys.Models;

namespace Toys
{
    class Toy
    {
        private static List<ModelToys> listToy = new List<ModelToys>();
        private static List<ModelToys> roomToy = new List<ModelToys>();
        private static BinaryFormatter formater = new BinaryFormatter();
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Меню: \n" +
                    "1) Создать игрушки\n" +
                    "2) Создать комнату\n" +
                    "3) Удалить игрушку\n" +
                    "4) Показать созданных игрушек\n" +
                    "5) Сортировка\n" +
                    "6) Поиск\n" +
                    "7) Сериализовать\n" +
                    "8) Десериализовать\n" +
                    "9) Вывести на экран сериализованных объектов !");

                int chooisgMenu = Convert.ToInt32(Console.ReadLine());
                switch (chooisgMenu)
                {
                    case 1: { CreateToy(); break; }
                    case 2: { CreateRoom(); break; }
                    case 3: { RemoveToys(); break; }
                    case 4: { ShowCreateToy(); break; }
                    case 5: { SortToy(); break; }
                    case 6: { SearchToys(); break; }
                    case 7: { SaveToyInFile(); break; }
                    case 8: { LoadFile(); break; }
                    case 9: { ShowToys(); break; }
                }
            }
        }

        private static void CreateToy()
        {
            //Создания новой игрушки
            Console.Write("Введите название игрушки: ");
            string nameToy = Convert.ToString(Console.ReadLine());

            Console.Write("Введите размер игрушки: ");
            string sizeToy = Convert.ToString(Console.ReadLine());

            Console.Write("Укажите цену игрушки: ");
            int priceToy = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите возвраст: ");
            int ageToy = Convert.ToInt32(Console.ReadLine());

            ModelToys addToy = new ModelToys(nameToy, sizeToy, priceToy, ageToy);
            listToy.Add(addToy);
        }

        private static void CreateRoom()
        {
            Console.Write("Ведите сумму денег комнате: ");
            int priceRoom = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Выберите игрушку для комнаты: ");
            for(int i =0; i < listToy.Count; i++)
            {
                Console.WriteLine(i + ") " + listToy[i]);
            }
            int choosingToy = Convert.ToInt32(Console.ReadLine());
            roomToy.Add(listToy[choosingToy]);
            priceRoom -= roomToy[choosingToy].Cost;
            Console.WriteLine("У вас осталось столько денег: \n" +
                priceRoom);
        }

        private static void RemoveToys()
        {
            Console.WriteLine("Выбрать игрушеку чтобы удалить: ");
            for (int i = 0; i < listToy.Count; i++)
            {
                Console.WriteLine(i + ") " + listToy[i]);
            }
            int removeToy = Convert.ToInt32(Console.ReadLine());
            if (removeToy <= listToy.Count)
            {
                listToy.RemoveAt(removeToy);
            }
        }

        private static void ShowCreateToy()
        {
            Console.WriteLine("Список созданных игрушек !");

            for (int i = 0; i < listToy.Count; i++)
            {
                Console.WriteLine(i + ") " + listToy[i]);
            }
        }

        private static void SortToy()
        {
            Console.WriteLine("Выберите вид сортировки !\n" +
                "1) По возрастанию\n" +
                "2) По убыванию");

            int choosingItem = Convert.ToInt32(Console.ReadLine());
            switch (choosingItem)
            {
                case 1:
                    var ascendingToys = from i in listToy
                                        orderby i.Cost
                                        select i;
                    foreach (var i in ascendingToys)
                    { Console.WriteLine(i + "\n"); }
                    break;
                case 2:
                    var descendingToys = from i in listToy
                                        orderby i.Cost descending
                                        select i;
                    foreach (var i in descendingToys)
                    { Console.WriteLine(i + "\n"); }
                    break;
            }
        }

        private static void SearchToys()
        {
            Console.Write("Поис по цене - \n" +
                "Ведите минимальную цену: ");
            int minimumCost = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ведите максимальную цену: ");
            int maximumCost = Convert.ToInt32(Console.ReadLine());

            var searchToys = from t in listToy
                             where t.Cost >= minimumCost && t.Cost <= maximumCost
                             select t;

            foreach (var getting in searchToys)
            {
                Console.WriteLine(getting);
            }
        }

        public static void SaveToyInFile()
        {
            using (FileStream fileSave = new FileStream("Toys.dat", FileMode.OpenOrCreate))
            {
               formater.Serialize(fileSave, listToy);

               Console.WriteLine("\nОбъект сериализован\n");
            }
        }

        private static void LoadFile()
        {
            using (FileStream fileLoad = new FileStream("Toys.dat", FileMode.OpenOrCreate))
            {
                listToy = (List<ModelToys>)formater.Deserialize(fileLoad);

                Console.WriteLine("\nОбъект десериализован\n"); 
            }
        }

        private static void ShowToys()
        {
            Console.WriteLine("Десериализованные объекты (Игрушки)");
            for (int i = 0; i < listToy.Count; i++)
            {
                Console.WriteLine(i + ") " + listToy[i] + "\n");
            }
        }
    }
}



