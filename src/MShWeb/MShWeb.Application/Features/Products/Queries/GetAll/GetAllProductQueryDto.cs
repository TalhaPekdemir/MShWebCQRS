using MShWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShWeb.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductQueryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image> Images { get; set; }
    }
}
