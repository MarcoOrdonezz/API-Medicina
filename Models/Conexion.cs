using Microsoft.EntityFrameworkCore;
namespace api_empresa.Models{
    class Conexion : DbContext {
         public Conexion (DbContextOptions<Conexion> options) : base(options){}
        public DbSet<Clientes> Clientes {get;set;}
        public DbSet<Medicine> Medicine {get;set;}  

    }
    class Conectar{
        private const string cadenaConexion = "server=localhost;port=3306;database=db_hospital;userid=root;pwd=12345678";
        public static Conexion Create(){
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new Conexion(constructor.Options);
            return cn;
        }
    }
}