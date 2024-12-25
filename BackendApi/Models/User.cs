using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Listing> Listings { get; set; } = new List<Listing>();

    public virtual ICollection<Message> MessageReceivers { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageSenders { get; set; } = new List<Message>();

    public virtual ICollection<UserReview> UserReviewReviewedUsers { get; set; } = new List<UserReview>();

    public virtual ICollection<UserReview> UserReviewReviewers { get; set; } = new List<UserReview>();
}
