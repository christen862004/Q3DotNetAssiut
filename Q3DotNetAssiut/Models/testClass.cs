namespace Q3DotNetAssiut.Models
{
    public class testClass
    {
        public void MEthod1()
        {
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

        public int Add(int x,int y)
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
