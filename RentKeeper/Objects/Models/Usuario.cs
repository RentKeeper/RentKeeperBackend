namespace RentKeeper.Models
{
    public enum RoleUsuario
    {
        Admin,
        Goleiro,
        Cliente
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public RoleUsuario Role { get; set; }
    }
}
