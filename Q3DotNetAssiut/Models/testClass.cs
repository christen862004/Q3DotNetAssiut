namespace Q3DotNetAssiut.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }

    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //arr sort using bubble sort
        }
    }
    class SelectionSort:ISort
    {
        public void Sort(int[] arr)
        {
            //arr sort using selection sort
        }
    }

    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {
            //throw new NotImplementedException();
        }
    }
    //------------------------
    class Stack//High level class
    {
        int[] arr;
        ISort SortObj; //Low Level Class
        public Stack(ISort _sortObj)
        {
            SortObj = _sortObj;// new BubbleSort();
        }
        void SortStack()//ISort _sort)
        {
            SortObj.Sort(arr);
        }
    }


    public class testClass
    {
        public void MEthod1()
        {

            Stack s1 = new Stack(new BubbleSort());
            Stack s2= new Stack(new SelectionSort());
            Stack s3 = new Stack(new ChrisSort());





            Console.WriteLine( "1");
            MEthod2();
            Console.WriteLine("3");
        }
        public void MEthod2()
        {
            Console.WriteLine( "2");
        }


        int viewData;
        public int ViewData
        {
            set { viewData = value;}
            get { return viewData; }
        }

        public dynamic ViewBag
        {
            set { ViewData = value; }
            get { return ViewData; }
        }

        public int Add(int x,int y=10) 
        {
            dynamic xx = 5;
            dynamic yy = "ahmed";
            dynamic obj = new Student();
            yy = xx + obj;
            return x + y;
        }

        public void display()
        {
            int a = 10;
            int b = 20;
            Add(a,b);
        }
    }
}
