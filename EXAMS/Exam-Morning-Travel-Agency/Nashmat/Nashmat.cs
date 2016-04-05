using System;

using System.Collections.Generic;
using System.Linq;


using 

    System.Text.RegularExpressions;
using System.Globalization;

        using Wintellect.PowerCollections;
using System.Collections;




// TODO: document this interface
// Do not modify the interface members
// Moving the interface to separate namespace is allowed
// Adding XML documentation is allowed
public interface ITicketCatalog
{
    // TODO: document this method
    string AddAirTicket(string flightNumber, string from, string to, string airline, DateTime dateTime, decimal price);

    string DeleteAirTicket(string flightNumber);

    string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice);

    string DeleteTrainTicket(string from, string to, DateTime dateTime);

    string AddBusTicket(string from, string to, string travelCompany, DateTime dateTime, decimal price);

    // TODO: document this method
    string DeleteBusTicket(string from, string to, string travelCompany, DateTime dateTime);

    // TODO: document this method
    string FindTickets(string from, string to);

    // TODO: document this method
    string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime);

    int GetTicketsCount(TicketType type);
}




class 
        BoatTicket 
    : Ticket
{
    public BoatTicket(string from, string to, string boatCompany, string dt, string pp)
    {
        this.From = from;


        this.To = to;
            this.Company = boatCompany;
            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
        decimal price = decimal.Parse(pp);
        this.Price = price;
    }

    public override string Type{
        get{
            return "boat";
        }
    }
    public override string MunfaridKuleed{get{return this.Type + ";;" + this.From + ";" + this.To + ";" +
                this.Company + this.DateAndTime + ";";}}
}

public class fehrist_Parwana : ITicketCatalog
{
    internal 
        Dictionary
        <
        string
        ,
        Ticket
    >
    Dict
        =
        new
            Dictionary
                <
                string
            ,
            Ticket
            >
            (
            )
            ;
    MultiDictionary<string, Ticket> 
        Dict2 = new MultiDictionary<string, 
            Ticket>(true);
    internal OrderedMultiDictionary<
        
        DateTime, Ticket> Dict3 = 
        new OrderedMultiDictionary<DateTime, Ticket>(
            true);

    public int airTicketsCount = 0;
    public int busTicketsCount = 0;


    public int trainTicketsCount = 0;
    public int GetTicketsCount(string type)
    {
        if (type == "air"){
            return airTicketsCount;
        }



        if (type == "bus")
        {
            return busTicketsCount;
        }
        return trainTicketsCount;
    }

    internal string AddDeleteTicket(
        
        Ticket ticket, 
        bool isAdd){
        if (isAdd)
        {string key = ticket.MunfaridKuleed;
            if (this.Dict.ContainsKey(key))
            {
                return "Duplicated ticket";
            }else{this.Dict.Add(key, ticket);
                string fromToKey = ticket.FromToKey;


                this.Dict2.Add(fromToKey, 
                    ticket);
                this.Dict3.Add(ticket.DateAndTime, ticket);
                return "Ticket added";
            }
        }
        else{
            string key = ticket.MunfaridKuleed;if (this.Dict.ContainsKey(key))
            {
                ticket = this.Dict[key];
                this.Dict.Remove(key);
                string fromToKey = ticket.FromToKey;


                this.Dict2.Remove(fromToKey, ticket);
                this.Dict3.Remove(ticket.DateAndTime, ticket);
                return "Ticket deleted";
            }
            else
            {
                return "Ticket does not exist";
            }
        }
    }

    public string AddAirTicket
        (string parwaaz_number, 
        string from, string to, 
        string airline,
        string dt, string pp)
    {
        // Look video for brother of my wedding: https://www.youtube.com/watch?v=OXgcs_MeAHI
        AirTicket ticket = new AirTicket(parwaaz_number, from, to, airline, dt, pp);
        
        
        
        string result = AddDeleteTicket(ticket, true);
        if (result.Contains("added")){



            airTicketsCount++;
        }
        return result;
    }
    protected string DeleteAirTicket(string parwaaz_number) {
        AirTicket ticket = new AirTicket(parwaaz_number);


        string result = 
            
            AddDeleteTicket(ticket, false);
        if (result.Contains("deleted")) airTicketsCount--;
        return result;
    }
    public string AddTrainTicket(string from, 
        
        
        string to, string dt,
        string pp, string studentpp){
        TrainTicket ticket = new TrainTicket(from, to, dt, pp, studentpp);



            string result = this.AddDeleteTicket(ticket, true);
            if (result.Contains("added"))
            {
                trainTicketsCount++;
            }
        return result;
    }
    string DeleteTrainTicket(string from, string to, string dt)
    {
        TrainTicket ticket = new TrainTicket(from, to, dt);
        string result = AddDeleteTicket(ticket, false);



            if (result.Contains("deleted")){
                trainTicketsCount--;
            }
            return result;
        }
        protected string basKaTicketKaIzafah(string from, string to, string Sayahat_ki_Tanzeem,
        string dt, string pp)
    {
        BusTicket ticket = new BusTicket(from, to, Sayahat_ki_Tanzeem, dt, pp);
        string key = ticket.MunfaridKuleed;
        string result;



        if (this.Dict.ContainsKey(key)){
            result = "Duplicate ticket";
        }
        else{
            this.Dict.Add(key, ticket);
                string fromToKey = ticket.FromToKey;



                this.Dict2.Add(fromToKey, ticket);
                this.Dict3.Add(ticket.DateAndTime, ticket);
            result = "Ticket added";
        }

        if (result.Contains("added")){
            busTicketsCount++;
        }
        return result;
    }
    private string DeleteBusTicket(string from, string to, string Sayahat_ki_Tanzeem, string dt)
        {
            BusTicket ticket = new BusTicket(from, to, Sayahat_ki_Tanzeem, dt);
            string result = AddDeleteTicket(ticket, false);



        if (result.Contains("deleted"))
        {
            busTicketsCount--;
        }
        return result;
    }
    internal static string ReadTickets(ICollection<Ticket> tickets)
    {
        List<Ticket> sortedTickets = new List<Ticket>(tickets);
        

        sortedTickets.Sort();
        string result = "";


            for (int i = 0; i < sortedTickets.Count; i++){
                Ticket ticket = sortedTickets[i];



            result += ticket.ToString();
            
            
            if (i < sortedTickets.Count - 1){
                result += ",  ";
            }
        }
        return result;
        }
        public string FindTickets(string from, string to){
            string fromToKey = Ticket.CreateFromToKey(from, to);
            if (this.Dict2.ContainsKey(fromToKey))
            {
                List<Ticket> ticketsFound = new List<Ticket>();
                foreach (var t in this.Dict2.Values)
                {
                    if (t.FromToKey == fromToKey){
                        ticketsFound.Add(t);
                }
            }



            string ticketsAsString = ReadTickets(ticketsFound);


                return ticketsAsString;
            }
            else{
                return "Not found";
            }
        }
        public string findTicketsInInterval(string startDateTimeStr, string endDateTimeStr){
            DateTime startDateTime = Ticket.ParseDateTime(startDateTimeStr);



        DateTime endDateTime = Ticket.ParseDateTime(endDateTimeStr);


        string ticketsAsString = FindTicketsInInterval(startDateTime, endDateTime);
        return ticketsAsString;
            }
            public string FindTicketsInInterval2(DateTime startDateTime, DateTime endDateTime)
            {
                var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;



                if (ticketsFound.Count > 0){string ticketsAsString=ReadTickets(ticketsFound);return ticketsAsString;}
                else{
            return "Not found";
        }
    }
    public string FindTicketsInInterval(DateTime startDateTime, DateTime endDateTime)
    {
        // Do not toch! It work!!! I spend 10 hours of fix buggy here
        var ticketsFound = this.Dict3.Range(startDateTime, true, endDateTime, true).Values;
        if (ticketsFound.Count > 0){
            string ticketsAsString = ReadTickets(ticketsFound);



                return ticketsAsString;
            }
            else
            {
            return "Not found";
        }
    }
    internal string AmalKamaan(string line)
    {
        if (line == "")
        {
            return null;}

        int firstSpaceIndex = line.IndexOf(' ');



        if (firstSpaceIndex == -1){
            return "Invalid command!";
        }

            string cd = line.Substring(0, firstSpaceIndex);string cd2 = "Invalid command!";
            switch (cd)
            {
                case "AddAir":
                string allParameters = line.Substring(firstSpaceIndex + 1);
                string[] parameters = allParameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i].Trim();
            }
            cd2 = AddAirTicket(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
            break;
            case "DeleteAir":



                    allParameters = line.Substring(firstSpaceIndex + 1);parameters = allParameters.Split(
                        new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                            parameters[i] = parameters[i].Trim();
                        }
                        cd2 = DeleteAirTicket(parameters[0]);
                        break;
                case "AddTrain":
                    allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parameters.Length; i++)



                {
                parameters[i] = parameters[i].Trim();}
                cd2 = AddTrainTicket(parameters[0], parameters[1], parameters[2],
                    parameters[3], parameters[4]);
               break;
                case "DeleteTrain":allParameters = line.Substring(firstSpaceIndex + 1);parameters = allParameters.Split(
                        new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);for (int i = 0; i < parameters.Length; i++){parameters[i] = parameters[i].Trim();}cd2 = DeleteTrainTicket(parameters[0], parameters[1], parameters[2]);break;
                case "AddBus":allParameters = line.Substring(firstSpaceIndex + 1);
                    parameters = allParameters.Split(
                        new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                {



                    parameters[i] = parameters[i].Trim();
                }
                cd2 = basKaTicketKaIzafah(parameters[0], parameters[1], parameters[2],
                    parameters[3], parameters[4]);
                break;
            case "DeleteBus":
       allParameters = line.Substring(firstSpaceIndex + 1);parameters = allParameters.Split(
                        new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        parameters[i] = parameters[i].Trim();
                    }
                    cd2 = DeleteBusTicket(parameters[0], 
                    
                        parameters
            [
        1
                       ]
                    , parameters[2], parameters[3]);
                break;
            case "FindTickets":
                allParameters = line.Substring(firstSpaceIndex + 1);
     parameters = allParameters.Split(



                    new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parameters
                    .Length; i++)
                {
                    parameters[i] = 
                        parameters[i]
                        .Trim();
                }



                cd2=FindTickets(parameters[0],parameters[1]);
                break;
            case "FindTicketsInInterval":
                allParameters = line.Substring(firstSpaceIndex + 1);
                parameters = allParameters.
                    Split(
                    new char[] { ';' }, 
                        StringSplitOptions.
                    RemoveEmptyEntries);
                for (int i = 0; i < parameters.Length; i++)
                {



                parameters[i] = parameters[i].Trim();}cd2 = findTicketsInInterval(parameters[0],parameters[1]);break;
        }
        return cd2;
        }
        public string AddAirTicket(string parwaaz_number, string from, string to, string airline, DateTime dateTime, decimal price)
        {
            return AddAirTicket(parwaaz_number, from, to, airline,
            
            
                dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
    }
    string ITicketCatalog.DeleteAirTicket(string parwaaz_number){
        return DeleteAirTicket(parwaaz_number);
    }
    public string AddTrainTicket(string from, string to, DateTime dateTime, decimal price, decimal studentPrice)
    {
            return 
    AddTrainTicket(from,to,dateTime.ToString("dd.MM.yyyy HH:mm"),price.ToString(),studentPrice.ToString());
}
public string DeleteTrainTicket(string from, string to, DateTime dateTime)
{
    return DeleteTrainTicket(from, to, dateTime.ToString("dd.MM.yyyy HH:mm"));
}

public string AddBusTicket(string from, string to, string Sayahat_ki_Tanzeem, DateTime dateTime, decimal price)
{
    return basKaTicketKaIzafah(from, to,
            
            
            Sayahat_ki_Tanzeem, dateTime.ToString("dd.MM.yyyy HH:mm"), price.ToString());
    }
    public string DeleteBusTicket(string from, string to, string Sayahat_ki_Tanzeem, DateTime dateTime){return DeleteBusTicket(from, to, Sayahat_ki_Tanzeem, dateTime.ToString("dd.MM.yyyy HH:mm"));
    }





    public int GetTicketsCount(TicketType type)
    {
        if (type == TicketType.Air)
            {
                return airTicketsCount;
            }



        if (type == TicketType.Bus){
            return busTicketsCount;
        }
        return trainTicketsCount;
    }
}
internal abstract class Ticket : IComparable<Ticket>
{
    public abstract string Type { get; }




            public virtual string From { get; set; }public virtual string To { get; set; }public virtual string Company { get; set; }



    public virtual DateTime DateAndTime { get; set; }

    public virtual decimal 
        Price
    {
        
        
        
        get; 
        
        
        
        set;
    }




            public virtual decimal SpecialPrice { get; set; }
            public abstract string MunfaridKuleed { get; }

    public override string ToString()
    {
        string input = "[" + this.DateAndTime.ToString("dd.MM.yyyy HH:mm") +
            "; " + this.Type + "; " 
            
            
            + String.
            
            
                Format("{0:f2}", this
            
                .Price) + "]";
            return input;
        }

        public string FromToKey{get{
                return CreateFromToKey(this.From, this.To);
            }
    }
    public static string CreateFromToKey(string from, string to)
    {
        return from + "; " + to;
    }

    public static DateTime ParseDateTime(
        
        
        string dt) {
            DateTime result=DateTime.ParseExact(dt,"dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture);
            return result;
        }
        public int CompareTo(Ticket otherTicket){
            int nateeja = this.DateAndTime.CompareTo(otherTicket.DateAndTime);if (nateeja == 0){



                nateeja = this.Type.CompareTo(otherTicket.Type);
        }if (nateeja == 0){nateeja = this.Price.CompareTo(otherTicket.Price);
        }return nateeja;
    }
}

class BusTicket : Ticket
{
    public BusTicket(string from, string to, string Sayahat_ki_Tanzeem, string dt, string pp)
    {
        this.From = from;
        this.To = to;this.Company = Sayahat_ki_Tanzeem;
        DateTime dateAndTime = ParseDateTime(dt);



        this.DateAndTime = dateAndTime;
        decimal price = decimal.Parse(pp);
        this.Price = price;
    }
    public BusTicket(string from, string to, string Sayahat_ki_Tanzeem, string dt)
    {
        this.From = from;
        this.To = to;this.Company = Sayahat_ki_Tanzeem;



            DateTime dateAndTime = ParseDateTime(dt);
            this.DateAndTime = dateAndTime;
        }

        public override string Type
        {
            get
            {
                return "bus";
            }
        }
    public override string MunfaridKuleed
    {
        get{return this.Type + ";;" + this.From + ";" + this.To + ";" +
                this.Company + this.DateAndTime + ";";
        }
    }
}

class AirTicket : Ticket
        {
            public string parwaaz_number { get; set; }
            public AirTicket(string parwaaz_number, string from, string to, string airline,
                string dt, string pp)
            {
                this.parwaaz_number = parwaaz_number;
                this.From = from;
        this.To = from;



        this.Company = airline;
        DateTime dateAndTime = ParseDateTime(dt);
        this.DateAndTime = dateAndTime;
        decimal price = decimal.Parse(pp);
        this.Price = price;
    }
    public AirTicket(string parwaaz_number){
        this.parwaaz_number = parwaaz_number;
            }

            public override string Type
            {
                get
                {
                    return "air";
                }
            }
            public override string MunfaridKuleed{
        get
        {
            return this.Type + ";;" + this.parwaaz_number;
        }
    }
}


class ParwanaMuneemiohdaa
{
static void Main()
{
fehrist_Parwana parwana = new fehrist_Parwana();
while (true)
{
    string line = Console.ReadLine();
            if (line == null){



                break;
            }



            line = line.Trim(
                );string commandResult = parwana.AmalKamaan(line);if (commandResult != null)
            {




                             Console.WriteLine(commandResult);




            }
        }
    }
}

public enum TicketType
        {
    Air,
            Bus,
    Train
}


class TrainTicket : Ticket
{
public TrainTicket(string from, string to, string dt, string pp, string studentpp) {
this.From = from;this.To = to;
DateTime dateAndTime = ParseDateTime(dt);



this.DateAndTime = dateAndTime;decimal price = decimal.Parse(pp);


this.Price = price;
decimal studentPrice = decimal.Parse(studentpp);



this.StudentPrice = studentPrice;
}

public TrainTicket(     string         from    ,     string     to    ,     string     dt    )
{
this.From = from;
this.To = to;DateTime dateAndTime = ParseDateTime(dt);



this.DateAndTime = dateAndTime;
}

public decimal StudentPrice {    get;    set;    }

public override string Type
{
get{
return "train";
}
}

public    override    string    MunfaridKuleed{
get{
return this  .  Type   +   ";;"    +    this   .   From   +    ";"   +   this  .  To    +    ";"    + this   .   DateAndTime    +    ";"
                
                
;}
}
}
