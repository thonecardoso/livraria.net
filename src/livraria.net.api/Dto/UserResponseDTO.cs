using livraria.net.core.Enums;
using System;

namespace livraria.net.api.Dto
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}
