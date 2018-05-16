namespace WebApplication2.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BusinessLayer.Interfaces;
    using DataLayerInterfaces;
    using Moq;

    [TestClass]
    public class PersonTests
    {
        private IPersonBusinessLayer personBusinessLayer;
        private Mock<IPersonDataLayer> moq_personDataLayer;

        public void Initialize()
        {
            moq_personDataLayer = new Mock<IPersonDataLayer>();

            moq_personDataLayer.Setup(dl => dl.GetTextData())
                .Returns(new )
        }
    }
}
