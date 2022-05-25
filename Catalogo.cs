namespace web_projeto_alura
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();

            livros.Add(new Livro("001", "Quem Mexeu na Minha Query?", 12.99m));
            livros.Add(new Livro("002", "Fique Rico com C#", 30.99m));
            livros.Add(new Livro("003", "Java para Baixinhos", 25.99m));

            return livros;
        }
    }
}
