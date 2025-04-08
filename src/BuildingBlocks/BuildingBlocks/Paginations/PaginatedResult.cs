using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace BuildingBlocks.Paginations
{
    public class PaginatedResult<TEntity>(int pageIndex,int pageSize,long count, IEnumerable<TEntity> entities)
    {
        public int PageIndex { get; } = pageIndex;

        public int PageSize { get; } = pageSize;

        public long Count { get;  } = count;

        public IEnumerable<TEntity> Data { get; } = entities;
    }
}
