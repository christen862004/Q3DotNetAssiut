namespace Q3DotNetAssiut.Models
{
    public class testClass
    {
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
