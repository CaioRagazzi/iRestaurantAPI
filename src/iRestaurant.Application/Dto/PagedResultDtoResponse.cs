using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace iRestaurant.Application.Dto
{
    public class PagedResultDtoResponse<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int FirstRowOnPage { get; set; }
        public int LastRowOnPage { get; set; }
        public IList<T> Results { get; set; }
    }
}
