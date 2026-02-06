using BE100.Entities;
using BE100.Entities.Enum;
using Microsoft.EntityFrameworkCore;

namespace BE100.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<AppUser> AppUser => Set<AppUser>();
        public DbSet<QuestionCategory> QuestionCategory => Set<QuestionCategory>();
        public DbSet<TrafficSignCategory> TrafficSignCategory => Set<TrafficSignCategory>();
        public DbSet<TrafficSign> TrafficSign => Set<TrafficSign>();
        public DbSet<Question> Question => Set<Question>();
        public DbSet<Answer> Answer => Set<Answer>();
        public DbSet<Exam> Exam => Set<Exam>();
        public DbSet<ExamQuestion> ExamQuestion => Set<ExamQuestion>();
        public DbSet<ExamHistory> ExamHistory => Set<ExamHistory>();
        public DbSet<ExamAnswer> ExamAnswer => Set<ExamAnswer>();
        public DbSet<RefreshToken> RefreshToken => Set<RefreshToken>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresEnum<QuestionType>("question_type");
            modelBuilder.HasPostgresEnum<ExamStatus>("exam_status");
            modelBuilder.HasPostgresEnum<ExamResult>("exam_result");
            modelBuilder.HasPostgresEnum<Role>("user_role");

            modelBuilder.Entity<AppUser>().ToTable("AppUser");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Answer>().ToTable("Answer");
            modelBuilder.Entity<Exam>().ToTable("Exam");
            modelBuilder.Entity<ExamQuestion>().ToTable("ExamQuestion");
            modelBuilder.Entity<ExamHistory>().ToTable("ExamHistory");
            modelBuilder.Entity<ExamAnswer>().ToTable("ExamAnswer");
            modelBuilder.Entity<QuestionCategory>().ToTable("QuestionCategory");
            modelBuilder.Entity<TrafficSign>().ToTable("TrafficSign");
            modelBuilder.Entity<TrafficSignCategory>().ToTable("TrafficSignCategory");
            modelBuilder.Entity<RefreshToken>().ToTable("RefreshToken");

            modelBuilder.Entity<AppUser>().HasKey(x => x.Id);
            modelBuilder.Entity<Question>().HasKey(x => x.id);
            modelBuilder.Entity<Answer>().HasKey(x => x.id);
            modelBuilder.Entity<Exam>().HasKey(x => x.id);
            modelBuilder.Entity<ExamQuestion>().HasKey(x => x.id);
            modelBuilder.Entity<ExamHistory>().HasKey(x => x.id);
            modelBuilder.Entity<ExamAnswer>().HasKey(x => x.id);
            modelBuilder.Entity<QuestionCategory>().HasKey(x => x.id);
            modelBuilder.Entity<TrafficSign>().HasKey(x => x.id);
            modelBuilder.Entity<TrafficSignCategory>().HasKey(x => x.id);
            modelBuilder.Entity<RefreshToken>().HasKey(x => x.id);

            modelBuilder.Entity<AppUser>()
                .Property(u => u.Role)
                .HasColumnType("user_role");
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.question_id);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Category)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.category_id);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.TrafficSign)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.traffic_sign_id);

            modelBuilder.Entity<Question>()
                 .Property(q => q.question_type)
                 .HasColumnType("question_type");

            modelBuilder.Entity<ExamHistory>()
                .Property(e => e.status)
                .HasColumnType("exam_status");


            modelBuilder.Entity<ExamHistory>()
                .Property(e => e.result)
                .HasColumnType("exam_result");


            modelBuilder.Entity<TrafficSign>()
                .HasOne(t => t.Category)
                .WithMany(c => c.TrafficSigns)
                .HasForeignKey(t => t.category_id);

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Exam)
                .WithMany(e => e.ExamQuestions)
                .HasForeignKey(eq => eq.exam_id);

            modelBuilder.Entity<ExamQuestion>()
                .HasOne(eq => eq.Question)
                .WithMany(q => q.ExamQuestions)
                .HasForeignKey(eq => eq.question_id);

            modelBuilder.Entity<ExamHistory>()
                .HasOne(eh => eh.User)
                .WithMany(u => u.ExamHistories)
                .HasForeignKey(eh => eh.user_id);

            modelBuilder.Entity<ExamHistory>()
                .HasOne(eh => eh.Exam)
                .WithMany(e => e.ExamHistories)
                .HasForeignKey(eh => eh.exam_id);

            modelBuilder.Entity<ExamAnswer>()
                .HasOne(ea => ea.examHistory)
                .WithMany(eh => eh.ExamAnswers)
                .HasForeignKey(ea => ea.exam_history_id);

            modelBuilder.Entity<ExamAnswer>()
                .HasOne(ea => ea.question)
                .WithMany()
                .HasForeignKey(ea => ea.question_id);

            modelBuilder.Entity<ExamAnswer>()
                .HasOne(ea => ea.Answer)
                .WithMany(a => a.ExamAnswers)
                .HasForeignKey(ea => ea.answer_id);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.user_id);
        }
    }
}
