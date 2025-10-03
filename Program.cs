 using System;

class Program
{
    // اسم غذاها
    static string[,,] meals = new string[3, 3, 3]
    {
        {   // رژیم کم کالری
            { "سالاد سبزیجات", "سوپ سبزیجات", "تخم مرغ آب‌پز" },   // صبحانه
            { "ماهی بخارپز", "خوراک عدس", "مرغ کبابی" },            // ناهار
            { "سالاد کینوا", "سوپ کرفس", "خوراک لوبیا" }            // شام
        },
        {   // رژیم پر پروتئین
            { "املت تخم مرغ", "شیر و جو دوسر", "تست مرغ و پنیر" }, // صبحانه
            { "استیک گوشت", "خوراک مرغ", "سالاد تن ماهی" },         // ناهار
            { "ماهی و برنج", "خوراک بوقلمون", "سوپ مرغ" }            // شام
        },
        {   // رژیم گیاه خواری
            { "نان و پنیر", "فرنی", "صبحانه میوه‌ای" },             // صبحانه
            { "خوراک لوبیا سبز", "عدس پلو", "سالاد نخود" },          // ناهار
            { "خوراک سبزیجات", "سالاد فصل", "سوپ عدس" }             // شام
        }
    };

    // مواد اولیه هر غذا
    static string[,] ingredients = new string[9, 4]
    {
        { "سالاد سبزیجات", "کاهو:1:5", "خیار:2:3", "گوجه:1:4" },
        { "سوپ سبزیجات", "هویج:1:4", "کرفس:1:6", "سیب زمینی:1:5" },
        { "تخم مرغ آب‌پز", "تخم مرغ:2:5", "نمک:1:1", "نان:1:2" },
        { "املت تخم مرغ", "تخم مرغ:3:5", "گوجه:1:4", "روغن:1:2" },
        { "شیر و جو دوسر", "شیر:1:10", "جو دوسر:1:15", "عسل:1:8" },
        { "تست مرغ و پنیر", "نان:2:2", "مرغ:1:20", "پنیر:1:8" },
        { "خوراک لوبیا سبز", "لوبیا سبز:1:12", "گوجه:2:4", "پیاز:1:3" },
        { "عدس پلو", "عدس:1:10", "برنج:1:20", "پیاز:1:3" },
        { "سالاد نخود", "نخود:1:15", "خیار:1:3", "گوجه:1:4" }
    };

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // مرحله 1: انتخاب رژیم
        Console.WriteLine("یک رژیم انتخاب کنید:");
        Console.WriteLine("1- کم کالری");
        Console.WriteLine("2- پر پروتئین");
        Console.WriteLine("3- گیاه خواری");
        int dietChoice = int.Parse(Console.ReadLine()) - 1;

        // مرحله 2: انتخاب روز
        string[] days = { "شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
        Console.WriteLine("\nروز مورد نظر را انتخاب کنید:");
        for (int i = 0; i < days.Length; i++)
            Console.WriteLine($"{i + 1}- {days[i]}");
        int dayChoice = int.Parse(Console.ReadLine());

        // مرحله 3: انتخاب وعده
        Console.WriteLine("\nکدام وعده را می‌خواهید انتخاب کنید؟");
        Console.WriteLine("1- صبحانه");
        Console.WriteLine("2- ناهار");
        Console.WriteLine("3- شام");
        int mealType = int.Parse(Console.ReadLine()) - 1;

        // مرحله 4: نمایش پیشنهاد غذا
        Console.WriteLine($"\nبرای {days[dayChoice - 1]} ({GetMealName(mealType)}) پیشنهادها:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{i + 1}- {meals[dietChoice, mealType, i]}");
        }

        Console.Write("\nغذا را انتخاب کنید: ");
        int foodChoice = int.Parse(Console.ReadLine()) - 1;

        string selectedMeal = meals[dietChoice, mealType, foodChoice];
        Console.WriteLine($"\n شما انتخاب کردید: {selectedMeal}");

        // مرحله 5: نمایش مواد اولیه و هزینه
        ShowIngredients(selectedMeal);

        Console.WriteLine("\n--- پایان برنامه ---");
    }

    // گرفتن نام وعده
    static string GetMealName(int mealType)
    {
        if (mealType == 0) return "صبحانه";
        if (mealType == 1) return "ناهار";
        return "شام";
    }

    // نمایش مواد اولیه یک غذا
    static void ShowIngredients(string mealName)
    {
        double total = 0;
        for (int i = 0; i < ingredients.GetLength(0); i++)
        {
            if (ingredients[i, 0] == mealName)
            {
                Console.WriteLine("\nمواد اولیه لازم:");
                for (int j = 1; j < ingredients.GetLength(1); j++)
                {
                    if (ingredients[i, j] == null) continue;
                    string[] parts = ingredients[i, j].Split(':'); // نام:مقدار:قیمت
                    string name = parts[0];
                    int qty = int.Parse(parts[1]);
                    int price = int.Parse(parts[2]);
                    int cost = qty * price;
                    Console.WriteLine($"- {name} ×{qty} (قیمت واحد {price}) = {cost} تومان");
                    total += cost;
                }
                break;
            }
        }
        Console.WriteLine($" هزینه کل: {total} تومان");
    }
}
