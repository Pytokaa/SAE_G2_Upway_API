using SAE_G2_Upway_API.Models;
using SAE_G2_Upway_API.Models.EntityFramework;

namespace SAE_G2_Upway_API.Controllers.DTO;

public class ClientDTO
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Mail { get; set; }
    public string Telephone { get; set; }
    public string Password { get; set; }
    public string? UserRole { get; set; }
    
    public ClientDTO(Client client)
    {
        this.Nom = client.Nomclient;
        this.Prenom = client.Prenomclient;
        this.Mail = client.Mailclient;
        this.Telephone = client.Telephone;
        this.Password = client.Password;
        this.UserRole = client.UserRole;
    }
}