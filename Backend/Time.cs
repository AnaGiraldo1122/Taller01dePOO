using System.Security;

namespace Backend;

public class Time
{

    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;


    //constructors
    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millesecond = 0;
    }
    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millesecond = 0;
    }
       public Time (int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millesecond = 0;
    }
       public Time (int hour,  int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millesecond = 0;
    }   
          public Time (int hour, int minute, int second, int millesecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millesecond = millesecond;

    }

    //properties
    public int Hour
    {
        get => _hour;
        set => _hour = ValidateHour (value);
    }
    public int Minute
    {
        get => _minute;
        set => _minute = ValidateMinute(value);
    }
    public int Second
    {
        get => _second;
        set => _second = ValidateSecond(value);
    }
    public int Millesecond
    {
        get => _millisecond;
        set => _millisecond = ValidateMillesecond(value);
    }


    //public methods
    public override string ToString()
    {
        string tt = Hour < 12 ? "AM" : "PM";

        int hour12 = Hour;

        if (Hour > 12)
        {
            hour12 = Hour - 12;
        }

        return $"{hour12:00}:{Minute:00}:{Second:00}.{Millesecond:000} {tt}";
    }

    public long ToMilliseconds()
    {
        return (Hour * 60 * 60 * 1000) +
               (Minute * 60 * 1000) +
               (Second * 1000) +
               Millesecond;
    }

    public long ToSeconds()
    {
        return (Hour * 60 * 60) +
               (Minute * 60) +
               Second;
    }
    public long ToMinutes()
    {
        return (Hour * 60) + Minute;
    }
    public bool IsOtherDay(Time other)
    {
        return Hour + other.Hour > 23;
    }

    public Time Add(Time other)
    {
        int millisecond = Millesecond + other.Millesecond;
        int second = Second + other.Second;
        int minute = Minute + other.Minute;
        int hour = Hour + other.Hour;

        if (millisecond > 999)
        {
            millisecond -= 1000;
            second++;
        }

        if (second > 59)
        {
            second -= 60;
            minute++;
        }

        if (minute > 59)
        {
            minute -= 60;
            hour++;
        }

        if (hour > 23)
        {
            hour -= 24;
        }

        return new Time(hour, minute, second, millisecond);
    }

    // Private methods
    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour ({hour}) is not valited");
        }
            return hour;
        
        }
    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute ({minute}) is not valited");
        }
        return minute;
           }
    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second ({second}) is not valid");
        }

        return second;
    }
    private int ValidateMillesecond(int millesecond)
    {
        if (millesecond < 0 || millesecond > 999)
        {
            throw new Exception($"The millesecond ({millesecond}) is not valited");
        }
        return millesecond;
    }
    
    
    

}




