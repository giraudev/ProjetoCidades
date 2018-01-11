using System.Collections.Generic;

namespace ProjetoCidades.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public int Habitantes { get; set; }

        public List<Cidade> ListarCidades(){
            List<Cidade>cidade = new List<Cidade>(){
                new Cidade{Id=10, Nome="Curitiba", Estado="PR",Habitantes=256384},
                new Cidade{Id=13, Nome="São Paulo", Estado="SP", Habitantes=12513264},
                new Cidade{Id=12, Nome="Belo Horizonte", Estado="MG",Habitantes=284},
                new Cidade{Id=11, Nome="Salvador", Estado="BA",Habitantes=2654},
                new Cidade{Id=14, Nome="Guaxupé", Estado="MG",Habitantes=563},
                new Cidade{Id=15, Nome="Ubatuba", Estado="SP",Habitantes=333},
                new Cidade{Id=15, Nome="Santos", Estado="SP",Habitantes=111},
                new Cidade{Id=17, Nome="Bertioga", Estado="SP",Habitantes=555},
                new Cidade{Id=18, Nome="Linhares", Estado="ES",Habitantes=284},
                new Cidade{Id=19, Nome="Florianópolis", Estado="SC",Habitantes=3332},
                new Cidade{Id=20, Nome="Búzios", Estado="RJ",Habitantes=1234},
            };
            return cidade;
        }




    }

}