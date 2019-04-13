using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO.Enumeration;

namespace ConsoleApp1
{
    class Warehouse
    {
        ArrayList arrayList  = new ArrayList();

        public void addToWareHouse(Item item)
        {
            arrayList.Add(item);
        }

        public void findItems(Item i)
        {
            foreach (var item in arrayList)
            {
                
                if (item.Equals(i))
                {
                    Console.WriteLine($"item fits your parameters {item.ToString()}");
                }
            }
        }

        public void sortPrice()
        {

            arrayList.Sort(new CompaperPrice());
        }

        public void showAll()
        {
            foreach (var item in arrayList)
            {
                Console.WriteLine(item.ToString());    
            }   
        }
        
    }

    class CompaperPrice : IComparer
    {
        public int Compare(Object p1, Object p2)
        {
            if (((Item)p1).price > (((Item)p2).price))
                return 1;
            else if (((Item)p1).price < (((Item)p2).price))
                return -1;
            else
                return 0;
        }
        
    }

    class Item 
    {
        
        public Item(string data, int price, int size)
        {
            this.data = data;
            this.price = price;
            this.size = size;
        }

        public String data { set; get; }

        

        public override string ToString()
        {
            return $"{nameof(data)}: {data}, {nameof(price)}: {price}, {nameof(size)}: {size}";
        }

        public int price {  set; get; }
        public int size { set; get; }
        
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            Item item = new Item("13.12", 34, 45);
            warehouse.addToWareHouse(item);
            warehouse.addToWareHouse(new Item("4334", 2,88));
            warehouse.addToWareHouse(new Item("56445", 69768, 89));
            warehouse.showAll();
            warehouse.sortPrice();
           
            warehouse.showAll();
            warehouse.findItems(item);
            
            int  n = 200000;
            int[] array = new int[n];
            ArrayList arr = new ArrayList();
            for(int i = 0; i < n; i++){
                array[i] = i;
            }
            array[1] = 0;

            for(int i = 0; i < n; i++){

                if(array[i] != 0){
                    for(int j = i + 1; j < n; j++){
                        if(array[j] % array[i] == 0){
                            array[j] = 0 ;
                        }
                    }
                    arr.Add(array[i]);

                }
            }
            int sum = 0;
            foreach (var o in arr)
            {
                sum += (int)o;
            }
    
            Console.WriteLine("sum = "+sum);
            Console.WriteLine(arr);





            
        }
    }
}