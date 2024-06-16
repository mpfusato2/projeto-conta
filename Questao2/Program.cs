using Newtonsoft.Json;
using Questao2.Modelos;
using System.Net;
using System.Text;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {        
        return RetornaTotalGoals(team, year);
    }

    public static int RetornaTotalGoals(string team, int year)
    {
        var totalGols = 0;

        using (var http = new HttpClient())
        {
            var url = new Uri(RetornaUrl(team, year));
            var result = http.GetAsync(url).GetAwaiter().GetResult();
            var resultContent = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                return 0;
            }
            var teamsGoals = JsonConvert.DeserializeObject<TeamsGoal>(resultContent);

            
            foreach (var item in teamsGoals.Data)
            {
                if (item.Team1.Contains(team))
                {
                    totalGols += int.Parse(item.Team1Goals);                    
                }

                if (item.Team2.Contains(team))
                {
                    totalGols += int.Parse(item.Team1Goals);                    
                }
            }
        }

        return totalGols;
    }

    private static string RetornaUrl(string team, int year)
    {
        StringBuilder path = new StringBuilder();
        path.Append("https://jsonmock.hackerrank.com/api/football_matches?year=");
        path.Append(year);
        path.Append("&team1=");
        path.Append(team);

        return path.ToString();
    }      
}