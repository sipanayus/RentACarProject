using Business.Abstract;
using Business.Constants;
using Core.Utilities.Bussines;
using Core.Utilities.FileUploads;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImage)
        {
            _carImageDal = carImage;
        }
     
        public IResult Add(IFormFile file, CarImage carImage, int carId)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Add(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageAdded);
        }
        //[CacheRemoveAspect("ICarImageService.GetCarImageDetails")]
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }
       
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ImageListed);
        }

     
        public IDataResult<List<CarImageDto>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetCarImageDetails(carImage => carImage.CarId == carId).Any();
            return new SuccessDataResult<List<CarImageDto>>(_carImageDal.GetCarImageDetails(p => p.CarId == carId), Messages.ImageListed);
        }



        public IResult Update(IFormFile image, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.CarId == carImage.CarId);

            var updatedFile = FileHelper.Update(image, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");

        }

        private IResult CheckImageLimitExceeded(int id)
        {
            if (_carImageDal.GetAll(image => image.CarId == id).Count >= 5)
            {
                return new ErrorResult(Messages.ImageCountExceded);
            }

            return new SuccessResult();

        }
       
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageId == id));
        }
        private IResult CarImageDelete(CarImage carImage)
        {
            var newPath = carImage.ImagePath.Replace('/', '\\');
            var secondPath = "C:" + newPath + ".";
            try
            {
                File.Delete(secondPath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var getAllbyCarIdResult = _carImageDal.GetAll(p => p.CarId == carId);
            if (getAllbyCarIdResult.Count == 0)
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage>
                {
                    new CarImage
                    {
                        CarImageId = -1,
                        CarId = carId,
                        Date = DateTime.MinValue,
                        ImagePath = "images/default.jpg"
                    }
                });
            }

            return new SuccessDataResult<List<CarImage>>(getAllbyCarIdResult);
        }

    }
}
