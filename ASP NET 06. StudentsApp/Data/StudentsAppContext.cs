using System;
using System.Collections.Generic;
using System.Linq;
using ASP_NET_06._StudentsApp.Models;
using Microsoft.EntityFrameworkCore;
public class StudentsAppContext : DbContext
{
    public StudentsAppContext(DbContextOptions<StudentsAppContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Student { get; set; } = default!;
}
