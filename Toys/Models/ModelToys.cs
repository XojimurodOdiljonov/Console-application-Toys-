using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Toys.Models
{
    [Serializable]
    class ModelToys
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public int Cost { get; set; }
        public int Age { get; set; }

        public ModelToys(string name, string size, int cost, int age)
        {
            this.Name = name;
            this.Size = size;
            this.Cost = cost;
            this.Age = age;
        }

        public override string ToString()
        {
            return "Игрушка: " + Name + "\n" +
                "Размер: " + Size + "\n" +
                "Цена: " + Cost + "\n" +
                "Возварст: " + Age;
        }
    }
}
