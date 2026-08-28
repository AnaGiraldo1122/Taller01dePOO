using Backend;
try
{
    var Time1 = new Time();
    var Time2 = new Time(14);
    var Time3 = new Time(9, 34);
    var Time4 = new Time(19, 45, 56);
    var Time5 = new Time(23, 3, 45, 678);

    var times = new List<Time> { Time1, Time2, Time3, Time4, Time5 };

    foreach (Time time in times)
    {
        Console.WriteLine($"Time: {time}");
        Console.WriteLine($"\tMilleseconds:{time.ToMilliseconds(),15:N0}");
        Console.WriteLine($"\tSeconds     :{time.ToSeconds(),15:N0}");
        Console.WriteLine($"\tMinutes     :{time.ToMinutes(),15:N0}");
        Console.WriteLine($"\tAdd         :{time.Add(Time3)}");
        Console.WriteLine($"\tIs Other day:{time.IsOtherDay(Time4)}");
        Console.WriteLine();
    }
    var Time6 = new Time(45, -7, 90, -87);
}
catch (Exception ex)
{ 
   Console.WriteLine(ex.Message);
}