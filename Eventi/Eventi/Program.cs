using Eventi.Models;

namespace Eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ris;

            //Partecipante Par1 = new Partecipante()
            //{
            //    Nome = "Luca",
            //    Contatto = "Luca@lu.it"
            //};

            //Evento ev = new Evento()
            //{
            //    Nome = "Osvaldo",
            //    Descrizione = "Bevilacqua",
            //    Data = new DateTime(2024, 05, 4),
            //    Luogo = "Roma villa ada",
            //    CapacitaMassima = 100
            //};

            string risposta;
            bool insabi = true;

            do
            {

                bool bo = true;
                Console.WriteLine($"inserire 1 aggiungere partecipanti\n 2 per aggiungere eventi\n 3 per cercare\n 4 per aggiornare\n 5 per eliminare\n Q per uscire");
                 risposta = Console.ReadLine();


                while (insabi)
                {

                 

                    {
                        switch (risposta)
                        {
                            case "1":
                                using (var ctx = new TaskEventoContext())
                                {



                                    Console.WriteLine("inserisci Nome");
                                    string? nome = Console.ReadLine();
                                    Console.WriteLine("inserisci Contatto");
                                    string? contatto = Console.ReadLine();


                                    Partecipante par = new Partecipante()
                                    {
                                        Nome = nome,
                                        Contatto = contatto,
                                    };
                                    try
                                    {

                                        ctx.Partecipantes.Add(par);
                                      
                                        ctx.SaveChanges();
                                        Console.WriteLine("Partecipante aggiunto con successo");

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }

                             

                             bo= false;
                                break;
//------------------------------------------------------------------------------------------
                            case "2":
                                using (var ctx = new TaskEventoContext())
                                {



                                    Console.WriteLine("inserisci nome");
                                    string? nome = Console.ReadLine();
                                    Console.WriteLine("inserisci descrizione");
                                    string? descrizione = Console.ReadLine();
                                    Console.WriteLine("inserisci data");
                                    DateTime? data = Convert.ToDateTime(Console.ReadLine());
                                    Console.WriteLine("inserisci luogo");
                                    string? luogo = Console.ReadLine();
                                    Console.WriteLine("inserisci capacitaMassima");
                                    int capacitaMassima =Convert.ToInt32(Console.ReadLine());


                                    Evento Ev = new Evento()
                                    {
                                        Nome = nome,
                                        Descrizione = descrizione,
                                        Data = (DateTime)data,
                                        Luogo = luogo,
                                        CapacitaMassima = capacitaMassima
                                    };


                                    try
                                    {

                                        ctx.Eventos.Add(Ev);

                                        ctx.SaveChanges();
                                        Console.WriteLine("evento aggiunto con successo");

                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }




                                bo = false;
                                break;
                            //---------------------------------------------
                            case "3":
                                using (var ctx = new TaskEventoContext())
                                {
                                    Console.WriteLine("inserisci contatto da cercare");
                                    string? Ricerca = Console.ReadLine();


                                    List<Partecipante> par=ctx.Partecipantes.Where(c=>c.Contatto.StartsWith(Ricerca)).ToList();

                                    foreach(Partecipante item in par)
                                    {
                                        Console.WriteLine(item);
                                    }

                                }
                                bo = false;
                                break;

                            case "Q":
                                insabi = false;
                                ris = "";
                                break;


                        }
                    }
                }

            } while (risposta != "");
            

           

        }
    }
}
