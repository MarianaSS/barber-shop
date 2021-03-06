using BarberShop.Service.Repository.Interfaces;
using BarberShop.Service.Repository.Interfaces.ModelsRepository;
using BarberShop.Service.Services;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Service.Models;
using BarberShop.Service.Utilities;

namespace BarberShop.Tests
{
    public class ShopAddressTests
    {
        private Mock<IShopAddressRepository> _shopAddressRepository;
        private Mock<ILogger> _logger;
        private int _id = 1;
        private string _name = "Name";
        private string _street = "Street";
        private int _number = 100;
        private string _city = "City";
        private string _state = "State";
        private List<Shop> _shopAddresses;

        public ShopAddressTests()
        {
            _shopAddressRepository = new Mock<IShopAddressRepository>();
            _logger = new Mock<ILogger>();
            _shopAddresses = new List<Shop>()
            {
                new Shop()
                {
                    Id = _id,
                    Name = _name,
                    Number = _number,
                    City = _city,
                    State = _state
                },
                new Shop()
                {
                    Id = _id,
                    Name = _name,
                    Number = _number,
                    City = _city,
                    State = _state
                }
            };        
        }

        [Fact]
        public void CreateShopAddressNullTest()
        {
            Shop shopAddress = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressNameNullTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = null,
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressNameEmptyTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = "",
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressStreetNullTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = null,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressStreetEmptyTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = "",
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressCityNullTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = null,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressCityEmptyTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = "",
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressStateNullTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = _state,
                State = null,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressStateEmptyTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = _state,
                State = "",
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressNumberLessThanZeroTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = _city,
                State = _state,
                Number = -1
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentOutOfRangeException>(() => instance.Create(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void CreateShopAddressTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(X => X.CreateLog("Database", "Insert", "ShopAddress", new string[] { shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State }));
            _shopAddressRepository.Setup(x => x.Create(shopAddress));

            var instance = GetInstance();

            instance.Create(shopAddress);

            _logger.Verify();
            _shopAddressRepository.Verify();
        }

        [Fact]
        public void DeleteShopAddressNullTest()
        {
            Shop shopAddress = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Delete(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void DeleteShopAddressIdLessThanZeroTest()
        {
            Shop shopAddress = new Shop()
            {
                Id = -1
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentOutOfRangeException>(() => instance.Delete(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void DeleteShopAddressTest()
        {
            Shop shopAddress = new Shop()
            {
                Id = _id,
                Name = _name,
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Database", "Delete", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State }));
            _shopAddressRepository.Setup(x => x.Delete(shopAddress));

            var instance = GetInstance();

            instance.Delete(shopAddress);

            _logger.Verify();
            _shopAddressRepository.Verify();
        }

        [Fact]
        public void ReadShopAddressNameNullTest()
        {
            string name = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Read(name));

            _logger.Verify();
        }

        [Fact]
        public void ReadShopAddressNameEmptyTest()
        {
            string name = "";

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Read(name));

            _logger.Verify();
        }

        [Fact]
        public void ReadShopAddressTest()
        {
            string name = _name;

            var shopAddress = new Shop()
            {
                Id = _id,
                Name = _name,
                Street = _street,
                Number = _number,
                City = _city,
                State = _state
            };

            _logger.Setup(x => x.CreateLog("Database", "Read", "ShopAddress", new string[] { shopAddress.Id.ToString(), shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State }));
            _shopAddressRepository.Setup(x => x.Read(name)).Returns(shopAddress);

            var instance = GetInstance();

            var result = instance.Read(name);

            Assert.NotNull(result);

            _logger.Verify();
            _shopAddressRepository.Verify();
        }

        [Fact]
        public void UpdateShopAddressNullTest()
        {
            Shop shopAddress = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentNullException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressNameNullTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = null,
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressNameEmptyTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = "",
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressStreetNullTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = null,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressStreetEmptyTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = "",
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressCityNullTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = null,
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressCityEmptyTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = "",
                State = _state,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressStateNullTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = _state,
                State = null,
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressStateEmptyTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = _state,
                State = "",
                Number = _number
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressNumberLessThanZeroTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = _city,
                State = _state,
                Number = -1
            };

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));

            var instance = GetInstance();

            Assert.Throws<ArgumentOutOfRangeException>(() => instance.Update(shopAddress));

            _logger.Verify();
        }

        [Fact]
        public void UpdateShopAddressTest()
        {
            Shop shopAddress = new Shop()
            {
                Name = _name,
                Street = _street,
                City = _city,
                State = _state,
                Number = _number
            };

            _logger.Setup(X => X.CreateLog("Database", "Insert", "ShopAddress", new string[] { shopAddress.Name, shopAddress.Street, shopAddress.Number.ToString(), shopAddress.State }));
            _shopAddressRepository.Setup(x => x.Update(shopAddress));

            var instance = GetInstance();

            instance.Update(shopAddress);

            _logger.Verify();
            _shopAddressRepository.Verify();
        }

        [Fact]
        public void GetAllNullShopAddressesTest()
        {
            List<Shop> shopAddresses = null;

            _logger.Setup(x => x.CreateLog("Error", "Exception Message"));
            _shopAddressRepository.Setup(x => x.GetAll()).Returns(shopAddresses);

            var instance = GetInstance();

            Assert.Throws<Exception>(() => instance.GetAll());

            _logger.Verify();
            _shopAddressRepository.Verify();
        }

        [Fact]
        public void GetAllShopAddressesTest()
        {
            List<Shop> shopAddresses = _shopAddresses;

            _logger.Setup(x => x.CreateLog("Database", "GetAllShopAddresses"));
            _shopAddressRepository.Setup(x => x.GetAll()).Returns(shopAddresses);

            var instance = GetInstance();

            var result = instance.GetAll();

            Assert.NotNull(result);

            _logger.Verify();
            _shopAddressRepository.Verify();
        }

        public ShopAddressService GetInstance()
        {
            return new ShopAddressService(_shopAddressRepository.Object, _logger.Object);
        }
    }
}
