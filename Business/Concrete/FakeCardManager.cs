using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FakeCardManager : IFakeCardService
    {
        IFakeCardDal _fakeCardDal;
        public FakeCardManager(IFakeCardDal fakeCardDal)
        {
            _fakeCardDal = fakeCardDal;
        }
        public IResult Add(FakeCard fakeCard)
        {
            _fakeCardDal.Add(fakeCard);
            return new SuccessResult("eklendi");
        }

        public IResult Delete(FakeCard fakeCard)
        {
            _fakeCardDal.Delete(fakeCard);
            return new SuccessResult("silindi");
        }

        public IDataResult<List<FakeCard>> GetAll()
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll());
        }

        public IDataResult<List<FakeCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<FakeCard>>(_fakeCardDal.GetAll(f=>f.CardNumber == cardNumber));
        }

        public IDataResult<FakeCard> GetById(int cardId)
        {
            return new SuccessDataResult<FakeCard>(_fakeCardDal.Get(f => f.Id == cardId));
        }

        public IResult IsCardExist(FakeCard fakeCard)
        {
            var result = _fakeCardDal.Get(c => c.CardName == fakeCard.CardName && c.CardNumber == fakeCard.CardNumber && c.CardCvv == fakeCard.CardCvv);
            if (result == null)
            {
                return new ErrorResult("Hata");
            }
            return new SuccessResult("Başarılı");
        }

        public IResult Update(FakeCard fakeCard)
        {
            _fakeCardDal.Update(fakeCard);
            return new SuccessResult("güncellendi");
        }
    }
}
