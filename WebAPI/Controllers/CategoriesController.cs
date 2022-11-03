using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategorieService _categorieService;

        public CategoriesController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        [HttpGet(template: "getall")]
        public IActionResult GetList()
        {
            var result = _categorieService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet(template: "getbyid")]
        public IActionResult GetById(int categorieId)
        {
            var result = _categorieService.GetById(categorieId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Categorie categorie)
        {
            var result = _categorieService.Add(categorie);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "update")]
        public IActionResult Update(Categorie categorie)
        {
            var result = _categorieService.Update(categorie);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost(template: "delete")]
        public IActionResult Delete(Categorie categorie)
        {
            var result = _categorieService.Delete(categorie);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
