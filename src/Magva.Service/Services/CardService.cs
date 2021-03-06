﻿using System;
using System.Collections.Generic;
using Magva.Infra.Crosscutting.DataTransferObject;
using Magva.Domain.Interfaces.Repository;
using Magva.Domain.Interfaces.Service;
using Magva.Domain.Entities;
using Magva.Infra.Crosscutting.DataTransferObject.Enum;
using Magva.Domain.Shared.Enum;
using System.Linq;
using NETCore.Encrypt;
using Magva.Infra.Crosscutting.Constants;
using Magva.Domain.Validations.Cards;

namespace Magva.Service.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRespository _repository;
        private readonly ICustomerRepository _customerRepository;

        public CardService(ICardRespository repository, ICustomerRepository customerRepository)
        {
            _repository = repository;
            _customerRepository = customerRepository;
        }

        public CardDto Add(CardDto cardDto)
        {
            var customerDto = HydrateCustomerDto(_customerRepository.GetCustomerByDocument(cardDto.Document), ExceptionConstants.CUSTOMER_NOT_EXISTS);
            var password = new PasswordLengthValidation(cardDto.Password);
            var card = HydrateCard(cardDto, customerDto);

            if (cardDto.Password != null && password.Invalid)
                return HydrateCardDto(card, ExceptionConstants.ERROR_IN_PASSWORD_SIZE);


            _repository.Add(card);

            return HydrateCardDto(card, ExceptionConstants.CREATE_SUCCESS);

        }

        public IEnumerable<CardDto> GetAll()
        {
            return _repository.GetByCardAndCustomer().Select(x => HydrateCardDto(x, ExceptionConstants.REQUEST_SUCCESS));
        }

        public CardDto GetById(Guid id)
        {
            var card = _repository.GetByCardId(id);
            return HydrateCardDto(card, ExceptionConstants.REQUEST_SUCCESS);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public CardDto Update(CardDto cardDto)
        {
            var customerDto = HydrateCustomerDto(_customerRepository.GetCustomerByDocument(cardDto.Document), ExceptionConstants.CUSTOMER_NOT_EXISTS);
            var card = HydrateCard(cardDto, customerDto);


            if (customerDto == null)
                return HydrateCardDto(card, customerDto.Message);


            _repository.Update(card);
            return HydrateCardDto(card, ExceptionConstants.CREATE_SUCCESS);

        }

        private CardDto HydrateCardDto(Card card, string message)
        {
            return new CardDto
            {
                Active = card.Active,
                Balance = card.Balance,
                CardBrand = card.CardBrand,
                ExpirationDate = card.ExpirationDate,
                Number = card.Number,
                SecurityCode = card.SecurityCode,
                Password = card.Password,
                HasPassword = card.HasPassword,
                Type = (ECardTypeDto)card.Type,
                Id = card.Id,
                CardholderName = card.Customer.Name,
                CustomerId = card.Customer.Id,
                Document = card.Customer.Document,
                Message = message,
            };
        }

        private Card HydrateCard(CardDto cardDto, CustomerDto customerDto)
        {
            return new Card
            {
                Active = cardDto.Active,
                Balance = cardDto.Balance,
                CardBrand = cardDto.CardBrand,
                ExpirationDate = cardDto.ExpirationDate,
                Number = cardDto.Number,
                SecurityCode = cardDto.SecurityCode,
                Password = (cardDto.Password != null) ? EncryptProvider.Base64Encrypt(cardDto.Password) : string.Empty,
                HasPassword = cardDto.HasPassword,
                Type = (ECardType)cardDto.Type,
                Id = cardDto.Id,
                Customer = new Customer
                {
                    Document = customerDto.Document,
                    Name = customerDto.Name,
                    Id = customerDto.Id,
                }
            };
        }

        private CustomerDto HydrateCustomerDto(Customer customer, string messsage)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Document = customer.Document,
                Email = customer.Document,
                Phone = customer.Phone,
                Message = messsage,
            };
        }
    }
}
