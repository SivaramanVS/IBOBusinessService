﻿using BusinessService.Data.DBModel;
using Microsoft.EntityFrameworkCore;

namespace BusinessService.Data
{
    public class DefaultContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<School> Schools { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }
    }
}