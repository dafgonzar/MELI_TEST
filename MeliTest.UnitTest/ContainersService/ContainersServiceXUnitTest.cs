using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeliTest.Core.Services;
using MeliTest.Core.Entities;
using MeliTest.Core.QueryFilters;
using Xunit;

namespace MeliTest.UnitTest.Services
{
    public class ContainersServiceXUnitTest
    {
        [Fact]
        public void GetAll()
        {
            //Arrange
            var containersService = new ContainersService();
            var containerFilters = new ContainersQueryFilter 
            { 
                NombreContenedor = ""            
            };
            bool isValid = false;

            //Act
            var containers = containersService.GetAll(containerFilters);
            if (containers != null)
            {
                isValid = true;
            }
            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void GetStats()
        {
            //Arrange
            var containersService = new ContainersService();
            int budgetUsed = 1610;
            bool isValid = false;

            //Act
            var containersStats = containersService.GetStats(budgetUsed);
            if (containersStats != null)
            {
                isValid = true;
            }
            //Assert
            Assert.True(isValid);
        }

        [Fact]
        public void PostContainers()
        {
            //Arrange
            var containersService = new ContainersService();
            TbContenedores tbContenedor = new TbContenedores { 
                        NombreContenedor = "C7",
                        CostoTransporte = 551,
                        ValorContainer = 13224

            };
            bool isValid = false;

            //Act
            var containersStats = containersService.Insert(tbContenedor);
            if (containersStats != null)
            {
                isValid = true;
            }
            //Assert
            Assert.True(isValid);
        }
    }
}
