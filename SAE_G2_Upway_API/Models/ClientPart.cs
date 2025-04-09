using SAE_G2_Upway_API.Controllers.DTO;

namespace SAE_G2_Upway_API.Models.EntityFramework;

public partial class Client
{
    public override bool Equals(object? obj)
    {
    return obj is Client client &&
            Idclient == client.Idclient &&
            Nomclient == client.Nomclient &&
            Prenomclient == client.Prenomclient &&
            Mailclient == client.Mailclient &&
            Telephone == client.Telephone;
    }

    public override int GetHashCode()
    {
        HashCode hash = new HashCode();
        hash.Add(Idclient);
        hash.Add(Nomclient);
        hash.Add(Prenomclient);
        hash.Add(Mailclient);
        hash.Add(Telephone);
        hash.Add(Password);
        hash.Add(Alertes);
        hash.Add(Commandes);
        hash.Add(LesFavoris);
        hash.Add(HabiteA);
        return hash.ToHashCode();
    }

    public Client(int idclient, string nomclient, string prenomclient, string mailclient, 
                    string telephone, string password, ICollection<Alerte> alertes, 
                    ICollection<Commande> commandes, ICollection<Est_En_Favoris> lesFavoris, 
                    ICollection<Habite> habiteA)
    {
        Idclient = idclient;
        Nomclient = nomclient;
        Prenomclient = prenomclient;
        Mailclient = mailclient;
        Telephone = telephone;
        Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password,13);
        Alertes = alertes;
        Commandes = commandes;
        LesFavoris = lesFavoris;
        HabiteA = habiteA;
        UserRole = "User";
    }
    public Client(int idclient, string nomclient, string prenomclient, string mailclient,
                      string telephone, string password )
    {
        Idclient = idclient;
        Nomclient = nomclient;
        Prenomclient = prenomclient;
        Mailclient = mailclient;
        Telephone = telephone;
        Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        UserRole = "User";
    }
    public Client(ClientDTO clientDto)
    {
        Nomclient = clientDto.Nomclient;
        Prenomclient = clientDto.Prenomclient;
        Mailclient = clientDto.Mailclient;
        Telephone = clientDto.Telephone;
        Password = BCrypt.Net.BCrypt.EnhancedHashPassword(clientDto.Password,13);
        UserRole = clientDto.UserRole;
    }

    public Client() { }
}