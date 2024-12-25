using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class UserReview
{
    public int ReviewId { get; set; }

    public int ReviewerId { get; set; }

    public int ReviewedUserId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User ReviewedUser { get; set; } = null!;

    public virtual User Reviewer { get; set; } = null!;
}
