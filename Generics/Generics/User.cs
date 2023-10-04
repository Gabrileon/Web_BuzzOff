using Common.Interfaces;
using Common.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Generics
{
    public class User : IUser
    {
        /// <summary>
        /// Insert.
        /// Sem nivel de acesso = usuário comum.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="cpf"></param>
        /// <param name="password"></param>
        /// <param name="accessLevel"></param>
        /// <param name="id"></param>
        public User(string name, string email, string cpf, string password, MyEnuns.Access accessLevel = MyEnuns.Access.Common)
        {
            Name = name;
            Email = email;
            Password = password;
            CPF = cpf;
            AccessLevel = accessLevel;
        }
        public User(int id,string name, string email, string cpf, string password, MyEnuns.Access accessLevel)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            CPF = cpf;
            AccessLevel = accessLevel;
        }
        public User()
        {

        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="cpf"></param>
        /// <param name="accessLevel"></param>
        /// <param name="id"></param>
        public User(string name, string email, string cpf, MyEnuns.Access accessLevel, int id = 0)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = "*****";
            CPF = cpf;
            AccessLevel = accessLevel;
        }
        public static List<User> Users = new List<User>()
        {
            new User(1, "Marco Antonio Angelo", "marco.angelo@prof.sc.senac.br","13426542935", "Bolinha", MyEnuns.Access.Agent),
            new User(2, "Viniezao", "vinicius.macaneiro@alunos.sc.senac.br","13426542935", "Bolinha", MyEnuns.Access.Common),
            new User(3, "Ladeiro", "ladeiro@alunos.sc.senac.br","13426542935", "Bolinha", MyEnuns.Access.Common)
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CPF { get; set; }
        public MyEnuns.Access AccessLevel { get; set; }
    }
}
