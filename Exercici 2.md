Els dobles de prova són recursos que s’utilitzen a l’hora de fer testing per simular com es comporta una dependència d’una aplicació en un ambient de prova.
Els tipus són:
Stub: Crear un stub vol dir crear una clase que siempre torni el mateix valor al passar pel test.
Exemple:
```
public class ArticulosStub : IArticulosRepository
{
    public int InsertarArticulo(string contenido, string titulo, int autorId)
    {
        return 1;
    }

    public Articulo GetArticulo(int id)
    {
        return new Articulo()
        {
            Autor = new Autor()
            {
                AutorId = 1,
                Nombre = "test"
            },
            Contenido = "contenido",
            Fecha = DateTime.UtcNow,
            Id = id,
            Titulo = "titulo"
        };
    }
}
```
-Fake: Un fake és una implementació de la interfaç sencera, però que només funciona dins els tests.
Exemple:
```
public class FakeArticulos : IArticulosRepository
{
    public List<Articulo> Articulos { get; set; }

    public int currentIdentifier { get; private set; }
    
    public FakeArticulos()
    {
        Articulos = new List<Articulo>();
        currentIdentifier = 0;
    }


    public int InsertarArticulo(string contenido, string titulo, int autorId)
    {
        Articulo articulo = new Articulo()
        {
            Autor = new Autor()
            {
                AutorId = autorId,
                Nombre = "test"
            },
            Contenido = contenido,
            Fecha = DateTime.UtcNow,
            Id = ++currentIdentifier,
            Titulo = titulo
        };

        Articulos.Add(articulo);
        
        return articulo.Id;
    }

    public Articulo GetArticulo(int id)
        => Articulos.FirstOrDefault(articulo => articulo.Id == id);

}
```

-Mock: Afegir configuració al test, per controlar la forma en què certs mètodes actúen.
Exemple:

```
Mock<IArticulosRepository> articuloRepo = new Mock<IArticulosRepository>();
Mock<IAutorRepository> autorRepo = new Mock<IAutorRepository>();
autorRepo.Setup(a => a.AutorValido(It.IsAny<int>())).Returns(true);

articuloRepo.Setup(a => a.InsertarArticulo(contenido, titulo, autorId)).Returns(1);
articuloRepo.Setup(a => a.GetArticulo(1)).Returns(new Articulo()
{
    Autor = new Autor()
    {
        AutorId = autorId,
        Nombre = "test"
    },
    Contenido = contenido,
    Fecha = DateTime.UtcNow,
    Id = 1,
    Titulo = titulo
});
```
