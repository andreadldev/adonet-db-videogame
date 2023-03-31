using adonet_db_videogame;
using System.Data.SqlClient;

var gamemanager = new VideogameManager();

//public void AddGame(string name, string overview, DateTime release_date, int software_house_id)

Console.WriteLine("1. Inserisci");
Console.WriteLine("2. Ricerca");
//Console.WriteLine("3. Filtra");
//Console.WriteLine("4. Elimina");
//Console.WriteLine("5. Chiudi");

while (true)
{
    int opzione = 0;
    
    while (opzione is 0)
    {
        var input = Console.ReadLine();
        opzione = Menu(input);
    }

    switch (opzione)
    {
        case 1:
            Console.WriteLine("Nome:");
            var name = Console.ReadLine();

            Console.WriteLine("Overview:");
            var overview = Console.ReadLine();

            Console.WriteLine("Release date (yyyy-MM-dd):");
            var releaseDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Software house id:");
            var softwareHouseId = Convert.ToInt64(Console.ReadLine());

            var game = new Videogame(0, name, overview, releaseDate, softwareHouseId);
            gamemanager.AddGame(game);
            Console.WriteLine("Videogioco inserito");
            break;
        case 2:
            Console.WriteLine("Inserisci id gioco");
            var id = Convert.ToInt64(Console.ReadLine());
            gamemanager.SearchById(id);
            break;
        //case 3:
        //    break;
        //case 4:
        //    break;
        //case 5:
        //    break;
    }
}

int Menu(string? input)
{
    switch (input)
    {
        case "1":
        case "inserisci":
            return 1;
        case "2":
        case "ricerca":
            return 2;
        //case "3":
        //case "filtra":
        //    return 3;
        //case "4":
        //case "elimina":
        //    return 4;
        //case "5":
        //case "chiudi":
        //    return 5;
        default:
            Console.WriteLine("Input non valido");
            return 0;
    }
}

