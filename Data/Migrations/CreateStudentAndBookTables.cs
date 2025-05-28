using FluentMigrator;

namespace online_school_api.Migrations
{
    [Migration(26052025)] 
    public class CreateStudentAndBookTables : Migration
    {
        public override void Up()
        {
            Create.Table("students")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("email").AsString().NotNullable()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("age").AsInt32().NotNullable()
                .WithColumn("university").AsString().NotNullable();

            Create.Table("books")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("StudentId").AsInt32().ForeignKey("students", "id").OnDelete(System.Data.Rule.Cascade);

            Create.Table("courses")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("department").AsString().NotNullable();

            Create.Table("enrolments")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("studentId").AsInt32().ForeignKey("students", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("courseId").AsInt32().ForeignKey("courses", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("createdAt").AsDate().NotNullable();

        }

        public override void Down()
        {
            Delete.Table("books");
            Delete.Table("students");
            Delete.Table("enrolemts");
            Delete.Table("courses");
        }
    }
}