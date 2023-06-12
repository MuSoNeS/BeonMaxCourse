using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace courseBeonMax2._6
{
    public interface IBaseCollection//по соглашению имена интерфейс начинаются с заглавой 'I'
    {
        void Add(object obj);
        void Remove(object obj);
    }
    public class BaseList : IBaseCollection
    {
        private object[] items;
        private int counter = 0;
        public BaseList(int initialCapacity)
        {
            items = new object[initialCapacity];
            
        }
        public void Add(object obj)
        {
            items[counter] = obj;
            counter++;
            //throw new NotImplementedException(); Выбрасывается, когда запрошенный метод или операция не реализованы
        } 

        public void Remove(object obj)
        {
            items[counter] = null;
            counter--;
        }
    }
}
