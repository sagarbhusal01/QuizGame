# QuizGame

It is a simple fun console game made in C# as a school project 
It uses Trivia Api to ask question and user has to respond with the answer.
you donot have to worry about the case sensitivity

here a GET method is used to fetch the API data
```csharp
string URL = "https://the-trivia-api.com/api/questions?categories=science&limit=10&difficulty=medium&tags=computing";
        var client = new RestClient(URL);
        var request = new RestRequest();

        var response = client.Get(request);
        var RESPONSE = response.Content;
        List<APIRESPONSES> ALLRESPONSE = JsonConvert.DeserializeObject<List<APIRESPONSES>>(RESPONSE);
```

And here json data is converted into the c# class

```csharp

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

```


here the checkchoice method handles the input and prevent the console from crashing from the Unecpected input
```csharp
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


```

# Dependencies

In this project 
# RestSharp and  Newtonsoft.json 
packages were used .
you have to install those from the nuget packages
