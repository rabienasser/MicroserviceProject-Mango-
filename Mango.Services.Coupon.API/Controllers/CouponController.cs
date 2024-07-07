using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.DTOs;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly CouponDbContext _context;
        private readonly IMapper _mapper;
        public CouponController(CouponDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET ALL COUPONS
        [HttpGet]
        public ResponseDTO<List<CouponDTO>> Get()
        {
            var response = new ResponseDTO<List<CouponDTO>>();
            try
            {
                var coupons = _context.Coupons.ToList();
                var couponDtos = _mapper.Map<List<CouponDTO>>(coupons);
                response.Result = couponDtos;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


        // GET COUPON BY ID
        [HttpGet]
        [Route("{id}")]
        public ResponseDTO<CouponDTO> GetById(int id)
        {
            var response = new ResponseDTO<CouponDTO>();
            try
            {
                var coupon = _context.Coupons.First(x => x.CouponId == id);
                var couponDto = _mapper.Map<CouponDTO>(coupon);
                response.Result = couponDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        // GET COUPON BY COUPON CODE
        [HttpGet]
        [Route("Code/{code}")]
        public ResponseDTO<CouponDTO> GetByCode(string code)
        {
            var response = new ResponseDTO<CouponDTO>();
            try
            {
                var coupon = _context.Coupons.FirstOrDefault(x => x.CouponCode.ToLower() == code.ToLower());
                if (coupon == null)
                {
                    response.IsSuccess = false;
                }

                var couponDto = _mapper.Map<CouponDTO>(coupon);
                response.Result = couponDto;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }


        // CREATE COUPON
        [HttpPost]
        public ResponseDTO<bool> Create([FromBody] CouponDTO dto)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                var coupon = _mapper.Map<Coupon>(dto);
                _context.Coupons.Add(coupon);
                _context.SaveChanges();
                response.Result = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        // UPDATE COUPON
        [HttpPut]
        [Route("{id}")]
        public ResponseDTO<int> Update([FromBody] CouponDTO dto)
        {
            var response = new ResponseDTO<int>();
            try
            {
                var coupon = _mapper.Map<Coupon>(dto);
                _context.Coupons.Update(coupon);
                _context.SaveChanges();
                response.Result = coupon.CouponId;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        // DELETE COUPON
        [HttpDelete]
        [Route("{id}")]
        public ResponseDTO<int> Delete(int id)
        {
            var response = new ResponseDTO<int>();
            try
            {
                var coupon = _context.Coupons.First(x => x.CouponId == id);
                _context.Coupons.Remove(coupon);
                _context.SaveChanges();
                response.Result = id;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
