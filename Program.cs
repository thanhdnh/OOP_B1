using System;
using System.ComponentModel.Design;
public class Program
{
    /*
    Tên hàng	                Gạo	Ngô	Khoai
    Số lượng (tấn)	            100	90	20
    Đơn giá (nghìn đồng/1kg)	30	15	12
    */
    public static void Nhap(object[] x)
    {
        Console.Write("\tNhập tên hàng: ");
        x[0] = Console.ReadLine();
        Console.Write("\tNhập Số lượng: ");
        x[1] = int.Parse(Console.ReadLine());
        Console.Write("\tNhập Đơn giá: ");
        x[2] = float.Parse(Console.ReadLine());
    }
    public static void NhapS(object[][] xs)
    {
        for (int i = 0; i < xs.Length; i++)
        {
            Console.Write(">> Nhập mặt hàng thứ {0}\n", i);
            object[] x = new object[3];
            Nhap(x);
            xs[i] = x;
        }
    }
    public static int FindIndex(object[][] db, string name){
        for(int i=0; i<db.Length; i++)
            if(name.Equals((string)db[i][0]))
                return i;
        return -1;
    }
    public static void ThemHangVaoGio(object[][] cart,object[][] db)
    {
        bool cont = true;
        while (cont)
        {
            Console.Write("Ban muon mua hang gi? Gao/Ngo/Khoai");
            string pname = Console.ReadLine();
            int index = FindIndex(db, pname);
            int x = 0;
            switch(pname){
                case "Gao":
                    Console.WriteLine("Nhập số lượng Gạo:");
                    x = int.Parse(Console.ReadLine());
                    if(x <= (int)db[0][1])
                        cart[0][0] = x;
                    else
                        cart[0][0] = db[index][1];
                    cart[0][1] = db[index][2];
                    break;
                case "Ngo":
                    Console.WriteLine("Nhập số lượng Ngo:");
                    x = int.Parse(Console.ReadLine());
                    if(x <= (int)db[0][1])
                        cart[1][0] = x;
                    else
                        cart[1][0] = db[index][1];
                    cart[1][1] = db[index][2];
                    break;
                case "Khoai":
                    Console.WriteLine("Nhập số lượng Khoai:");
                    x = int.Parse(Console.ReadLine());
                    if(x <= (int)db[0][1])
                        cart[2][0] = x;
                    else
                        cart[2][0] = db[index][1];
                    cart[2][1] = db[index][2];
                    break;
                default:
                    break;
            }
            Console.Write("Bạn muốn mua hàng? Y/N");
            cont = (Console.ReadLine() == "Y") ? true : false;
        }
        Checkout(cart);
    }
    public static void Checkout(object[][] cart){
        float sum = 0;
        for(int i=0; i<cart.Length; i++)
            if((int)cart[i][0]!=0)
            sum += (int)cart[i][0] * (float)cart[i][1];
        string  format =  "==> Gio hang <==";
        string[] names = {"Gao", "Ngo", "Khoai"};
        for(int i=0; i<cart.Length; i++)
            if((int)cart[i][0]!=0)
                format += "\nHang ["+names[i]+"], \tSL: "+cart[i][0]+", \tDG: "+cart[i][1];
        Console.WriteLine(format);
        Console.WriteLine("---------");
        Console.WriteLine("Tong tien: " + sum);
    }
    public static void Main(string[] args)
    {
        Console.Clear();
        object[][] db = new object[3][];
        for (int i = 0; i < db.Length; i++)
            db[i] = new object[3];
        NhapS(db);
        object[][] cart = new object[3][];
        for (int i=0; i<cart.Length; i++)
            cart[i] = new object[2];
        for (int i=0; i<cart.Length; i++)
            for (int j=0; j<cart[i].Length; j++)
                cart[i][j] = 0;
        ThemHangVaoGio(cart, db);
        Console.ReadLine();
    }
}