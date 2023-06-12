using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_OOP
{
    public class Character//может быть использован в той сборке, в которой объявлен.
                          //чтобы использовать из внешней можно изменить доступ на public
    {
        //public. Позволяет использовать метод класса вне класса.
        //Получить доступ можно в той же сборке или из внешней.
        //internal. Только внутри той же сборки
        //protected. не доступен в своей сборке и из вне. Доступ лишь внутри класса. Но будет доступен 
        //в классе наследнике. Типо, можно копировать
        private int health = 100;//Публичный тип позволяет менять переменные на прямую.
        //Приватный же позволяет менять тип только внутри класса. Т.е. если есть необходимость оградиться
        //от ошибочного изменения значения, можно оставить класс публичным, а переменные внутри класса приватными

        public int Health { get; private set; } = 100;

        //public int Health//если вневний код пытается забрать свойство
        //{
        //    get//чтение
        //    {
        //        return health;
        //    }
        //    private set//запись
        //    {
        //        health = value;//невидимый аргумент
        //    }
        //}
        //public int GetHealth()
        //{
        //    return health;
        //}
        //public void SetHealth(int value)
        //{
        //    health = value;
        //}
        public void Hit(int damage)
        {
            
            if(damage>health)
            {
                damage = health;
            }
            health -= damage;
           // Health -= damage;
        }
    }
}
