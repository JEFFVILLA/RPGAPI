using System.Collections.Generic;

namespace netCoreApi.Models
{
    public class User
    {
        public int Id {get; set;}
        public string Username  {get; set;}
        public byte[] PasswordHash {get ;set;}
        public byte[] PassWordSalt {get; set;}

        public List<Character> Characters {get; set;}
    }
}