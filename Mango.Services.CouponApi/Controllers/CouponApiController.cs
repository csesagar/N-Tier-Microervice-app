using AutoMapper;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext db;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponApiController(AppDbContext db , IMapper mapper)
        {
            this.db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = db.Coupons.ToList();
                //_response.Result = objList;
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);


            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon objList = db.Coupons.First(u => u.CouponId == id);
                //_response.Result = objList;
                _response.Result = _mapper.Map<Coupon>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public object GetByCode(String code)
        {
            try
            {
                Coupon objList = db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                if(objList == null)
                {
                    _response.IsSuccess = false;
                }
                //_response.Result = objList;
                _response.Result = _mapper.Map<Coupon>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                db.Coupons.Add(obj);
                db.SaveChanges();
                _response.Result = _mapper.Map<Coupon>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto )
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                db.Coupons.Update(obj);
                db.SaveChanges();
                _response.Result = _mapper.Map<Coupon>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = db.Coupons.First(u => u.CouponId == id);
                db.Coupons.Remove(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
