using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public int ListingId { get; set; }

    public string MessageText { get; set; } = null!;

    public DateTime? SentAt { get; set; }

    public virtual Listing Listing { get; set; } = null!;

    public virtual User Receiver { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
