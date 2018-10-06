namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMoviesFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenraId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenraId", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
