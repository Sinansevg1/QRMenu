using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;
using AutoMapper;
namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    { private readonly IDiscountService _disvountService;
      private readonly IMapper _mapper;

        public DiscountController(IDiscountService disvountService, IMapper mapper)
        {
            _disvountService = disvountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_disvountService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _disvountService.TAdd(new Discount()
            {
                Title = createDiscountDto.Title,
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl
            });
            return Ok("indirim kodu eklendi");
        }
        [HttpDelete("{id}")]    
        public IActionResult DeleteDiscount(int id)
        {
            var values = _disvountService.TGetByID(id);
            _disvountService.TDelete(values);
            return Ok("indirim kodu silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var values = _disvountService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _disvountService.TUpdate(new Discount()
            {
                DiscountID=updateDiscountDto.DiscountID,
                Title = updateDiscountDto.Title,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl
            });
            return Ok("indirim kodu güncellendi");
        }
    }
}
