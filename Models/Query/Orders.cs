public class OrderQueryRequest
{
    public int CustomerId { get; set; } // مشتری خاص
    public string? StartDate { get; set; } // فیلتر از تاریخ
    public string? EndDate { get; set; } // فیلتر تا تاریخ
    public string? SortBy { get; set; } = "OrderDate"; // ستون مرتب‌سازی پیش‌فرض
    public bool SortDesc { get; set; } = false; // مرتب‌سازی نزولی یا صعودی
    public int status{get;set;}
}
