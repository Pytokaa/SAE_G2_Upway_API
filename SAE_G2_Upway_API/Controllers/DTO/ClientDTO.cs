using SAE_G2_Upway_API.Models;
using SAE_G2_Upway_API.Models.EntityFramework;

namespace SAE_G2_Upway_API.Controllers.DTO;

public class ClientDTO
{
    public string Nomclient { get; set; }
    public string Prenomclient { get; set; }
    public string Mailclient { get; set; }
    public string Telephone { get; set; }
    public string Password { get; set; }
    public string? UserRole { get; set; }
    
    public ClientDTO(Client client)
    {
        this.Nomclient = client.Nomclient;
        this.Prenomclient = client.Prenomclient;
        this.Mailclient = client.Mailclient;
        this.Telephone = client.Telephone;
        this.Password = client.Password;
        this.UserRole = client.UserRole;
    }
    public ClientDTO(string nomclient, string prenomclient, string mailclient, string telephone, string password)
    {
        Nomclient = nomclient;
        Prenomclient = prenomclient;
        Mailclient = mailclient;
        Telephone = telephone;
        Password = password;
        UserRole = "User";
    }

    public ClientDTO(){}
}