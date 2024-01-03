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
    public static int FindIndex(object[][] db, string name)
    {
        for (int i = 0; i < db.Length; i++)
            if (name.Equals((string)db[i][0]))
                return i;
        return -1;
    }
    public static void ThemHangVaoGio(object[][] cart, object[][] db)
    {
        bool cont = true;
        while (cont)
        {
            Console.Write("Ban muon mua hang gi\n?");
            for (int i = 0; i < db.Length; i++)
            {
                Console.WriteLine($"{i} - {db[i][0]}\n");
            }

            int index = int.Parse(Console.ReadLine());
            Console.WriteLine($"Nhập số lượng của {db[index][0]}:");
            int x = 0;
            x = int.Parse(Console.ReadLine());
            if (x <= (int)db[index][1])
                cart[index][0] = x;
            else
                cart[index][0] = db[index][1];
            cart[index][1] = db[index][2];



            Console.Write("Bạn muốn mua hàng? Y/N");
            cont = (Console.ReadLine() == "Y") ? true : false;
        }
        Checkout(cart, db);
    }
    public static void Checkout(object[][] cart, object[][] db)
    {
        float sum = 0;
        for (int i = 0; i < cart.Length; i++)
            if ((int)cart[i][0] != 0)
                sum += (int)cart[i][0] * (float)cart[i][1];
        string format = "==> Gio hang <==";

        for (int i = 0; i < cart.Length; i++)
            if ((int)cart[i][0] != 0)
                format += "\nHang [" + db[i][0] + "], \tSL: " + cart[i][0] + ", \tDG: " + cart[i][1];
        Console.WriteLine(format);
        Console.WriteLine("---------");
        Console.WriteLine("Tong tien: " + sum);
    }
    public static void Main(string[] args)
    {
        Console.Clear();
        int n = 5;

        object[][] db = new object[n][];
        for (int i = 0; i < db.Length; i++)
            db[i] = new object[3];
        NhapS(db);
        object[][] cart = new object[n][];
        for (int i = 0; i < cart.Length; i++)
            cart[i] = new object[2];
        for (int i = 0; i < cart.Length; i++)
            for (int j = 0; j < cart[i].Length; j++)
                cart[i][j] = 0;
        ThemHangVaoGio(cart, db);
        Console.ReadLine();
    }
}