using courseBeonMax2._6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courseBeonMax2._6
{
    public interface IBaseCollection_5_25
    {
        void Add(object obj);
        void Remove(object obj);
    }

    public static class BaseCollectionExtension
    {
        public static void AddRange(this IBaseCollection_5_25 collection, IEnumerable<object> objects)
        {
            foreach (var item in objects) 
            {
                collection.Add(item);
            }
        }

    }
}
public class BaseList : IBaseCollection_5_25
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