using Microsoft.AspNetCore.Mvc;
using System.Linq;
using api_empresa.Models;
using System.Threading.Tasks;

namespace api_empresa.Controllers{
    [Route("api/[controller]")]
    public class MedicineController : Controller{
        private Conexion dbConexion;
        public MedicineController(){
            dbConexion = Conectar.Create();
        }
        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.Medicine.ToArray());
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id){
            var medicine = dbConexion.Medicine.SingleOrDefault(a => a.id == id);
            if(medicine != null){
                return Ok(medicine);
            }else{
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Medicine medicine){
            if(ModelState.IsValid){
                dbConexion.Medicine.Add(medicine);
                dbConexion.SaveChanges();
                return Ok(medicine);
            }else{
                return NotFound();
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] Medicine medicine){
            var v_medicinas = dbConexion.Medicine.SingleOrDefault(a => a.id == medicine.id);
            if(v_medicinas != null && ModelState.IsValid){
                dbConexion.Entry(v_medicinas).CurrentValues.SetValues(medicine);
                dbConexion.SaveChanges();
                return Ok();
            }else{
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
             var medicine = dbConexion.Medicine.SingleOrDefault(a => a.id == id);
             if(medicine != null){
                 dbConexion.Medicine.Remove(medicine);
                 dbConexion.SaveChanges();
                 return Ok();
             }else{
                 return NotFound();
             }
        }

    }
}