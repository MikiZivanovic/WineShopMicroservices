using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Paginations
{
    public record PaginatedRequest(int PageIndex = 0, int PageSize = 4);


}