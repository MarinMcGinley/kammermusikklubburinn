using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class PagedResultDto<T>
{
    public required int PageIndex { get; set; }

    public required int PageSize { get; set; }
    public required int Count { get; set; }
    public required List<T> Data { get; set; }


}
