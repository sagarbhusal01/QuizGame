//Quiz game



using System;
using RestSharp;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class utils
{
    public void Seperator()
    {
        Console.WriteLine
          ("---------------------------------------------------------------------------------------------------------------------");
    }
    public void Ender()
    {
        Console.WriteLine
          ("=====================================================================================================================");
    }
    public void log(string message)
    {
        Console.WriteLine(message);
    }


}
public class APIRESPONSES
{
    public string category { get; set; }
    public string id { get; set; }
    public string correctAnswer { get; set; }
    public List<string> incorrectAnswers { get; set; }
    public string question { get; set; }
    //public List<string> tags { get; set; }
    public string type { get; set; }
    public string difficulty { get; set; }
    public List<object> regions { get; set; }
    //public bool isNiche { get; set; }
}


public class Engine
{
    // 
    // 
    // 
    // 
    public string[] ques ={
    "How many time zones are there in Russia?",
    "What’s the national flower of Japan?",
    "How many stripes are there on the US flag? ",
    "What’s the national animal of Australia?",
    "How many days does it take for the Earth to orbit the Sun?",
    "Which of the following empires had no written language:",
    "Until 1923, what was the Turkish city of Istanbul called?",
    "National Income estimates in India are prepared by",
    "Fathometer is used to measure",
    "The purest form of iron is ",
    };
    // 
    // 
    //      "\n 1. \n 2. \n 3. \n 4. ",
    // 
    public string[] option ={
    "\n 1. 12 \n 2. 13 \n 3. 11  \n 4. 15",
    "\n 1.cherry \n 2.jasmine \n 3.hibiscus \n 4. cherry blossom",
    "\n 1. 12 \n 2. 13 \n 3. 11  \n 4. 15",
    "\n 1.kangaroo  \n 2.lion  \n 3.tiger  \n 4.red kangaroo ",
    "\n 1.345 \n 2.365 \n 3.375 \n 4.385 ",
    "\n 1.Incan \n 2.Aztec \n 3.Egyptian \n 4.Roman ",
    "\n 1.Istanbul \n 2.Constantinople \n 3.Turkey \n 4.Japan ",
    "\n 1.Planning Commission \n 2.Reserve Bank of India \n 3.Central statistical \n 4.Indian statistical Institute ",
    "\n 1.Earthquakes \n 2.Rainfall \n 3.Ocean depth \n 4.sound intensity ",
    "\n 1.wrought iron \n 2.steel \n 3.pig iron  \n 4.nickel steel ",
    };
    // 
    // 
    // 
    // 
    // 
    public int[] ans ={
    3,//ques 1 ans : 11
    4,//ques 2 ans : cherry blossom
    2,//ques 3 ans : 13
    4,//ques 4 ans : red kangaroo 
    2,//ques 5 ans : 365 
    1,//ques 6 ans :  Incan
    2,//ques 7 ans : Constantinople
    3,//ques 8 ans :  Central statistical
    3,//ques 9 ans : Ocean depth
    1,//ques 10 ans : wrought iron

    };





    // 
    // 
    // 
    //decelarations
    utils u = new utils();
    //
    //cache
    string temp;
    int temp0;
    //
    public struct variables
    {
        public int choice;
        public int score;
    }

    public variables v;
    public void checkChoice(string input)
    {
        try
        {
            temp0 = Convert.ToInt32(input);

            if (temp0 > 4 || temp0 == 0)
            {
                u.Seperator();
                Console.ForegroundColor = ConsoleColor.Red;
                u.log("your input is invalid");
                Console.ResetColor();
                u.Seperator();
            }
            else
            {
                v.choice = temp0;
            }

        }
        catch
        {
            u.Seperator();
            Console.ForegroundColor = ConsoleColor.Red;
            u.log("your input is invalid");
            Console.ResetColor();
            u.Seperator();

        }
    }

    public void ScoreCounter(int i)
    {
        if (ans[i] == v.choice)
        {
            v.score += 1;
            Console.ForegroundColor = ConsoleColor.Green;
            u.log("Correct answer ");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("correct answer is option: " + ans[i]);
            Console.ResetColor();
        }
    }


    public void MainEngineStart()

    {
        u.Seperator();
        u.log("game starts from here!  Best of Luck");
        v.score = 0;
        v.choice = 0;
        u.Seperator();
        u.log("Always remember to use number as a option if not you will lost your point!");
        u.Seperator();
        for (int i = 0; i < ques.Length; i++)
        {
            u.Seperator();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            u.log(ques[i]);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            u.log(option[i]);
            Console.ResetColor();
            u.Seperator();
            checkChoice(Console.ReadLine());
            ScoreCounter(i);
        }
    }

    public void QuizEngineStart()
    {
        u.Seperator();
        u.log("game starts from here!  Best of Luck");
        v.score = 0;
        u.Seperator();
        u.log("Always remember to use number as a option if not you will lost your point!");
        u.Seperator();
        string URL = "https://the-trivia-api.com/api/questions?categories=science&limit=10&difficulty=medium&tags=computing";
        var client = new RestClient(URL);
        var request = new RestRequest();

        var response = client.Get(request);
        var RESPONSE = response.Content;
        List<APIRESPONSES> ALLRESPONSE = JsonConvert.DeserializeObject<List<APIRESPONSES>>(RESPONSE);
        foreach (var item in ALLRESPONSE)
        {

            u.Seperator();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(item.question);
            Console.ResetColor();
            u.Seperator();
            string Answer = Console.ReadLine();
            if(Answer.ToLower()== item.correctAnswer.ToLower())
            {
                v.score += 1;
                u.Seperator();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Corerct Answer");
                Console.ResetColor();


            }
            else
            {
                u.Seperator();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Correct Answer is "+item.correctAnswer);
                Console.ResetColor();
            }
        }


    }


}
class MainContainer
{
    static void Main()
    {

        // some decelarations 
        utils u = new utils();
        int n = 0;
        Engine e = new Engine();
        //


        //welcome format 
        Console.ForegroundColor = ConsoleColor.Magenta;
        u.Ender();
        u.Ender();
        u.Ender();
        u.log("   ____        _        _____                      \r\n  / __ \\      (_)      / ____|                     \r\n | |  | |_   _ _ ____ | |  __  __ _ _ __ ___   ___ \r\n | |  | | | | | |_  / | | |_ |/ _` | '_ ` _ \\ / _ \\\r\n | |__| | |_| | |/ /  | |__| | (_| | | | | | |  __/\r\n  \\___\\_\\\\__,_|_/___|  \\_____|\\__,_|_| |_| |_|\\___|\r\n                                                   \r\n                                                   ");
        u.Seperator();
        u.Seperator();
        Console.ResetColor();
        //
        //start of program
        while (n < 1)
        {
            u.log("Here are your options:");
            Console.ForegroundColor = ConsoleColor.Green;
            u.log
              ("\n 1.MCQs \n 2.Quiz \n 3.See your score  \n 4.How to play ? \n 5.Quit ");
            Console.ResetColor();
            e.checkChoice(Console.ReadLine());
            switch (e.v.choice)
            {
                case 1:
                    e.MainEngineStart();
                    break;

                case 2:
                    e.QuizEngineStart();
                    break;

                case 3:
                    u.Seperator();
                    Console.WriteLine("your score is : " + e.v.score);
                    u.Seperator();
                    break;

                
                case 4:
                    u.Seperator();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    u.log("The game is very simple. you are asked with multiple choice questions \n and you have to chose the best answer after all the qustion \n is completed you can see your score  ");
                    Console.ResetColor();
                    u.Seperator();
                    break;

                case 5:
                    u.Seperator();
                    u.log("sorry to see you go !!!!");
                    n = 5;
                    u.Ender();
                    break;

                default:
                    u.Seperator();

                    u.Seperator();
                    break;

            }

        }
    }
}

