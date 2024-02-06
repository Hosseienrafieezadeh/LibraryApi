using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Migrations
{
    [Migration(202402061111)]
    public class _202402061111_AddBooktables : Migration
    {

        public override void Up()
        {
            Create.Table("Books")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString().NotNullable()
               .WithColumn("DateOfRelease").AsDateTime().NotNullable()
               .WithColumn("Inventory").AsInt32().NotNullable()
               .WithColumn("WriterId").AsInt32().NotNullable()
               .WithColumn("ShelfId").AsInt32().NotNullable();

            Create.Table("Members")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Email").AsString().NotNullable();

            Create.Table("Rents")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("BackBook").AsBoolean().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                .WithColumn("BookId").AsInt32().NotNullable();

            Create.Table("Shelves")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString().NotNullable();

            Create.Table("Writers")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();

            
            Create.ForeignKey("FK_Books_Writers")
                .FromTable("Books").ForeignColumn("WriterId")
                .ToTable("Writers").PrimaryColumn("Id");

            Create.ForeignKey("FK_Books_Shelves")
                .FromTable("Books").ForeignColumn("ShelfId")
                .ToTable("Shelves").PrimaryColumn("Id");

            Create.ForeignKey("FK_Rents_Members")
                .FromTable("Rents").ForeignColumn("UserId")
                .ToTable("Members").PrimaryColumn("Id");

            Create.ForeignKey("FK_Rents_Books")
                .FromTable("Rents").ForeignColumn("BookId")
                .ToTable("Books").PrimaryColumn("Id");
        }
        public override void Down()
        {
            Delete.Table("Books");
            Delete.Table("Members");
            Delete.Table("Rents");
            Delete.Table("Shelves");
            Delete.Table("Writers");
        }
    }
}
