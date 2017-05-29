namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSeedDataGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Genres(Id, Name) VALUES (1, 'Bollywood')");
            Sql("INSERT INTO dbo.Genres(Id, Name) VALUES  (2, 'Jazz')");
            Sql("INSERT INTO dbo.Genres(Id, Name) VALUES  (3, 'Rock')");
            Sql("INSERT INTO dbo.Genres(Id, Name) VALUES  (4, 'Romantic')");
            Sql("INSERT INTO dbo.Genres(Id, Name) VALUES  (5, 'Voltz')");
            Sql("INSERT INTO dbo.Genres(Id, Name) VALUES  (6, 'Garba')");
            Sql("INSERT INTO dbo.Genres(Id, Name) VALUES  (7, 'Bhangra')");
            Sql("INSERT INTO dbo.Genres(Id, Name) VALUES  (8, 'DesiBitz')");
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Genres WHERE ID In(1,2,3,4,5,6,7,8)");
        }
    }
}
