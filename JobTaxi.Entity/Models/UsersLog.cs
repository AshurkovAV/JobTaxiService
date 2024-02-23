using System;
using System.Collections.Generic;

namespace JobTaxi.Entity.Models;

public partial class UsersLog
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime? NoteDate { get; set; }

    public string TableName { get; set; } = null!;

    public int ObjectId { get; set; }

    public string? FieldName { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public int? CreateFlag { get; set; }

    public int? DelFlag { get; set; }

    public string? PaketCondition { get; set; }

    public virtual UsersWeb User { get; set; } = null!;
}
